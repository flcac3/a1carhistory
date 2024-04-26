using Microsoft.AspNetCore.Mvc;
using userinfo.Interfaces;
using userinfo.Models;
using userinfo.ViewModels;
using System.Linq;
using userinfo.Repository;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace userinfo.Controllers
{
    public class ServiceLogsController : Controller
    {
        private readonly IServiceLogsRepository _serviceLogsRepository;
        private readonly IGarageRepository _garageRepository;

        public ServiceLogsController(IServiceLogsRepository serviceLogRepository, IGarageRepository garageRepository)
        {
            _serviceLogsRepository = serviceLogRepository;
            _garageRepository = garageRepository;
        }

        public IActionResult Create(int vehicleId)
        {
            ViewBag.VehicleId = vehicleId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Servicelog servicelog)
        {
            if (!ModelState.IsValid)
            {
                return View(servicelog);
            }
            _serviceLogsRepository.add(servicelog);

            // Assuming that your vehicle details action is named "Details" and is in a controller named "Vehicles"
            return RedirectToAction("Detail", "Garage", new { id = servicelog.vehicleId});
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var servicelogs = await _serviceLogsRepository.GetByIdAsync(id);
            if (servicelogs == null) return View("Error");
            var servicelogVM = new EditServiceLogViewModel
            {
                date = servicelogs.date,
                mileageIn = servicelogs.mileageIn,
                mileageOut = servicelogs.mileageOut,
                serviceNotes = servicelogs.serviceNotes
            };
            return View(servicelogVM);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditServiceLogViewModel servicelogVM, Servicelog servicelog)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit Vehicle");
                return View("Edit", servicelogVM);
            }
            var userServiceLog = await _serviceLogsRepository.GetByIdAsync(id);

            if (userServiceLog == null)
            {
                return View("Error");
            }

            // Update the properties of userVehicle with the values from garageVM
            userServiceLog.date = servicelogVM.date;
            userServiceLog.mileageIn = servicelogVM.mileageIn;
            userServiceLog.mileageOut = servicelogVM.mileageOut;
            userServiceLog.serviceNotes = servicelogVM.serviceNotes;

            _serviceLogsRepository.update(userServiceLog);
            return RedirectToAction("Detail", "Garage", new { id = userServiceLog.vehicleId });
        }
    
    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var servicelog = await _serviceLogsRepository.GetByIdAsync(id);
        if (servicelog == null) return View("Error");
        return RedirectToAction("Detail", "Garage", new { id = servicelog.vehicleId });
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteLog(int id)
        {
            var servicelog = await _serviceLogsRepository.GetByIdAsync(id);
            if (servicelog == null) return View("Error");
            _serviceLogsRepository.delete(servicelog);
            return RedirectToAction("Detail", "Garage", new { id = servicelog.vehicleId });
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using userinfo.Interfaces;
using userinfo.Models;
using userinfo.ViewModels;
using System.Linq;
using userinfo.Repository;
using System.Threading.Tasks;

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

    }
}
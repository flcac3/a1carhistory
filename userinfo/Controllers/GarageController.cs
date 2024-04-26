using Microsoft.AspNetCore.Mvc;
using userinfo.Interfaces;
using userinfo.Models;
using userinfo.ViewModels;
using System.Linq;
using userinfo.Repository;

namespace userinfo.Controllers
{
    public class GarageController : Controller
    {
        private readonly IGarageRepository _garageRepository;
        private readonly IServiceLogsRepository _serviceLogsRepository;

        public GarageController(IGarageRepository garageRepository, IServiceLogsRepository serviceLogRepository)
        {
            _garageRepository = garageRepository;
            _serviceLogsRepository = serviceLogRepository;
        }

        public async Task<IActionResult> Index()
        {
            var garages = await _garageRepository.GetAll();
            return View(garages);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var vehicle = await _garageRepository.GetByIdAsync(id);
            var serviceLogs = (await _serviceLogsRepository.GetAll()).Where(log => log.vehicleId == id).ToList();

            var viewModel = new GarageServiceLogViewModel
            {
                Vehicle = vehicle,
                ServiceLogs = serviceLogs
            };

            return View(viewModel);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Garage garage)
        {
            if (!ModelState.IsValid)
            {
                return View(garage);
            }
            _garageRepository.add(garage);

            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var vehicle = await _garageRepository.GetByIdAsync(id);
            if (vehicle == null) return View("Error");
            var garageVM = new EditGarageViewModel
            {

                vehicleId = vehicle.vehicleId,
                vin = vehicle.vin,
                Make = vehicle.Make,
                Model = vehicle.Model,
                trim = vehicle.trim,
                modelYear = vehicle.modelYear,
                engineCylinders = vehicle.engineCylinders,
                displacementL = vehicle.displacementL,
                engineHP = vehicle.engineHP,
                driveType = vehicle.driveType,
                Mileage = vehicle.Mileage,
                nickname = vehicle.nickname,
                purchaseDate = vehicle.purchaseDate
            };
            return View(garageVM);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditGarageViewModel garageVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit Vehicle");
                return View("Edit", garageVM);
            }
            var userVehicle = await _garageRepository.GetByIdAsync(id);

            if (userVehicle == null)
            {
                return View("Error");
            }

            // Update the properties of userVehicle with the values from garageVM
            userVehicle.vin = garageVM.vin;
            userVehicle.Make = garageVM.Make;
            userVehicle.Model = garageVM.Model;
            userVehicle.trim = garageVM.trim;
            userVehicle.modelYear = garageVM.modelYear;
            userVehicle.engineCylinders = garageVM.engineCylinders;
            userVehicle.displacementL = garageVM.displacementL;
            userVehicle.engineHP = garageVM.engineHP;
            userVehicle.driveType = garageVM.driveType;
            userVehicle.Mileage = garageVM.Mileage;
            userVehicle.nickname = garageVM.nickname;
            userVehicle.purchaseDate = garageVM.purchaseDate;

            _garageRepository.update(userVehicle);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var garage = await _garageRepository.GetByIdAsync(id);
            if (garage == null) return View("Error");
            return RedirectToAction("Index");
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteGarage(int id)
        {
            var garage = await _garageRepository.GetByIdAsync(id);
            if (garage == null) return View("Error");
            _garageRepository.delete(garage);
            return RedirectToAction("Index");
        }
    }
}
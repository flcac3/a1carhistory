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
    }
}
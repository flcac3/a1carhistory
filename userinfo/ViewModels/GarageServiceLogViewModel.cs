using userinfo.Models;

namespace userinfo.ViewModels
{
    public class GarageServiceLogViewModel
    {
        public Garage Vehicle { get; set; }
        public IEnumerable<Servicelog> ServiceLogs { get; set; }
    }
}
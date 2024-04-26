using userinfo.Models;

namespace userinfo.ViewModels
{
    public class EditServiceLogViewModel
    {
        public int servicelogId { get; set; } // Service Log ID
        public DateTime date { get; set; } // Date
        public string mileageIn { get; set; } // Mileage In
        public string mileageOut { get; set; } // Mileage Out
        public string serviceNotes { get; set; } // Service Notes
        public int vehicleId { get; set; }

    }
}
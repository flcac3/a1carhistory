using userinfo.Models;

namespace userinfo.ViewModels
{
    public class EditGarageViewModel
    {
        public int vehicleId { get; set; }
        public string vin { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string? trim { get; set; }
        public string? modelYear { get; set; }
        public string? engineCylinders { get; set; }
        public string? displacementL { get; set; }
        public string? engineHP { get; set; }
        public string? driveType { get; set; }
        public string Mileage { get; set; }
        public string nickname { get; set; }
        public string purchaseDate { get; set; }
    }
}
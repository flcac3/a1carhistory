using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace userinfo.Models
{
    public class Garage
    {
        [Key]
        public int vehicleId { set; get; }

        [Required]
        public string vin { get; set; } // VIN

        [Required]
        public string Make { set; get; } // Make

        [Required]
        public string Model { set; get; } // Model

        public string? trim { get; set; } // Trim

        public string? modelYear { get; set; } // Model Year

        public string? engineCylinders { get; set; } // Engine Cylinders

        public string? displacementL { get; set; } // Displacement L

        public string? engineHP { get; set; } // Engine HP

        public string? driveType { get; set; } // Drive Type

        [Required]
        public string Mileage { set; get; } // Mileage

        [Required]
        public string purchaseDate { set; get; } // Purchase Date

        [Required]
        public string nickname { set; get; } // Nickname

        public string? carPhoto { set; get; } // Car Photo
        [ForeignKey("User")]
        public string? UserId { get; set; }
        public User User { get; set; }
    }
}

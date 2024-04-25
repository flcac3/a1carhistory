using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace userinfo.Models
{
    public class Garage
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int vehicleId { set; get; }

        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }

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
    }
}

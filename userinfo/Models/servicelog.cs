using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace userinfo.Models
{
    public class Servicelog
    {
        [Key]
        public int servicelogId { get; set; } // Service Log ID

        [Required]
        public DateTime date { get; set; } // Date

        [Required]
        public string mileageIn { get; set; } // Mileage In

        [Required]
        public string mileageOut { get; set; } // Mileage Out

        public string serviceNotes { get; set; } // Service Notes

        [ForeignKey("vehicle")]
        public int vehicleId { get; set; } // Vehicle ID
        [ForeignKey("User")]
        public string? UserId { get; set; }
        public User User { get; set; }

    }
}
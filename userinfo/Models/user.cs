using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace userinfo.Models
{

    public class User : IdentityUser
    {
        public ICollection<Garage> Garages { get; set; }
        public ICollection<Servicelog> Servicelogs { get; set; }
    }
}
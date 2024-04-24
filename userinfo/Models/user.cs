using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class User
 {
    [Key]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UserId { set; get; }
    [Required]
    public string UserName { set; get; }
    [Required]   
    public string Password { set; get; }
    }

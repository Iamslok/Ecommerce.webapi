using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace demo.webapi.demo.Models
{
    [Table("UserProfile")]
    public class UserProfile
    {
        [Key]
        public int PkUser { get; set; }
        public string Name { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
    }
}

using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtStoreShop.Models
{
    public class User : IdentityUser
    {
        [Key]
        
        public string Login { get; set; }
        public int RoleId { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public int Year { get; set; }
        
    }
}

using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WebPortal.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Key]
        public override string Id { get => base.Id; set => base.Id = value; }
        public string  FullName { get; set; }

        public ICollection<Order>? order { get; set; }



    }
}

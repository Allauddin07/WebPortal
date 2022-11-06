using System.ComponentModel.DataAnnotations;

namespace WebPortal.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }


        public string Status { get; set; }

        public string Id { get; set; }
        public ApplicationUser users { get; set; }

        public ICollection<Course> course { get; set; }
    }
}

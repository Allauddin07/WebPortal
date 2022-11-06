using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace WebPortal.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; } 
        public string Name { get; set; }

        public string  Price { get; set; }

        public int? OrderId   { get; set; }
        public Order?  order { get; set; }
    }
}

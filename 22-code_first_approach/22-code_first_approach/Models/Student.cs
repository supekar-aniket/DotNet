using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _22_code_first_approach.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Gender {get; set; }

        [Required]
        public int? Age { get; set; }

        [Required]
        public int? Marks { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace _35_CRUD_using_web_API_34.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Standard { get; set; }

        [Required]
        public int Marks { get; set; }

        [Required]
        public string Address { get; set; }
    }

}
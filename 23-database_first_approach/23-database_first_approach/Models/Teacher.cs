using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _23_database_first_approach.Models;

public partial class Teacher
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // 👈 tells EF not to insert Id manually
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = null!;

    [Required]
    public string Subject { get; set; } = null!;

    [Required]
    public int Salary { get; set; }
}
    
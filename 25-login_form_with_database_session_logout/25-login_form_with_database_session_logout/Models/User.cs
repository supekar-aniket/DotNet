using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _25_login_form_with_database_session_logout.Models;

public partial class User
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = null!;

    [Required]
    public string Gender { get; set; } = null!;

    [Required]
    public int? Age { get; set; }

    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;
}

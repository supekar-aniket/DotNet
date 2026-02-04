using System;
using System.Collections.Generic;

namespace _34_web_API_CURD_with_Database.Models;

public partial class Student
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Standard { get; set; } = null!;

    public int Marks { get; set; }

    public string Address { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace _27_binding_dropdownlist_with_database.Models;

public partial class Payment
{
    public int Id { get; set; }

    public string PaymentMethod { get; set; } = null!;
}

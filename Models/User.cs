using System;
using System.Collections.Generic;

namespace ex01.Models;

public partial class User
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<Bag> Bags { get; set; } = new List<Bag>();
}

using System;
using System.Collections.Generic;

namespace ex01.Models;

public partial class Product
{
    public int Id { get; set; } = 0!;

    public string Name { get; set; } = null!;

    public int Price { get; set; }

    public string ImageUrl { get; set; } = null!;

    public string? Colors { get; set; }

    public int Sale { get; set; }

    public string Desc { get; set; } = null!;

    public bool IsDeleted { get; set; }

    public virtual ICollection<Bag> Bags { get; set; } = new List<Bag>();

    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();
}

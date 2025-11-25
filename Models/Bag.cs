using System;
using System.Collections.Generic;

namespace ex01.Models;

public partial class Bag
{
    public int Id { get; set; }

    public string ProductId { get; set; } = null!;

    public string UserId { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}

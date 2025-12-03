using System;
using System.Collections.Generic;

namespace BookStore.Models;

public partial class Inventory
{
    public int StoreId { get; set; }

    public int Amount { get; set; }

    public string Isbn13 { get; set; } = null!;

    public DateTime LastUpdated { get; set; }

    public virtual Book Isbn13Navigation { get; set; } = null!;

    public virtual Store Store { get; set; } = null!;
}

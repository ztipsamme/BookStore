using System;
using System.Collections.Generic;

namespace BookStore.Models;

public partial class Store
{
    public int StoreId { get; set; }

    public string Name { get; set; } = null!;

    public string Adress { get; set; } = null!;

    public string City { get; set; } = null!;

    public string PostalCode { get; set; } = null!;

    public string Country { get; set; } = null!;

    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();

    public override string ToString()
    {
        return $"{StoreId}. {Name}";
    }
}

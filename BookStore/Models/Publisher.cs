using System;
using System.Collections.Generic;

namespace BookStore.Models;

public partial class Publisher
{
    public int PublisherId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();

    public override string ToString()
    {
        return $"{PublisherId}. {Name}";
    }
}

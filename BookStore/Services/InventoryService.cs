using System;
using BookStore.Models;

namespace BookStore.Services;

public class InventoryService
{
    private readonly BookstoreContext _db;

    public InventoryService(BookstoreContext db)
    {
        _db = db;
    }


}

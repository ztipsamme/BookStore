using System;
using BookStore.Models;

namespace BookStore.Services;

public class StoreService
{
    private readonly BookstoreContext _db;

    public StoreService(BookstoreContext db)
    {
        _db = db;
    }

    public List<Store> GetAllStores()
    {
        return _db.Stores.ToList();
    }

    public Store? GetStoreById(int storeId)
    {
        return _db.Stores.FirstOrDefault(s => s.StoreId == storeId);
    }

    public List<Inventory> GetStoreInventoryByStoreId(int storeId)
    {
        return _db.Inventories.Where(s => s.StoreId == storeId).ToList();
    }

    public void AddStore(Store store)
    {
        _db.Stores.Add(store);
        _db.SaveChanges();
    }

    public void DeleteStore(int storeId)
    {
        var store = _db.Stores.Find(storeId);
        if (store == null) return;

        _db.Stores.Remove(store);
        _db.SaveChanges();
    }
}

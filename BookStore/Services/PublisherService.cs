using System;
using BookStore.Models;

namespace BookStore.Services;

public class PublisherService
{
    private readonly BookstoreContext _db;

    public PublisherService(BookstoreContext db)
    {
        _db = db;
    }

    public List<Publisher> GetAllPublishers()
    {
        return _db.Publishers.ToList();
    }

    public Publisher? GetPublisherById(int publisherId)
    {
        return _db.Publishers.FirstOrDefault(a => a.PublisherId == publisherId);
    }

    public void AddPublisher(Publisher publisher)
    {
        _db.Publishers.Add(publisher);
        _db.SaveChanges();
    }

    public void DeletePublisher(int publisherId)
    {
        var publisher = _db.Publishers.Find(publisherId);
        if (publisher == null) return;

        _db.Publishers.Remove(publisher);
        _db.SaveChanges();
    }

}

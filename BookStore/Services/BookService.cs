using System;
using BookStore.Models;

namespace BookStore.Services;

public class BookService
{
    private readonly BookstoreContext _db;

    public BookService(BookstoreContext db)
    {
        _db = db;
    }

    public List<Book> GetAllBooks()
    {
        return _db.Books.ToList();
    }

    public Book? GetBookByIsbn(string isbn)
    {
        return _db.Books.FirstOrDefault(b => b.Isbn13 == isbn);
    }

    public void AddBook(Book book)
    {
        _db.Books.Add(book);
        _db.SaveChanges();
    }

    public void UpdateBook(Book book)
    {
        _db.Books.Update(book);
        _db.SaveChanges();
    }

    public void DeleteBook(string isbn)
    {
        var book = _db.Books.Find(isbn);
        if (book == null) return;

        _db.Books.Remove(book);
        _db.SaveChanges();
    }
}

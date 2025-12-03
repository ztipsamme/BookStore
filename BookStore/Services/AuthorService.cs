using System;
using BookStore.Models;

namespace BookStore.Services;

public class AuthorService
{
    private readonly BookstoreContext _db;

    public AuthorService(BookstoreContext db)
    {
        _db = db;
    }

    public List<Author> GetAllAuthors()
    {
        return _db.Authors.ToList();
    }

    public Author? GetAuthorById(int authorId)
    {
        return _db.Authors.FirstOrDefault(a => a.AuthorId == authorId);
    }

    public List<Author> GetMatchingAuthors(string fullName)
    {
        return _db.Authors
            .Where(a =>
                (a.FirstName + " " + a.LastName)
                .ToLower()
                .Contains(fullName.ToLower()))
            .ToList();
    }


    public void AddAuthor(Author author)
    {
        _db.Authors.Add(author);
        _db.SaveChanges();
    }

    public void DeleteAuthor(int authorId)
    {
        var author = _db.Authors.Find(authorId);
        if (author == null) return;

        _db.Authors.Remove(author);
        _db.SaveChanges();
    }
}

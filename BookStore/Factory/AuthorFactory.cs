using System;
using BookStore.Models;
using BookStore.Services;

namespace BookStore.Factory;

public class AuthorFactory
{
    private readonly AuthorService _authors;

    public AuthorFactory(AuthorService authors)
    {
        _authors = authors;
    }

    public Author CreateAuthor()
    {
        Console.WriteLine("--- Add new author ---");
        var book = new Book();

        Console.Write("FirstName: ");
        string firstName = Console.ReadLine() ?? "";

        Console.Write("LastName: ");
        string lastName = Console.ReadLine() ?? "";

        Console.Write("Birthday: ");
        if (DateOnly.TryParse(Console.ReadLine(), out var birthday))
            _ = birthday;

        var author = new Author();
        author.FirstName = firstName;
        author.LastName = lastName;
        author.Birthday = birthday;

        return author;
    }
}

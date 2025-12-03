using System;
using BookStore.Factory;
using BookStore.Models;
using BookStore.Services;
using BookStore.Ui;

namespace BookStore.Menus;

public class MainMenu
{
    private readonly BookService _books;
    private readonly AuthorService _authors;
    private readonly PublisherService _publishers;
    private readonly StoreService _stores;
    private readonly AuthorFactory _authorFactory;
    private readonly PublisherFactory _publisherFactory;

    private readonly GeneralUi _ui;
    private readonly BookUi _bookUi;

    public MainMenu(BookService books, AuthorService authors, PublisherService publishers, StoreService stores, GeneralUi ui)
    {
        _books = books;
        _authors = authors;
        _publishers = publishers;
        _stores = stores;
        _ui = ui;
        _bookUi = new BookUi(authors);
        _authorFactory = new AuthorFactory(authors);
        _publisherFactory = new PublisherFactory(publishers);
    }

    public void Show()
    {
        Console.WriteLine("=== Bookstore Menu ===\n");

        List<(string name, Action method)> menu = new()
        {
            ("Show all books", ListAllBooks),
            ("Show all authors", ListAllAuthors),
            ("Store inventory", ShowStoreInventory),
            // ("Show all publishers", ListAllPublishers),
            // ("Add book", AddBook),
            // ("Edit book", EditBook),
            // ("Move book", MoveBook),
            // ("Delete book", DeleteBook),
            // ("Add author", AddAuthor),
            // ("Edit author", EditAuthor),
            // ("Delete author", DeleteAuthor),
            // ("Add publisher", AddPublisher),
            // ("Edit publisher", EditPublisher),
            // ("Delete publisher", DeletePublisher),
            ("Exit",()=> {}),
        };

        for (int i = 0; i < menu.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {menu[i].name}");
        }

        Console.Write("Choice: ");
        var choice = Console.ReadLine();

        if (int.TryParse(choice, out int num) && num < 0 || num > menu.Count)
        {
            Console.WriteLine("Invalid choice");
        }
        else menu[num - 1].method();

        _ui.PressToContinue();
    }

    public void ListAllBooks()
    {
        Console.WriteLine("\n=== All books ===\n");
        var books = _books.GetAllBooks();
        foreach (var book in books)
        {
            Console.WriteLine(book.ToString());
        }
    }

    public void ListAllAuthors()
    {
        Console.WriteLine("\n=== All authors ===\n");
        var authors = _authors.GetAllAuthors();
        foreach (var author in authors)
        {
            Console.WriteLine($"{author.ToString()} | B-day: {author.Birthday} | Á books: {author.Books.Count}");
        }
    }

    public void ShowStoreInventory()
    {
        Console.WriteLine("\n=== Store Inventory ===\n");
        Console.WriteLine("\nSelect a store to check out it's inventory\n");

        var stores = _stores.GetAllStores();

        if (stores.Count == 0)
        {
            System.Console.WriteLine("No stores found");
            _ui.PressToContinue();
        }

        for (int i = 0; i < stores.Count; i++)
        {
            Console.WriteLine(stores[i].ToString());
        }

        System.Console.WriteLine("b. back");

        Console.Write("\nChoice: ");
        var choice = Console.ReadLine();

        if (int.TryParse(choice, out int num) && num < 0 || num > stores.Count)
        {
            Console.WriteLine("Invalid choice");
        }
        else if (choice.ToLower() == "b") return;
        else
        {
            System.Console.WriteLine($"\n--- {stores[num - 1].Name}'s inventory ---");
            var booksInInventory = _stores.GetStoreInventoryByStoreId(num - 1);

            if (booksInInventory.Count == 0)
            {
                System.Console.WriteLine("/nInventory is empty");
                return;
            }

            for (int i = 0; i < booksInInventory.Count; i++)
            {
                var book = _books.GetBookByIsbn(booksInInventory[i].Isbn13);
                System.Console.WriteLine(book.ToString());
            }
        }
    }

    public void AddBook()
    {
        Console.WriteLine("=== Add book ===");
        var book = new Book();

        Console.Write("Isbn13: ");
        string isbn13 = Console.ReadLine() ?? "";

        Console.Write("Title: ");
        string title = Console.ReadLine() ?? "";

        Console.Write("Language: ");
        string language = Console.ReadLine() ?? "";

        Console.Write("Price: ");
        if (decimal.TryParse(Console.ReadLine(), out var price))
            _ = price;

        Console.Write("Published: ");
        if (DateOnly.TryParse(Console.ReadLine(), out var published))
            _ = published;

        Console.Write("Author: ");
        Author? author = _bookUi.SelectOption(_authors.GetAllAuthors(), "Author", _authorFactory.CreateAuthor, _authors.GetAuthorById);
        Console.WriteLine(author);

        Console.Write("Publisher: ");
        Publisher? publisher = _bookUi.SelectOption(_publishers.GetAllPublishers(), "Publisher", _publisherFactory.CreatePublisher, _publishers.GetPublisherById);
        Console.WriteLine(publisher);
    }

    private void DeleteBook()
    {

    }

    private void EditBook()
    {

    }

    private void MoveBook()
    {

    }

    private void AddAuthor()
    {

    }
    private void EditAuthor()
    {

    }
    private void DeleteAuthor()
    {

    }

    private void AddPublisher()
    {

    }
    private void EditPublisher()
    {

    }
    private void DeletePublisher()
    {

    }

}

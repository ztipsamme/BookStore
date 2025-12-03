using BookStore.Menus;
using BookStore.Models;
using BookStore.Services;
using BookStore.Ui;


using var db = new BookstoreContext();

var bookService = new BookService(db);
var authorService = new AuthorService(db);
var publisherService = new PublisherService(db);
var storeService = new StoreService(db);
var ui = new GeneralUi();

var bookMenu = new MainMenu(bookService, authorService, publisherService, storeService, ui);

bool run = true;

while (run)
{
    Console.Clear();
    bookMenu.Show();
}
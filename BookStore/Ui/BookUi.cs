using System;
using BookStore.Factory;
using BookStore.Models;
using BookStore.Services;

namespace BookStore.Ui;

public class BookUi
{
    private readonly AuthorService _authors;
    private readonly GeneralUi _ui;

    public BookUi(AuthorService authors)
    {
        _authors = authors;
        _ui = new GeneralUi();
    }

    private void ShowOptions<T>(List<T> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            var item = list[i];
            Console.WriteLine(item.ToString());
        }
    }

    public T? SelectOption<T>(List<T> list, string key, Func<T> factoryMethod, Func<int, T?> getByIdMethod)
    {
        Console.WriteLine($"\n[add new]. Add new {key}");

        ShowOptions(list);

        T? selected = default;

        do
        {
            Console.Write("\nChoice: ");
            string choice = Console.ReadLine() ?? "";

            if (choice.ToLower() == "add new")
            {
                selected = factoryMethod();
            }
            else if (int.TryParse(choice, out var id))
            {
                selected = getByIdMethod(id);
            }
            else Console.WriteLine("Invalid choice");
        } while (selected == null);

        return selected;
    }

}

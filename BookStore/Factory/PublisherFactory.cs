using System;
using BookStore.Models;
using BookStore.Services;

namespace BookStore.Factory;

public class PublisherFactory
{
    private readonly PublisherService _publishers;

    public PublisherFactory(PublisherService publishers)
    {
        _publishers = publishers;
    }

    public Publisher CreatePublisher()
    {
        Console.WriteLine("--- Add new publisher ---");
        var book = new Book();

        Console.Write("Name: ");
        string name = Console.ReadLine() ?? "";

        var publisher = new Publisher();
        publisher.Name = name;

        return publisher;
    }
}

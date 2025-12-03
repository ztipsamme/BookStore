using System;
using System.Globalization;
using System.Security.Principal;
using BookStore.Models;

namespace BookStore.Ui;

public class GeneralUi
{
    public void PressToContinue()
    {
        Console.Write("\nPress any key to continue...");
        Console.ReadKey();
    }

    public void ClearLine()
    {
        int width = Console.WindowWidth;
        Console.Write(new string(' ', width));
    }

    public void ClearSuggestions()
    {
        int row = Console.GetCursorPosition().Top;

        for (int i = 0; i < 6 + 1; i++)
        {
            Console.SetCursorPosition(0, row + i);
            ClearLine();
        }

        Console.SetCursorPosition(0, row);
    }

}
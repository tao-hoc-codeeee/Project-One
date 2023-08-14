using System;

class Program
{
    static void Main(string[] args)
    {
        Console.BackgroundColor = ConsoleColor.DarkBlue;
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Clear();
        MenuLoginActivity menuLoginActivity = new MenuLoginActivity();
        menuLoginActivity.MenuLogin();
    }
}



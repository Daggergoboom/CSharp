using Business.Factories;
using Business.Interfaces;

namespace Presentation_ConsoleApp.Dialogs;

public class MenuDialogs
{
    private readonly iUserService _userService;

    public MenuDialogs(iUserService userService)
    {
        _userService = userService;
    }
    // Här har jag använt ChatGPT för att hjälpa mig konvertera om koden eftersom jag råkade göra kompressionen fel. (från userservice till _userservice)
    public void MainMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("-- MENU OPTIONS --");
            Console.WriteLine("1. Register User");
            Console.WriteLine("2. List Users");
            Console.WriteLine();
            Console.Write("Selection Option: ");
            var option = Console.ReadLine()!;

            switch (option)
            {
                case "1":
                    AddUserOption();
                    break;
                case "2":
                    ViewAllUsersOption();
                    break;
            }
        }
    }

    public void AddUserOption()
    {
        var form = UserFactory.Create();
        Console.Clear();
        Console.WriteLine("-- NEW USER --");
        Console.Write("First Name: ");
        form.FirstName = Console.ReadLine()!;
        Console.Write("Last Name: ");
        form.LastName = Console.ReadLine()!;
        Console.Write("Email: ");
        form.Email = Console.ReadLine()!;
        Console.Write("PhoneNumber: ");
        form.PhoneNumber = Console.ReadLine()!;
        Console.Write("Address: ");
        form.Address = Console.ReadLine()!;
        Console.Write("Postal Code: ");
        form.PostalCode = Console.ReadLine()!;
        Console.Write("City: ");
        form.City = Console.ReadLine()!;
        Console.WriteLine();

        var result = _userService.Save(form);
        if (result)
            Console.Write("User was created successfully.");
        else
            Console.Write("User was not created.");

        Console.ReadKey();
    }

    public void ViewAllUsersOption()
    {
        Console.Clear();
        Console.WriteLine("-- VIEW ALL USERS --");

        var users = _userService.GetAll();
        foreach (var user in users)
        {
            Console.WriteLine($"{user.FirstName} {user.LastName} - {user.Email} - {user.PhoneNumber} - {user.Address} - {user.PostalCode} - {user.City}");
        }
        Console.ReadKey();
    }
}
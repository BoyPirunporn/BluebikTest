using System;
using BluebikTest.Controllers;
using BluebikTest.Interfaces;
using BluebikTest.Services;
using Microsoft.Extensions.DependencyInjection;
class Program
{
    private readonly ModuleController moduleController;

    public Program(ModuleController moduleController)
    {
        this.moduleController = moduleController;
    }


    public static void Main(string[] args)
    {
        var serviceProvider = new ServiceCollection()
            .AddSingleton<ITextProcessingService, TextProcessingService>()
            .AddSingleton<INumberConvertsionService, NumberConvertsionService>()
            .AddSingleton<INumberPairService, NumberPairService>()
            .AddSingleton<ModuleController>()
            .AddSingleton<Program>()
            .BuildServiceProvider();

        var program = serviceProvider.GetRequiredService<Program>();
        program.Run();
    }


    public void Run()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Main Menu ===");
            Console.WriteLine("1. Find most common word");
            Console.WriteLine("2. Convert Roman to Integer");
            Console.WriteLine("3. Find pari with target");
            Console.WriteLine("0. Exit program");
            Console.Write("Select menu: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    moduleController.FindMostCommonWord();
                    break;
                case "2":
                    moduleController.ConvertRomanToInteger();
                    break;
                case "3":
                    moduleController.FindPairs();
                    break;
                case "0":
                    Console.WriteLine("Goodbye! Exiting now...");
                    return;
                default:
                    Console.WriteLine("Invalid selection. Please choose a valid option from the menu.");
                    Console.Write("Press Enter to continue...");
                    Console.ReadLine();
                    break;

            }
        }
    }

}
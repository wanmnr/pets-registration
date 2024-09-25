using Microsoft.Extensions.DependencyInjection;
using PetFriendsApp.Helpers;
using PetFriendsApp.Services;
using PetFriendsApp.Repository;

namespace PetFriendsApp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Create a service collection
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IAnimalRepository, PetRepository>() // Register repository
                .AddSingleton<PetService>() // Register PetService
                .BuildServiceProvider(); // Build the service provider

            // Resolve dependencies
            var petService = serviceProvider.GetRequiredService<PetService>();
            var animalRepository = serviceProvider.GetRequiredService<IAnimalRepository>();

            // Create the data seeder and inject the repository
            var dataSeeder = new DataSeeder(animalRepository);

            // Seed the initial data
            dataSeeder.Seed();

            bool continueProgram = true;

            while (continueProgram)
            {
                DisplayMainMenu();
                string? menuSelection = InputHelper.GetUserInput("Enter your selection number (or type Exit to exit the program)").ToLower();

                if (menuSelection == "exit")
                {
                    continueProgram = false;
                    break;
                }

                switch (menuSelection)
                {
                    case "1":
                        petService.DisplayAllPets();
                        break;
                    case "2":
                        petService.AddNewPet();
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please select a valid menu option.");
                        break;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
        }
    }

    // Method to display the main menu
    static void DisplayMainMenu()
    {
        Console.Clear();
        Console.WriteLine("Welcome to the PetFriends app. Your main menu options are:");
        Console.WriteLine(" 1. List all of our current pet information");
        Console.WriteLine(" 2. Add a new animal friend to the ourAnimals array");
        Console.WriteLine(" 3. Ensure animal ages and physical descriptions are complete");
        Console.WriteLine(" 4. Ensure animal nicknames and personality descriptions are complete");
        Console.WriteLine(" 5. Edit an animal's age");
        Console.WriteLine(" 6. Edit an animal's personality description");
        Console.WriteLine(" 7. Display all cats with a specified characteristic");
        Console.WriteLine(" 8. Display all dogs with a specified characteristic");
        Console.WriteLine();
    }
}
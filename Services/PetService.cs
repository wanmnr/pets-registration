using PetFriendsApp.Helpers;
using PetFriendsApp.Repository;

namespace PetFriendsApp.Services
{
    public class PetService
    {
        private readonly IAnimalRepository _animalRepository;

        public PetService(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        private const int maxPets = 5;
        private readonly string[,] ourAnimals = new string[maxPets, 6];

        public void DisplayAllPets()
        {
            var allAnimals = _animalRepository.GetAllAnimals();
            foreach (var animal in allAnimals)
            {
                Console.WriteLine($"ID #: {animal.Id}");
                Console.WriteLine($"Species: {animal.Species}");
                Console.WriteLine($"Age: {animal.Age}");
                Console.WriteLine($"Nickname: {animal.Nickname}");
                Console.WriteLine($"Physical Description: {animal.PhysicalDescription}");
                Console.WriteLine($"Personality Description: {animal.PersonalityDescription}");
                Console.WriteLine();
            }
            Console.WriteLine("\nPress the Enter key to continue.");
            Console.ReadLine();
        }

        public void AddNewPet()
        {
            string anotherPet = "y";
            int petCount = GetCurrentPetCount();

            if (petCount >= maxPets)
            {
                Console.WriteLine("We have reached our limit on the number of pets.");
                Console.ReadLine();
                return;
            }

            while (anotherPet == "y" && petCount < maxPets)
            {
                // Get species (cat or dog) - required field
                string animalSpecies;
                do
                {
                    animalSpecies = InputHelper.GetValidatedInput("Enter 'dog' or 'cat' to begin a new entry", IsValidSpecies);
                } while (string.IsNullOrEmpty(animalSpecies));

                // Generate animal ID
                string animalID = GenerateAnimalID(animalSpecies, petCount);

                // Get the pet's age; can be ? at initial entry.
                string animalAge;
                do
                {
                    animalAge = InputHelper.GetValidatedInput("Enter the pet's age or enter ? if unknown", IsValidAge);
                } while (string.IsNullOrEmpty(animalAge));

                // Get a physical description - can be blank.
                string animalPhysicalDescription = InputHelper.GetOptionalInput("Enter a physical description of the pet (size, color, gender, weight, housebroken)", "tbd");

                // Get a personality description - can be blank.
                string animalPersonalityDescription = InputHelper.GetOptionalInput("Enter a description of the pet's personality (likes or dislikes, tricks, energy level)", "tbd");

                // Get the pet's nickname - can be blank.
                string animalNickname = InputHelper.GetOptionalInput("Enter a nickname for the pet", "tbd");

                // Save pet information
                SavePetInfo(petCount, animalID, animalSpecies, animalAge, animalPhysicalDescription, animalPersonalityDescription, animalNickname);
                petCount++;

                // Check if we can add another pet
                if (petCount < maxPets)
                {
                    anotherPet = InputHelper.GetUserInput("Do you want to enter info for another pet (y/n)").ToLower();
                }
            }

            if (petCount >= maxPets)
            {
                Console.WriteLine("We have reached our limit on the number of pets that we can manage.");
                Console.WriteLine("Press the Enter key to continue.");
                Console.ReadLine();
            }
        }



        private int GetCurrentPetCount()
        {
            int count = 0;
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] != "ID #: ")
                {
                    count++;
                }
            }
            return count;
        }

        private bool IsValidSpecies(string input) => input == "dog" || input == "cat";

        private bool IsValidAge(string input) => input == "?" || int.TryParse(input, out _);

        private string GenerateAnimalID(string species, int count) => species.Substring(0, 1).ToUpper() + (count + 1);

        private void SavePetInfo(int index, string id, string species, string age, string physicalDescription, string personality, string nickname)
        {
            ourAnimals[index, 0] = "ID #: " + id;
            ourAnimals[index, 1] = "Species: " + species;
            ourAnimals[index, 2] = "Age: " + age;
            ourAnimals[index, 3] = "Nickname: " + nickname;
            ourAnimals[index, 4] = "Physical description: " + physicalDescription;
            ourAnimals[index, 5] = "Personality: " + personality;
        }
    }
}

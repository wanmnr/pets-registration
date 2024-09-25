using System;
using PetFriendsApp.Entities;
using PetFriendsApp.Repository;

public class DataSeeder
{
    private readonly IAnimalRepository _animalRepository;

    // Constructor to inject the repository dependency
    public DataSeeder(IAnimalRepository animalRepository)
    {
        _animalRepository = animalRepository;
    }

    // Seed method to populate data
    public void Seed()
    {
        _animalRepository.AddAnimal(new Pet("d1", AnimalSpecies.Dog, 2, 
            "medium-sized cream colored female golden retriever weighing about 65 pounds. housebroken.", 
            "loves to have her belly rubbed and likes to chase her tail.", 
            "Lola"));

        _animalRepository.AddAnimal(new Pet("d2", AnimalSpecies.Dog, 9,
            "large reddish-brown male golden retriever weighing about 85 pounds. housebroken.", 
            "loves to have his ears rubbed when he greets you at the door.", 
            "Loki"));

        _animalRepository.AddAnimal(new Pet("c3", AnimalSpecies.Cat, 1, 
            "small white female weighing about 8 pounds. litter box trained.", 
            "friendly", 
            "Puss"));

        Console.WriteLine("Data seeding completed.");
    }
}

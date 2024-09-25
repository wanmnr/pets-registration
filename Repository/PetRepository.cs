using PetFriendsApp.Entities;

namespace PetFriendsApp.Repository;
public class PetRepository : IAnimalRepository
{
    private readonly List<IAnimal> _animals = new();

    public void AddAnimal(IAnimal animal)
    {
        _animals.Add(animal);
    }

    public IEnumerable<IAnimal> GetAllAnimals()
    {
        return _animals;
    }
}
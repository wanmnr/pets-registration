using PetFriendsApp.Entities;

namespace PetFriendsApp.Repository;
public interface IAnimalRepository
{
    void AddAnimal(IAnimal animal);
    IEnumerable<IAnimal> GetAllAnimals();
}
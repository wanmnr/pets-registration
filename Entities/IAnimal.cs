namespace PetFriendsApp.Entities;
public interface IAnimal
{
    string Id { get; set; }
    AnimalSpecies Species { get; set; }
    int? Age { get; set; }
    string Nickname { get; set; }
    string PhysicalDescription { get; set; }
    string PersonalityDescription { get; set; }
}
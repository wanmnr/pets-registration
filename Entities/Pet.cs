namespace PetFriendsApp.Entities;
public class Pet : IAnimal
{
    public string Id { get; set; }
    public AnimalSpecies Species { get; set; }
    public int? Age { get; set; }
    public string Nickname { get; set; }
    public string PhysicalDescription { get; set; }
    public string PersonalityDescription { get; set; }

    public Pet(string id, AnimalSpecies species, int age, string nickname, string physicalDescription, string personalityDescription)
    {
        Id = id;
        Species = species;
        Age = age;
        Nickname = nickname;
        PhysicalDescription = physicalDescription;
        PersonalityDescription = personalityDescription;
    }
}
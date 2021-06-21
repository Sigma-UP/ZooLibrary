using System.Collections.Generic;
using ZooLib.Animals;
namespace ZooLib.Employees
{
    public interface IEmployee
    {
        string FirstName { get; }

        string LastName { get; }

        //int ID { get; } //additional shit

        List<string> AnimalExperiences { get; }

        bool HasAnimalExperience(Animal animal);
        void AddAnimalExperience(Animal animal);

    }
}

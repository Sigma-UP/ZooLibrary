using ZooLib.Console;
using System.Collections.Generic;
using ZooLib.Animals;

namespace ZooLib.Employees
{
    public class Veterinarian : IEmployee
    {
        private readonly IConsole _console;
        public Veterinarian(string firstName, string lastName, List<string> animalExperiences, IConsole console = null)
        {
            FirstName = firstName;
            LastName = lastName;
            AnimalExperiences = animalExperiences;
            _console = console;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public List<string> AnimalExperiences { get; private set; }

        public void AddAnimalExperience(Animal animal)
        {
            if (!HasAnimalExperience(animal))
                AnimalExperiences.Add(animal.GetType().Name);
        }
        public bool HasAnimalExperience(Animal animal) => AnimalExperiences.Contains(animal.GetType().Name);

        public bool HealAnimal(Animal animal)
        {
            if (HasAnimalExperience(animal) && animal.IsSick == true)
            {
                animal.IsSick = false;
                _console?.WriteLine($"Veterenarian {FirstName} {LastName} cured the {animal.GetType().Name}, ID {animal.ID}.");
            }
            else
                _console?.WriteLine($"{animal.GetType().Name} is healthy.");
            return !animal.IsSick;
        }

    }
}

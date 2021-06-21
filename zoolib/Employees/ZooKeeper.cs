using System;
using System.Collections.Generic;

using ZooLib.Console;
using ZooLib.Animals;
using ZooLib.Foods;
namespace ZooLib.Employees
{
    public class ZooKeeper : IEmployee
    {
        private readonly IConsole _console;
        public ZooKeeper(string firstName, string lastName, List<string> animalExperiences, IConsole console = null)
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
            if(!HasAnimalExperience(animal))
                AnimalExperiences.Add(animal.GetType().Name);
        }
        public bool HasAnimalExperience(Animal animal) => AnimalExperiences.Contains(animal.GetType().Name);

        public bool FeedAnimal(Animal animal) {
            if (!HasAnimalExperience(animal))
            {
                return false;
            }

            string foodClassName = $"ZooLib.Foods.{animal.FavoriteFood[0]}";
            Type type = Type.GetType(foodClassName);
            Food food = Activator.CreateInstance(type) as Food;
            animal.Feed(food, this);
            _console?.WriteLine($"Zookeeper: Zookeeper {FirstName} {LastName} fed {animal.GetType().Name} ID {animal.ID}.");

            return true;
        }

    }
}

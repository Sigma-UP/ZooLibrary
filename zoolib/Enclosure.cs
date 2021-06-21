using System.Collections.Generic;
using ZooLib.Console;
using ZooLib.Exceptions;
using ZooLib.Animals;
namespace ZooLib
{
    public class Enclosure
    {
        public Enclosure(string name, List<Animal> animals, Zoo parentZoo, int squareFeet, IConsole console = null)
        {
            Name = name;
            Animals = animals;
            ParentZoo = parentZoo;
            SquareFeet = squareFeet;
            _console = console;
        }
        private readonly IConsole _console;
        public string Name { get; private set; }
        public List<Animal> Animals { get; private set; }
        public Zoo ParentZoo { get; private set; }
        public int SquareFeet { get; private set; } // changed to uint

        public int AvailableSpace()
        {
            int UnavailableSpace = 0;
            foreach (Animal animal in Animals)
                UnavailableSpace += animal.RequiredSpaceSqFt;
            return SquareFeet - UnavailableSpace;
        } // addition to origin diagram

        public void AddAnimals(Animal animal)
        {
            if (animal.RequiredSpaceSqFt > AvailableSpace())
            {
                _console?.WriteLine($"Enclosure {Name} Addition: Addition failed. {animal.GetType().Name} need more space.");
                throw new NoAvailableSpaceException($"Enclosure {Name}: Addition failed. " +
                    $"{animal.GetType().Name} need more space.");
            }
            foreach (Animal animalInEnclosure in Animals)
                if (!animalInEnclosure.IsFriendlyWith(animal)) 
                {
                    _console?.WriteLine($"Enclosure {Name} Addition: Addition failed. {animal.GetType().Name} is not friendly with {animalInEnclosure.GetType().Name}.");
                    throw new NotFriendlyAnimalException($"Enclosure {Name}: Addition failed. " +
                        $"{animal.GetType().Name} is not friendly with {animalInEnclosure.GetType().Name}.");
                }
            //_console
            Animals.Add(animal);
        }
    }
}

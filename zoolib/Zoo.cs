using System.Collections.Generic;
using ZooLib.Console;
using ZooLib.Employees.Validators;
using ZooLib.Employees;
using ZooLib.Animals;
using ZooLib.Exceptions;
using System.Linq;
using System;

namespace ZooLib
{
    public class Zoo
    {
        private readonly IConsole _console;

        public Zoo(string location, IConsole console = null)
        {
            Location = location;
            _console = console;
        }

        public List<Enclosure> Enclosures { get; private set; } = new List<Enclosure>();
        public List<IEmployee> Employees { get; private set; } = new List<IEmployee>();
        public string Location { get; private set; }

        public void AddEnclosure(string name, int squareFeet) //additional: Enclosure type changed to void, squareFeet`s type changed to uint instead of int
        {
            foreach (Enclosure enc in Enclosures)
                if (name == enc.Name)
                {
                    _console?.WriteLine($"Enclosure Addition: Impossible to add the Enclosure {name} because an Enclosure with such name is already exists.");
                    throw new EnclosureIsAlreadyExistsException($"Enclosure Addition: Impossible to add the Enclosure { name } because an Enclosure with such name is already exists.");
                }
            _console?.WriteLine($"Enclosure Addition: New Enclosure {name} successfully added.");
            Enclosures.Add(new Enclosure(name, new List<Animal>(), this, squareFeet));
        }

        public Enclosure FindAvailableEnclosure(Animal animal)
        {
            foreach (Enclosure enclosure in Enclosures) // try to redo it, using Enclosure`s AddAnimal method
            {
                if (enclosure.Animals.Count == 0 && enclosure.AvailableSpace() > animal.RequiredSpaceSqFt)
                {
                    _console?.WriteLine($"Available Enclosure searching: The Enclosure for {animal.GetType().Name} ID:{animal.ID} is finded");
                    return enclosure;
                }
                foreach (Animal animalInEnclosure in enclosure.Animals)
                    if (animalInEnclosure.IsFriendlyWith(animal) && enclosure.AvailableSpace() <= animal.RequiredSpaceSqFt)
                    {
                        _console?.WriteLine($"Available Enclosure searching: The Enclosure for {animal.GetType().Name} ID:{animal.ID} is finded.");
                        return enclosure;
                    }
            }
            _console?.WriteLine($"Available Enclosure searching: The Enclosure for {animal.GetType().Name} ID:{animal.ID} is not finded.");
            return null;
        }

        public void HireEmployee(IEmployee employee)
        {
            if (HireValidatorProvider.GetHireValidator(employee).ValidateEmployee(employee, this) == null)
            {
                Employees.Add(employee);
                _console?.WriteLine($"Employee Addition: {employee.GetType().Name} {employee.FirstName} {employee.LastName} was successfully hired.");
            }
            else
                _console?.WriteLine($"Employee Addition: {employee.GetType().Name} {employee.FirstName} {employee.LastName} cant be hired.");
        }
        public void FeedAnimals(DateTime dateTime)
        {
            var dividedAnimals =
                DivideAnimalsBetweenEmployees("ZooKeeper", (animal) => animal.IsHungry(dateTime));

            foreach (var group in dividedAnimals)
            {
                foreach (var animal in group.Item2)
                {
                    (group.Item1 as ZooKeeper)?.FeedAnimal(animal);
                    _console?.WriteLine(
                        $"Feeding Animals {Location}: {animal.GetType().Name} ID {animal.ID} was fed by {group.Item1.FirstName} {group.Item1.LastName}.");
                }
            }
        }
        public void HealAnimals()
        {
            var dividedAnimals = DivideAnimalsBetweenEmployees("Veterinarian", (animal) => animal.IsSick);

            foreach (var group in dividedAnimals)
            {
                foreach (var animal in group.Item2)
                {
                    (group.Item1 as Veterinarian)?.HealAnimal(animal);
                    _console?.WriteLine(
                        $"Healing Animals {Location}: {animal.GetType().Name} ID {animal.ID} was healed by {group.Item1.FirstName} {group.Item1.LastName}.");
                }
            }
        }

        public List<(IEmployee, List<Animal>)> DivideAnimalsBetweenEmployees(string employeeType,
           Predicate<Animal> checkAnimal)
        {
            var employees = Employees.Where(e => e.GetType().Name == employeeType);

            var dividedAnimals = employees.Select((e) => (employee: e, animals: new List<Animal>())).ToList();

            bool noEmployeeWithAnimalExperience = false;

            foreach (var enclosure in Enclosures)
            {
                foreach (var animal in enclosure.Animals)
                {
                    if (checkAnimal(animal))
                    {
                        dividedAnimals = dividedAnimals.OrderBy(d => d.animals.Count()).ToList();
                        foreach (var item in dividedAnimals)
                        {
                            if (item.employee.HasAnimalExperience(animal))
                            {
                                item.animals.Add(animal);
                                break;
                            }
                            else
                            {
                                noEmployeeWithAnimalExperience = true;
                            }
                        }

                        if (noEmployeeWithAnimalExperience)
                        {
                            throw new UnknownAnimalException(
                                $"The zoo does not keep this type of animals - {animal.GetType().Name}.");
                        }
                    }
                }
            }

            return dividedAnimals.ToList();
        }

    }
}

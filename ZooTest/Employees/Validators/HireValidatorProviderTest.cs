using ZooLib;
using ZooLib.Animals;
using ZooLib.Animals.Birds;
using ZooLib.Animals.Mammals;
using ZooLib.Animals.Reptiles;
using ZooLib.Console;
using ZooLib.Employees;
using ZooLib.Employees.Validators;
using ZooLib.Employees.Validators.Errors;
using ZooLib.Exceptions;
using ZooLib.Foods;
using ZooLib.Medicines;
using System.Collections.Generic;
using Xunit;
using System;
namespace ZooTest.Employees
{
    public class HireValidatorProviderTest
    {
        [Fact]
        public void ShouldBeAbleToReturnVeterinarianHireValidator()
        {
            IEmployee empl = new Veterinarian("Name", "LName", null);
            Assert.Equal("VeterinarianHireValidator", HireValidatorProvider.GetHireValidator(empl).GetType().Name);
        }

        [Fact]
        public void ShouldBeAbleToReturnZooKeeperHireValidator()
        {
            IEmployee empl = new ZooKeeper("Name", "LName", null);
            Assert.Equal("ZooKeeperHireValidator", HireValidatorProvider.GetHireValidator(empl).GetType().Name);
        }

        [Fact]
        public void ShouldThrowAnExceptionWhenEmployeeHasWrongType()
        {
            IEmployee empl = new Paleontolog("A", "B", new List<string> { "Cat" });
            Assert.Throws<UnknownEmployeeTypeException>(() => HireValidatorProvider.GetHireValidator(empl));
        }

        class Paleontolog : IEmployee
        {
            public Paleontolog(string firstName, string lastName, List<string> animalExperiences)
            {
                FirstName = firstName;
                LastName = lastName;
                AnimalExperiences = animalExperiences;
            }

            public string FirstName { get; set; }

            public string LastName { get; set; }

            public List<string> AnimalExperiences { get; set; }

            public void AddAnimalExperience(Animal animal)
            {
                throw new NotImplementedException();
            }

            public bool HasAnimalExperience(Animal animal)
            {
                throw new NotImplementedException();
            }
        }

        [Fact]
        public void ShouldBeAbleToCreateLocalPaleontolog()
        {
            Paleontolog paleontolog = new Paleontolog("A", "B", new List<string> { "Cat" });

            Assert.Equal("A", paleontolog.FirstName);
            Assert.Equal("B", paleontolog.LastName);
            Assert.Equal("Cat", paleontolog.AnimalExperiences[0]);

            Assert.Throws<NotImplementedException>(() => paleontolog.AddAnimalExperience(new Lion(1)));
            Assert.Throws<NotImplementedException>(() => paleontolog.HasAnimalExperience(new Lion(1)));
        }
    }
}

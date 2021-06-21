using System.Collections.Generic;
using System;
using ZooLib.Employees;

using ZooLib.Animals.Mammals;
using ZooLib.Animals.Birds;
using Xunit;

namespace ZooTest.Employees
{
    public class VeterinarianTest
    {
        [Fact]
        public void ShouldBeAbleToCreateVeterinarian()
        {
            IEmployee employee = new Veterinarian("Anthony", "Hopkins", new List<string> { "Parrot", "Penguin" });
            Assert.Equal("Anthony", employee.FirstName);
            Assert.Equal("Hopkins", employee.LastName);
            Assert.Equal(new List<string> { "Parrot", "Penguin" }, employee.AnimalExperiences);
        }

        [Fact]
        public void ShouldBeAbletoAddAnimalExperiences()
        {
            IEmployee employee = new Veterinarian("Anthony", "Hopkins", new List<string>());
            employee.AddAnimalExperience(new Parrot(1));
            Assert.True(employee.HasAnimalExperience(new Parrot(1)));
        }

        [Fact]
        public void ShouldBeAbleToHealAnimal()
        {
            IEmployee employee = new Veterinarian("Anthony", "Hopkins", new List<string> { "Parrot" });
            Parrot parrot = new Parrot(1);
            parrot.IsSick = true;

            Assert.True(((Veterinarian)employee).HealAnimal(parrot));
            Assert.False(parrot.IsSick);
        }
        [Fact]
        public void ShouldBeUnableToHealAnimalWithoutExperience()
        {
            IEmployee employee = new Veterinarian("Anthony", "Hopkins", new List<string> { "Parrot" });
            Lion lion = new Lion(1);
            lion.IsSick = true;

            Assert.False(((Veterinarian)employee).HealAnimal(lion));
            Assert.True(lion.IsSick);
        }
    }
}

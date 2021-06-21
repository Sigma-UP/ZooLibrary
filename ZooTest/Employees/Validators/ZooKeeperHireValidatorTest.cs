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
namespace ZooTest.Employees.Validators
{
    public class ZooKeeperHireValidatorTest
    {
        [Fact]
        public void ShouldReturnNullIfEmployeeHasNeededExperience()
        {
            Zoo zoo = new Zoo("Denver");
            zoo.AddEnclosure("1", 2000);
            zoo.Enclosures[0].AddAnimals(new Lion(1));

            ZooKeeperHireValidator validator = new ZooKeeperHireValidator();
            IEmployee empl = new ZooKeeper("Name", "LName", new List<string> { "Lion" });
            Assert.Null(validator.ValidateEmployee(empl, zoo));
        }
        [Fact]
        public void ShouldThrowAnExceptionIfEmployeeDoesNotHaveNeededExperience()
        {
            Zoo zoo = new Zoo("Denver");
            zoo.AddEnclosure("1", 2000);
            zoo.Enclosures[0].AddAnimals(new Elephant(1));

            ZooKeeperHireValidator validator = new ZooKeeperHireValidator();
            IEmployee empl = new ZooKeeper("Name", "LName", new List<string> { "Lion" });
            Assert.Equal(new NoNeededAnimalExperienceError().GetType().Name, validator.ValidateEmployee(empl, zoo)[0].GetType().Name);
        }
    }
}

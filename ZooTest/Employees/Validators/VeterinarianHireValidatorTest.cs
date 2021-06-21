using ZooLib;
using ZooLib.Animals.Mammals;
using ZooLib.Employees;
using ZooLib.Employees.Validators;
using ZooLib.Employees.Validators.Errors;
using System.Collections.Generic;
using Xunit;

namespace ZooTest.Employees.Validators
{
    public class VeterinarianHireValidatorTest
    {
        [Fact]
        public void ShouldReturnNullIfEmployeeHasNeededExperience()
        {
            Zoo zoo = new Zoo("Denver");
            zoo.AddEnclosure("1", 2000);
            zoo.Enclosures[0].AddAnimals(new Lion(1));

            VeterinarianHireValidator validator = new VeterinarianHireValidator();
            IEmployee empl = new Veterinarian("Name", "LName", new List<string> { "Lion" });
            Assert.Null(validator.ValidateEmployee(empl, zoo));
        }
        [Fact]
        public void ShouldThrowAnExceptionIfEmployeeDoesNotHaveNeededExperience()
        {
            Zoo zoo = new Zoo("Denver");
            zoo.AddEnclosure("1", 2000);
            zoo.Enclosures[0].AddAnimals(new Elephant(1));

            VeterinarianHireValidator validator = new VeterinarianHireValidator();
            IEmployee empl = new Veterinarian("Name", "LName", new List<string> { "Lion" });
            Assert.Equal(new NoNeededAnimalExperienceError().GetType().Name, validator.ValidateEmployee(empl, zoo)[0].GetType().Name);
        }

    }
}

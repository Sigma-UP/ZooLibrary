using System.Collections.Generic;
using ZooLib.Employees.Validators.Errors;
using ZooLib.Animals;
namespace ZooLib.Employees.Validators
{
    public class ZooKeeperHireValidator : HireValidator, IHireValidator
    {
        public override List<ValidationError> ValidateEmployee(IEmployee employee, Zoo zoo)
        {
            List<ValidationError> validationErrors = new List<ValidationError>();
            try
            {
                foreach (Enclosure enclosure in zoo.Enclosures)                         // REFACTOR IT IMMEDIATELY AAAAAAAAAAAAAAAAHHH
                    foreach (Animal animal in enclosure.Animals)                        // REFACTOR IT IMMEDIATELY AAAAAAAAAAAAAAAAHHH
                        if (employee.AnimalExperiences.Contains(animal.GetType().Name)) // REFACTOR IT IMMEDIATELY AAAAAAAAAAAAAAAAHHH
                            return null;                                                // REFACTOR IT IMMEDIATELY AAAAAAAAAAAAAAAAHHH
                throw new Exceptions.NoNeededExperienceException("");
            }
            catch
            {
                validationErrors.Add(new NoNeededAnimalExperienceError());              // REFACTOR IT IMMEDIATELY AAAAAAAAAAAAAAAAHH
            }
            return validationErrors;
        }
    }
}

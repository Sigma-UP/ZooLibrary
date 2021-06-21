using System.Collections.Generic;
using ZooLib.Employees.Validators.Errors;
using ZooLib.Animals;
namespace ZooLib.Employees.Validators
{
    public abstract class HireValidator
    {
        public abstract List<ValidationError> ValidateEmployee(IEmployee employee, Zoo zoo);
           
    }
}

using System.Collections.Generic;
using ZooLib.Employees.Validators.Errors;
namespace ZooLib.Employees.Validators
{
    public interface IHireValidator
    {
        public List<ValidationError> ValidateEmployee(IEmployee employee, Zoo zoo);
    }
}

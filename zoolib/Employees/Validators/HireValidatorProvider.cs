using System;
using System.Collections.Generic;
using System.Text;
using ZooLib.Exceptions;
namespace ZooLib.Employees.Validators
{
    public class HireValidatorProvider
    {
        public static IHireValidator GetHireValidator(IEmployee employee)
        {
            if(employee.GetType().Name == "Veterinarian")
                return new VeterinarianHireValidator();
            if (employee.GetType().Name == "ZooKeeper")
                return new ZooKeeperHireValidator();
            throw new UnknownEmployeeTypeException($"Zoo doesnt have this type of employees.");
        }
    }
}

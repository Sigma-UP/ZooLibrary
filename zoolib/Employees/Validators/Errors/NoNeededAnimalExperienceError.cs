namespace ZooLib.Employees.Validators.Errors
{
    public class NoNeededAnimalExperienceError:ValidationError
    {
        public NoNeededAnimalExperienceError():base("The employee doesn`t have needed experience.", "AnimalExperiences"){}
    }
}

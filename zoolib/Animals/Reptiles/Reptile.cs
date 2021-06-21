using ZooLib.Console;
namespace ZooLib.Animals.Reptiles
{
    public abstract class Reptile : Animal
    {
        protected Reptile(IConsole console = null) : base(console)
        {
        }
    }
}

using ZooLib.Console;
namespace ZooLib.Animals.Mammals
{
    public abstract class Mammal : Animal
    {
        protected Mammal(IConsole console = null) : base(console)
        {
        }
    }
}

using ZooLib.Console;
namespace ZooLib.Animals.Birds
{
    public abstract class Bird : Animal
    {
        protected Bird(IConsole console = null) : base(console)
        {
        }
    }
}

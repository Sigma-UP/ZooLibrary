using ZooLib.Console;
using System.Collections.Generic;
namespace ZooLib.Animals.Birds
{
    public class Penguin : Bird
    {
        public Penguin(int id, List<int> feedSchedule = null, IConsole console = null) : base(console)
        {
            ID = id;
            FeedSchedule = feedSchedule ?? new List<int>() { 5, 16 };
        }
        public override int RequiredSpaceSqFt { get; } = 10;
        public override List<string> FavoriteFood { get; } = new List<string> { "Vegetable" };
        public List<string> FriendlyWith { get; } = new List<string> {
            "Penguin"
        };

        public override bool IsFriendlyWith(Animal animal)
        {
            return FriendlyWith.Contains(animal.GetType().Name);
        }
    }
}

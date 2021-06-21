using ZooLib.Console;
using System.Collections.Generic;

namespace ZooLib.Animals.Birds
{
    public class Parrot : Bird
    {
        public Parrot(int id, List<int> feedSchedule = null, IConsole console = null):base(console)
        {
            ID = id;
            FeedSchedule = feedSchedule ?? new List<int>() { 5, 16 };
        }
        public override int RequiredSpaceSqFt { get; } = 5;
        public override List<string> FavoriteFood { get; } = new List<string> { "Vegetable" };
        public List<string> FriendlyWith { get; } = new List<string> {
            "Parrot", "Bison",
            "Elephant", "Turtle"
        };

        public override bool IsFriendlyWith(Animal animal)
        {
            return FriendlyWith.Contains(animal.GetType().Name);
        }
    }
}

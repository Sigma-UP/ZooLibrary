using ZooLib.Console;
using System.Collections.Generic;
namespace ZooLib.Animals.Mammals
{
    public class Lion : Mammal
    {
        public Lion(int id, List<int> feedSchedule = null, IConsole console = null) : base(console)
        {
            ID = id;
            FeedSchedule = feedSchedule ?? new List<int>() { 5, 16 };
        }

        public override int RequiredSpaceSqFt { get; } = 1000;
        public override List<string> FavoriteFood { get; } = new List<string> { "Meat"};
        public List<string> FriendlyWith { get; } = new List<string>{ "Lion" };

        public override bool IsFriendlyWith(Animal animal)
        {
            return FriendlyWith.Contains(animal.GetType().Name);
        }
    }
}

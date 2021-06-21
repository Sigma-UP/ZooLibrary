using System.Collections.Generic;

namespace ZooLib.Animals.Mammals
{
    public class Bison : Mammal
    {
        public Bison(int id, List<int> feedSchedule = null)
        {
            ID = id;
            FeedSchedule = feedSchedule ?? new List<int>() { 5, 16 };
        }
        public override int RequiredSpaceSqFt { get; } = 1000;
        public override List<string> FavoriteFood { get; } = new List<string> { "Vegetable", "Grass" };
        public List<string> FriendlyWith { get; } = new List<string> {
            "Elephant"
        };

        public override bool IsFriendlyWith(Animal animal)
        {
            return FriendlyWith.Contains(animal.GetType().Name);
        }
    }
}

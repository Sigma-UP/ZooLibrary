using System.Collections.Generic;
namespace ZooLib.Animals.Reptiles
{
    public class Snake : Reptile
    {
        public Snake(int id, List<int> feedSchedule = null)
        {
            ID = id;
            FeedSchedule = feedSchedule ?? new List<int>() { 5, 16 };
        }
        public override int RequiredSpaceSqFt { get; } = 2;
        public override List<string> FavoriteFood { get; } = new List<string> { "Meat" };
        public List<string> FriendlyWith { get; } = new List<string> {
            "Snake"
        };

        public override bool IsFriendlyWith(Animal animal)
        {
            return FriendlyWith.Contains(animal.GetType().Name);
        }
    }
}

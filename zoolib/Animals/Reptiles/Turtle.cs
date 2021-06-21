using System.Collections.Generic;
namespace ZooLib.Animals.Reptiles
{
    public class Turtle : Reptile
    {
        public Turtle(int id, List<int> feedSchedule = null)
        {
            ID = id;
            FeedSchedule = feedSchedule ?? new List<int>() { 5, 16 };
        }
        public override int RequiredSpaceSqFt { get; } = 5;
        public override List<string> FavoriteFood { get; } = new List<string>{ "Vegetable", "Grass" };
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

using System.Collections.Generic;
using ZooLib.Animals.Birds;
using ZooLib.Animals.Mammals;
using ZooLib.Animals.Reptiles;
using Xunit;

namespace ZooTest.Animals.Birds
{
    public class PenguinTest
    {
        [Fact]
        public void ShouldBeAbleToCreatePenguin()
        {
            Penguin penguin = new Penguin(1, new List<int> { 7, 19 });
            Assert.Equal(1, penguin.ID);
            Assert.Equal(new List<int> { 7, 19 }, penguin.FeedSchedule);
            Assert.Equal(10, penguin.RequiredSpaceSqFt);
            Assert.Equal(new List<string> { "Vegetable" }, penguin.FavoriteFood);
            Assert.True(penguin.IsFriendlyWith(new Penguin(2)));
            Assert.False(penguin.IsFriendlyWith(new Lion(3)));
        }
    }
}

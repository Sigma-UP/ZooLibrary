using System.Collections.Generic;
using ZooLib.Animals.Mammals;
using Xunit;

namespace ZooTest.Animals.Mammals
{
    public class BisonTest
    {
        [Fact]
        public void ShouldBeAbleToCreateBison()
        {
            Bison bison = new Bison(1);
            Assert.Equal(1, bison.ID);
            Assert.Equal(new List<int> { 5, 16 }, bison.FeedSchedule);
            Assert.Equal(1000, bison.RequiredSpaceSqFt);
            Assert.Equal(new List<string> { "Vegetable", "Grass" }, bison.FavoriteFood);
            Assert.True(bison.IsFriendlyWith(new Elephant(2)));
            Assert.False(bison.IsFriendlyWith(new Lion(3)));
        }
    }
}

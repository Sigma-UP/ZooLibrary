using System.Collections.Generic;
using ZooLib.Animals.Mammals;
using Xunit;

namespace ZooTest.Animals.Mammals
{
    public class LionTest
    {
        [Fact]
        public void ShouldBeAbleToCreateLion()
        {
            Lion lion = new Lion(1, new List<int> { 7, 19 });
            Assert.Equal(1, lion.ID);
            Assert.Equal(new List<int> { 7, 19 }, lion.FeedSchedule);
            Assert.Equal(1000, lion.RequiredSpaceSqFt);
            Assert.Equal(new List<string> { "Meat" }, lion.FavoriteFood);
            Assert.True(lion.IsFriendlyWith(new Lion(2)));
        }
    }
}

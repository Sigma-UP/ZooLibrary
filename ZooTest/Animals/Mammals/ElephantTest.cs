using System.Collections.Generic;
using ZooLib.Animals.Birds;
using ZooLib.Animals.Mammals;
using ZooLib.Animals.Reptiles;
using Xunit;

namespace ZooTest.Animals.Mammals
{
    public class ElephantTest
    {
        [Fact]
        public void ShouldBeAbleToCreateElephant()
        {
            Elephant elephant = new Elephant(1);
            Assert.Equal(1, elephant.ID);
            Assert.Equal(new List<int> { 5, 16 }, elephant.FeedSchedule);
            Assert.Equal(1000, elephant.RequiredSpaceSqFt);
            Assert.Equal(new List<string> { "Vegetable", "Grass" }, elephant.FavoriteFood);

            Assert.True(elephant.IsFriendlyWith(new Elephant(2)));
            Assert.True(elephant.IsFriendlyWith(new Bison(3)));
            Assert.True(elephant.IsFriendlyWith(new Parrot(4)));
            Assert.True(elephant.IsFriendlyWith(new Turtle(5)));
            Assert.False(elephant.IsFriendlyWith(new Lion(6)));
        }
    }
}

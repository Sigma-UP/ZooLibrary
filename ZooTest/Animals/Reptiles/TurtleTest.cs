using System.Collections.Generic;

using ZooLib.Animals.Mammals;
using ZooLib.Animals.Birds;
using ZooLib.Animals.Reptiles;
using Xunit;

namespace ZooTest.Animals.Reptiles
{
    public class TurtleTest
    {
        [Fact]
        public void ShouldBeAbleToCreateTurtle()
        {
            Turtle turtle = new Turtle(1, new List<int> { 7, 19 });
            Assert.Equal(1, turtle.ID);
            Assert.Equal(new List<int> { 7, 19 }, turtle.FeedSchedule);
            Assert.Equal(5, turtle.RequiredSpaceSqFt);
            Assert.Equal(new List<string> { "Vegetable", "Grass" }, turtle.FavoriteFood);
            Assert.True(turtle.IsFriendlyWith(new Parrot(2)));
            Assert.True(turtle.IsFriendlyWith(new Bison(3)));
            Assert.True(turtle.IsFriendlyWith(new Elephant(4)));
            Assert.True(turtle.IsFriendlyWith(new Turtle(5)));
            Assert.False(turtle.IsFriendlyWith(new Lion(6)));
        }
    }
}

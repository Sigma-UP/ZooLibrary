using System.Collections.Generic;

using ZooLib.Animals.Birds;
using ZooLib.Animals.Reptiles;
using Xunit;

namespace ZooTest.Animals.Reptiles
{
    public class SnakeTest
    {
        [Fact]
        public void ShouldBeAbleToCreateSnake()
        {
            Snake snake = new Snake(1, new List<int> { 7, 19 });
            Assert.Equal(1, snake.ID);
            Assert.Equal(new List<int> { 7, 19 }, snake.FeedSchedule);
            Assert.Equal(2, snake.RequiredSpaceSqFt);
            Assert.Equal(new List<string> { "Meat" }, snake.FavoriteFood);
            Assert.True(snake.IsFriendlyWith(new Snake(2)));
            Assert.False(snake.IsFriendlyWith(new Parrot(3)));
        }
    }
}

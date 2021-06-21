using System.Collections.Generic;
using ZooLib.Animals.Birds;
using ZooLib.Console;
using ZooLib.Employees;
using ZooLib.Exceptions;
using ZooLib.Foods;
using ZooLib.Animals.Mammals;
using ZooLib.Animals.Reptiles;
using Xunit;
namespace ZooTest.Animals.Birds
{
    public class ParrotTest
    {
        [Fact]
        public void ShouldBeAbleToCreateParrot()
        {
            Parrot parrot = new Parrot(1, new List<int> { 7, 19 });
            Assert.Equal(1, parrot.ID);
            Assert.Equal(new List<int> { 7, 19 }, parrot.FeedSchedule);
            Assert.Equal(5, parrot.RequiredSpaceSqFt);
            Assert.Equal(new List<string> { "Vegetable" }, parrot.FavoriteFood);
            Assert.True(parrot.IsFriendlyWith(new Parrot(2)));
            Assert.True(parrot.IsFriendlyWith(new Bison(3)));
            Assert.True(parrot.IsFriendlyWith(new Elephant(4)));
            Assert.True(parrot.IsFriendlyWith(new Turtle(5)));
            Assert.False(parrot.IsFriendlyWith(new Lion(6)));
        }

        [Fact]
        public void ShouldBeAbleToFeedParrot() {
            IConsole console = new ZooConsole();
            Parrot parrot = new Parrot(1, console: console);

            parrot.Feed(new Vegetable(), new ZooKeeper("s", "s", new List<string> { "Parrot" }));
            Assert.Equal($"Feeding {parrot.GetType().Name}: {parrot.GetType().Name} ID {parrot.ID} was fed by s s.", ((ZooConsole)console).Messages[0]);
        }
        [Fact]
        public void ShouldNotBeAbleToFeedParrotWithUnfavoriteFood()
        {
            IConsole console = new ZooConsole();
            Parrot parrot = new Parrot(1, console: console);

            
            Assert.Throws<NotFavoriteFoodException>(() => parrot.Feed(new Meat(), new ZooKeeper("s", "s", new List<string> { "Parrot" })));
            Assert.Equal($"Feeding {parrot.GetType().Name}: Trying to feed {parrot.GetType().Name} ID {parrot.ID} with not its favorite food.", ((ZooConsole)console).Messages[0]);
        }
        [Fact]
        public void ShouldNotBeAbleToFeedParrotIfZooKeeperHasNotExperience()
        {
            IConsole console = new ZooConsole();
            Parrot parrot = new Parrot(1, console: console);


            Assert.Throws<NoNeededExperienceException>(() => parrot.Feed(new Meat(), new ZooKeeper("s", "s", new List<string> { "Lion" })));
            Assert.Equal($"Feeding {parrot.GetType().Name}: The animal can`t be feeded. s s doesn`t have needed experience.", ((ZooConsole)console).Messages[0]);
        }
    }
}

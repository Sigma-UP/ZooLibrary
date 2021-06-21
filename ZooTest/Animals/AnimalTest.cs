using System.Collections.Generic;
using System;
using ZooLib.Animals;
using ZooLib.Exceptions;
using ZooLib.Medicines;
using ZooLib.Console;
using Xunit;
using Moq;

namespace ZooTest.Animals
{
    public class AnimalTest
    {
        [Fact]
        public void AnimalIsHungryWhenItIsCreated()
        {
            var mock = new Mock<Animal>();

            Assert.True(mock.Object.IsHungry(DateTime.Now));
        }
        [Fact]
        public void AnimalIsNotSickWhenItIsCreated()
        {
            var mock = new Mock<Animal>();

            Assert.False(mock.Object.IsSick);

            //Assert.Throws<NotFavoriteFoodException>(() => mock.Object.Feed(new Vegetable(), new ZooKeeper("Alex", "Huyalex", new List<string> { "Lion" })));
            //Assert.Equal($"Lion: Trying to feed Lion ID 1 with not its favorite food.", ((ZooConsole)console).Messages[0]);
        }
        [Fact]
        public void AnimalCanBeSick()
        {
            var mock = new Mock<Animal>();
            mock.Object.IsSick = true;

            Assert.True(mock.Object.IsSick);
        }

        [Fact]
        public void AnimalShouldBeAbleToAddFeedSchedule()
        {
            IConsole console = new ZooConsole();

            var mock = new Mock<Animal>(console);
            mock.Object.AddFeedSchedule(new List<int> { 12, 20 });

            Assert.Equal(new List<int> { 12, 20 }, mock.Object.FeedSchedule);
        }
        [Fact]
        public void AnimalShouldNotBeAbleToAddFeedScheduleContainsNull()
        {
            IConsole console = new ZooConsole();

            var mock = new Mock<Animal>(console);
            
            Assert.Throws<NullReferenceException>(() => mock.Object.AddFeedSchedule(null));
            Assert.Equal($"Feed schedule change {mock.Object.GetType().Name}: The feed schedule of {mock.Object.GetType().Name} ID {mock.Object.ID} was not changed.", ((ZooConsole)console).Messages[0]);
        }

        [Fact]
        public void AnimalShouldNotBeAbleToAddFeedScheduleWithTheSameElements()
        {
            IConsole console = new ZooConsole();

            var mock = new Mock<Animal>(console);
            mock.Object.AddFeedSchedule(new List<int> { 12, 20 });

            Assert.Equal(new List<int> { 12, 20 }, mock.Object.FeedSchedule);

            Assert.Throws<SameScheduleException>(() => mock.Object.AddFeedSchedule(new List<int> { 12, 20 })); 
        }

        [Fact]
        public void AnimalShouldBeHealedIfSick()
        {
            IConsole console = new ZooConsole();
            var mock = new Mock<Animal>(console);
            mock.Object.IsSick = true;

            mock.Object.Heal(new AntiDepression());
            Assert.False(mock.Object.IsSick);
            Assert.Equal($"Healing {mock.Object.GetType().Name}: The {mock.Object.GetType().Name}#{mock.Object.ID} is healed by AntiDepression.", ((ZooConsole)console).Messages[0]);
        }

        [Fact]
        public void AnimalShouldNotBeHealedIfItIsHealthy()
        {
            IConsole console = new ZooConsole();
            var mock = new Mock<Animal>(console);
            Assert.False(mock.Object.IsSick);

            mock.Object.Heal(new AntiDepression());
            Assert.Equal($"Healing {mock.Object.GetType().Name}: The {mock.Object.GetType().Name} is no need healing.", ((ZooConsole)console).Messages[0]);
        }
    }
}

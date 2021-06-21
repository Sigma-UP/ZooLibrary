using System.Collections.Generic;
using System;
using ZooLib.Employees;

using ZooLib.Animals.Mammals;
using ZooLib.Animals.Birds;
using Xunit;
namespace ZooTest.Employees
{
    public class ZooKeeperTest
    {
        [Fact]
        public void ShouldBeAbleToCreateZooKeeper()
        {
            IEmployee employee = new ZooKeeper("Anthony", "Hopkins", new List<string> { "Parrot", "Penguin" });
            Assert.Equal("Anthony", employee.FirstName);
            Assert.Equal("Hopkins", employee.LastName);
            Assert.Equal(new List<string> { "Parrot", "Penguin" }, employee.AnimalExperiences);
        }

        [Fact]
        public void ShouldBeAbletoAddAnimalExperiences()
        {
            IEmployee employee = new ZooKeeper("Anthony", "Hopkins", new List<string>());
            employee.AddAnimalExperience(new Parrot(1));
            Assert.True(employee.HasAnimalExperience(new Parrot(1)));
        }

        [Fact]
        public void ShouldBeAbleToFeedAnimal()
        {
            IEmployee employee = new ZooKeeper("Anthony", "Hopkins", new List<string> { "Parrot" });
            Parrot parrot = new Parrot(1);

            Assert.True(parrot.IsHungry(DateTime.Now));

            Assert.True(((ZooKeeper)employee).FeedAnimal(parrot));
            Assert.True(((ZooKeeper)employee).FeedAnimal(parrot));

            Assert.False(parrot.IsHungry(DateTime.Now));
        }

        [Fact]
        public void ShouldBeUnableToFeedAnimalWithotExperience()
        {
            IEmployee employee = new ZooKeeper("Anthony", "Hopkins", new List<string> { "Parrot" });
            Lion lion = new Lion(2);

            Assert.True(lion.IsHungry(DateTime.Now));

            Assert.False(((ZooKeeper)employee).FeedAnimal(lion));

            Assert.True(lion.IsHungry(DateTime.Now));
        }
    }
}

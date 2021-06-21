using System.Collections.Generic;
using ZooLib.Console;
using ZooLib.Exceptions;
using ZooLib.Animals;
using ZooLib.Animals.Mammals;
using ZooLib.Employees;
using ZooLib.Animals.Birds;
using ZooLib.Animals.Reptiles;
using ZooLib;
using System;
using Xunit;
namespace ZooTest
{
    public class ZooTest
    {
        [Fact]
        public void ShouldBeAbleToCrateZoo()
        {
            Zoo zoo = new Zoo("Denver");
            Assert.Equal("Denver", zoo.Location);
        }
        [Fact]
        public void ShouldBeAbleToAddEnclosure()
        {
            Zoo zoo = new Zoo("Denver");
            zoo.AddEnclosure("Enc1", 5000);

            Assert.Equal("Enc1", zoo.Enclosures[0].Name);
        }
        [Fact]
        public void ShouldBeUnableToAddEnclosureWithNameThatAlreadyExists()
        {
            IConsole console = new ZooConsole();
            Zoo zoo = new Zoo("Denver", console);
            zoo.AddEnclosure("Enc1", 5000);

            Assert.Throws<EnclosureIsAlreadyExistsException>(() => zoo.AddEnclosure("Enc1", 4000));
            Assert.Equal("Enclosure Addition: Impossible to add the Enclosure Enc1 because an Enclosure with such name is already exists.", ((ZooConsole)console).Messages[1]);
        }
        [Fact]
        public void ShouldBeAbleToFindAvailableEnclosure()
        {
            Zoo zoo = new Zoo("Denver");
            zoo.AddEnclosure("Enc1", 500);
            zoo.AddEnclosure("Enc2", 5000);


            Assert.Equal(zoo.Enclosures[1], zoo.FindAvailableEnclosure(new Lion(1)));
        }
        [Fact]
        public void ShouldBeAbleFindAvailableNonEmptyEnclosureWithFriendlyAnimalOnly()
        {
            IConsole console = new ZooConsole();
            Zoo zoo = new Zoo("Denver", console);
            zoo.AddEnclosure("Enc1", 2000);
            zoo.Enclosures[0].AddAnimals(new Elephant(1));

            zoo.AddEnclosure("Enc2", 2000);
            zoo.Enclosures[1].AddAnimals(new Lion(2));

            Assert.Equal(zoo.Enclosures[1], zoo.FindAvailableEnclosure(new Lion(3)));
            Assert.Equal("Available Enclosure searching: The Enclosure for Lion ID:3 is finded.", ((ZooConsole)console).Messages[2]);
        } 
        [Fact]
        public void ShouldBeAbleToReturnNullIfThereIsNoAvailableEnclosure()
        {
            IConsole console = new ZooConsole();
            Zoo zoo = new Zoo("Denver", console);
            zoo.AddEnclosure("Enc1", 2000);
            zoo.Enclosures[0].AddAnimals(new Elephant(1));

            Assert.Null(zoo.FindAvailableEnclosure(new Lion(3)));
            Assert.Equal("Available Enclosure searching: The Enclosure for Lion ID:3 is not finded.", ((ZooConsole)console).Messages[1]);
        }

        [Fact]
        public void ShouldBeAbleToHireAnEmployee()
        {
            ZooConsole console = new ZooConsole();
            Zoo zoo = new Zoo("Denver", console);
            zoo.AddEnclosure("Enclosure1", 2000);
            zoo.Enclosures[0].AddAnimals(new Lion(1));
            zoo.HireEmployee(new ZooKeeper("Alex", "Terrible", new List<string> { "Lion" }));

            Assert.Equal($"Employee Addition: ZooKeeper Alex Terrible was successfully hired.", console.Messages[1]);
        }
        [Fact]
        public void ShouldNotBeAbleToHireAnEmployeeIfAnyValidationErrorIsExist()
        {
            ZooConsole console = new ZooConsole();
            Zoo zoo = new Zoo("Denver", console);
            zoo.AddEnclosure("Enclosure1", 2000);
            zoo.Enclosures[0].AddAnimals(new Lion(1));
            zoo.HireEmployee(new ZooKeeper("Alex", "Terrible", new List<string> { "Bison" }));

            Assert.Equal($"Employee Addition: ZooKeeper Alex Terrible cant be hired.", console.Messages[1]);
        }

        [Fact]
        public void ShouldBeAbleToFeedAnimalsByZooKeepers()
        {
            ZooConsole console = new ZooConsole();
            Zoo zoo = new Zoo("London", console);
            zoo.AddEnclosure("Enclosure1", 10000);
            zoo.AddEnclosure("Enclosure2", 10000);
            zoo.AddEnclosure("Enclosure3", 10000);
            Parrot parrot = new Parrot(1);
            Lion lion = new Lion(2);
            Penguin penguin = new Penguin(3);
            Penguin penguin2 = new Penguin(4);
            zoo.Enclosures[0].AddAnimals(parrot);
            zoo.Enclosures[1].AddAnimals(lion);
            zoo.Enclosures[2].AddAnimals(penguin);
            zoo.Enclosures[2].AddAnimals(penguin2);

            ZooKeeper zooKeeper1 =
                new ZooKeeper("Bob", "Smith", new List<string>() { "Elephant", "Parrot", "Lion", "Penguin" });
            ZooKeeper zooKeeper2 = new ZooKeeper("Tom", "Ford", new List<string>() { "Elephant", "Parrot", "Lion", "Penguin" });
            zoo.HireEmployee(zooKeeper1);
            zoo.HireEmployee(zooKeeper2);
            zooKeeper1.FeedAnimal(parrot);
            zooKeeper2.FeedAnimal(lion);
            zooKeeper1.FeedAnimal(penguin);
            zooKeeper1.FeedAnimal(penguin2);
            zooKeeper1.FeedAnimal(penguin2);
            DateTime dateTime = DateTime.Now;
            zoo.FeedAnimals(dateTime);

            Assert.Equal(2, parrot.FeedTimes.Count);
            Assert.Equal(2, lion.FeedTimes.Count);
            Assert.Equal(2, penguin.FeedTimes.Count);
            Assert.Equal(2, penguin2.FeedTimes.Count);
            Assert.Equal("Feeding Animals London: Parrot ID 1 was fed by Bob Smith.", console.Messages[7]);
        }

        [Fact]
        public void ShouldBeAbleToHealAnimalsByZooKeepers()
        {
            ZooConsole console = new ZooConsole();
            Zoo zoo = new Zoo("London", console);
            zoo.AddEnclosure("Enclosure1", 10000);
            zoo.AddEnclosure("Enclosure2", 10000);
            zoo.AddEnclosure("Enclosure3", 10000);
            Parrot parrot = new Parrot(1);
            parrot.IsSick = true;
            Lion lion = new Lion(2);
            lion.IsSick = true;
            Penguin penguin = new Penguin(3);
            penguin.IsSick = true;
            Elephant elephant = new Elephant(4);
            elephant.IsSick = true;

            zoo.Enclosures[0].AddAnimals(parrot);
            zoo.Enclosures[0].AddAnimals(elephant);
            zoo.Enclosures[1].AddAnimals(lion);
            zoo.Enclosures[2].AddAnimals(penguin);

            var veterinarian1 = new Veterinarian("Bob", "Smith",
                new List<string>() { "Elephant", "Parrot", "Lion", "Penguin" });
            var veterinarian2 =
                new Veterinarian("Tom", "Ford", new List<string>() { "Elephant", "Parrot", "Lion", "Penguin" });
            zoo.HireEmployee(veterinarian1);
            zoo.HireEmployee(veterinarian2);
            Assert.True(parrot.IsSick);
            Assert.True(lion.IsSick);
            Assert.True(elephant.IsSick);
            Assert.True(penguin.IsSick);
            zoo.HealAnimals();
            Assert.False(parrot.IsSick);
            Assert.False(lion.IsSick);
            Assert.False(elephant.IsSick);
            Assert.False(penguin.IsSick);
            Assert.Equal("Healing Animals London: Parrot ID 1 was healed by Bob Smith.", console.Messages[5]);
        }

        [Fact]
        public void ShouldThrowUnknownAnimalExceptionIfNoZooKeeperWithSuchAnimalExperience()
        {
            Zoo zoo = new Zoo("London");
            zoo.AddEnclosure("Enclosure1", 10000);
            zoo.AddEnclosure("Enclosure2", 10000);
            zoo.AddEnclosure("Enclosure3", 10000);

            var parrot = new Parrot(1);
            var lion = new Lion(2);
            var bison = new Bison(3);
            
            zoo.Enclosures[0].AddAnimals(lion);
            zoo.Enclosures[1].AddAnimals(parrot);
            zoo.Enclosures[1].AddAnimals(bison);
            var zooKeeper1 =
                new ZooKeeper("Bob", "Smith", new List<string>() { "Elephant", "Parrot", "Lion", "Penguin" });
            var zooKeeper2 = new ZooKeeper("Tom", "Ford", new List<string>() { "Elephant", "Parrot", "Lion", "Penguin" });
            zoo.HireEmployee(zooKeeper1);
            zoo.HireEmployee(zooKeeper2);

            Assert.Throws<UnknownAnimalException>(() => zoo.DivideAnimalsBetweenEmployees("ZooKeeper", animal => true));
        }
    }
}

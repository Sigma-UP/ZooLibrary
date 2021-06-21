using ZooLib;
using ZooLib.Animals;
using ZooLib.Animals.Birds;
using ZooLib.Animals.Mammals;
using ZooLib.Animals.Reptiles;
using ZooLib.Console;
using ZooLib.Exceptions;
using System.Collections.Generic;
using Xunit;
namespace ZooTest
{
    public class EnclosureTest
    {
        [Fact]
        public void ShouldBeAbleToCreateEnclosure()
        {
            Enclosure enclosure = new Enclosure("Enclosure1", null, null, 50000);

            Assert.Equal("Enclosure1", enclosure.Name);
            Assert.Null(enclosure.Animals);
            Assert.Null(enclosure.ParentZoo);
            Assert.Equal(50000, enclosure.SquareFeet);
        }

        [Fact]
        public void ShouldBeAbleToCalculateFreeSpace()
        {
            List<Animal> animals = new List<Animal> { new Lion(1), new Lion(2), };
            Enclosure enclosure = new Enclosure("Enclosure1", animals, null, 10000);
            Assert.Equal(8000, enclosure.AvailableSpace());
        }

        [Fact]
        public void ShouldBeAbleToAddFriendlyAnimalsIntoEnclosure()
        {
            List<Animal> animals = new List<Animal> { new Elephant(1), new Parrot(2), };
            Enclosure enclosure = new Enclosure("Enclosure1", animals, null, 10000);
            Turtle turtle = new Turtle(3);
            enclosure.AddAnimals(turtle);

            Assert.Equal(turtle, enclosure.Animals[2]);
        }
        [Fact]
        public void ShouldNotBeAbleToAddFriendlyAnimalsIntoFullEnclosure()
        {
            IConsole console = new ZooConsole();
            List<Animal> animals = new List<Animal> { new Elephant(1), new Parrot(2), };
            Enclosure enclosure = new Enclosure("Enclosure1", animals, null, 1010, console);
            Elephant elephant = new Elephant(3);
            Assert.Throws<NoAvailableSpaceException>(() => enclosure.AddAnimals(elephant));
            Assert.Equal($"Enclosure Enclosure1 Addition: Addition failed. Elephant need more space.", ((ZooConsole)console).Messages[0]);    
        }

        [Fact]
        public void ShouldNotBeAbleToAddFriendlyAnimalsIntoFullEnclosureAndConsoleIsNull()
        {
            List<Animal> animals = new List<Animal> { new Elephant(1), new Parrot(2), };
            Enclosure enclosure = new Enclosure("Enclosure1", animals, null, 1010);
            Elephant elephant = new Elephant(3);
            Assert.Throws<NoAvailableSpaceException>(() => enclosure.AddAnimals(elephant));
        }

        [Fact]
        public void ShouldNotBeAbleToAddUnfriendlyAnimalsIntoEnclosure()
        {
            IConsole console = new ZooConsole();
            List<Animal> animals = new List<Animal> { new Elephant(1), new Parrot(2), };
            Enclosure enclosure = new Enclosure("Enclosure1", animals, null, 10000, console);
            Lion lion = new Lion(3);
            Assert.Throws<NotFriendlyAnimalException>(() => enclosure.AddAnimals(lion));
            Assert.Equal($"Enclosure Enclosure1 Addition: Addition failed. Lion is not friendly with Elephant.", ((ZooConsole)console).Messages[0]);    
        }
        [Fact]
        public void ShouldNotBeAbleToAddUnfriendlyAnimalsIntoEnclosureIsNull()
        {
            List<Animal> animals = new List<Animal> { new Elephant(1), new Parrot(2), };
            Enclosure enclosure = new Enclosure("Enclosure1", animals, null, 10000);
            Lion lion = new Lion(3);
            Assert.Throws<NotFriendlyAnimalException>(() => enclosure.AddAnimals(lion));
        }

    }
}

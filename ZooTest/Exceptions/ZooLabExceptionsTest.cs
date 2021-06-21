using System.Collections.Generic;
using ZooLib.Console;
using ZooLib.Exceptions;
using ZooLib.Animals;
using ZooLib.Animals.Mammals;
using ZooLib.Employees;
using ZooLib.Animals.Birds;
using ZooLib.Animals.Reptiles;
using ZooLib;
using Xunit;

namespace ZooTest.Exceptions
{
    public class ZooLabExceptionsTest
    {
        [Fact]
        public void ShouldBeAbleToCreateNoNeededExperienceException()
        {
            NoNeededExperienceException exception = new NoNeededExperienceException("Message");
            Assert.Equal("Message", exception.Message);
        }

        [Fact]
        public void ShouldBeAbleToCreateEnclosureAlreadyExistsException()
        {
            EnclosureIsAlreadyExistsException exception = new EnclosureIsAlreadyExistsException("Message");
            Assert.Equal("Message", exception.Message);
        }
        
        [Fact]
        public void ShouldBeAbleToCreateNoAvailableSpaceException()
        {
            NoAvailableSpaceException exception = new NoAvailableSpaceException("Message");
            Assert.Equal("Message", exception.Message);
        }


        [Fact]
        public void ShouldBeAbleToCreateNotFavoriteFoodException()
        {
            NotFavoriteFoodException exception = new NotFavoriteFoodException("Message");
            Assert.Equal("Message", exception.Message);
        }


        [Fact]
        public void ShouldBeAbleToCreateNotFriendlyAnimalException()
        {
            NotFriendlyAnimalException exception = new NotFriendlyAnimalException("Message");
            Assert.Equal("Message", exception.Message);
        }

        [Fact]
        public void ShouldBeAbleToCreateUnknownAnimalException()
        {
            UnknownAnimalException exception = new UnknownAnimalException("Message");
            Assert.Equal("Message", exception.Message);
        }
    }
}

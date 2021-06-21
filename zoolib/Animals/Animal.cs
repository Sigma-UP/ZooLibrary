using System.Collections.Generic;
using ZooLib.Exceptions;
using ZooLib.Employees;
using ZooLib.Foods;
using ZooLib.Medicines;
using ZooLib.Console;
using System;
namespace ZooLib.Animals
{
    public abstract class Animal
    {
        private readonly IConsole _console;
        protected Animal(IConsole console = null)
        {
            _console = console;
        }

        public Animal() { }

        public bool IsSick { get; set; } = false;

        public abstract int RequiredSpaceSqFt{ get; }

        public abstract List<string> FavoriteFood { get; }

        public abstract bool IsFriendlyWith(Animal animal);

        public List<FeedTime> FeedTimes { get; } = new List<FeedTime>();

        public List<int> FeedSchedule { get; set; } = new List<int>();
        
        public int ID { get; set; }
        
        public bool IsHungry(DateTime dateTime)
        {
            var dayBeginning = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day);
            if (FeedTimes.Count == 0 || FeedTimes.Count == 1)
            {
                return true;
            }

            return !(FeedTimes[^1].FeedAnimalTime >= dayBeginning &&
            FeedTimes[^2].FeedAnimalTime >= dayBeginning);
        } //additional

        public void Feed(Food food, ZooKeeper zooKeeper)
        {
            if(!zooKeeper.HasAnimalExperience(this))
            {
                _console?.WriteLine($"Feeding {GetType().Name}: The animal can`t be feeded. {zooKeeper.FirstName} {zooKeeper.LastName} doesn`t have needed experience.");
                throw new NoNeededExperienceException($"Feeding {GetType().Name}: The animal can`t be feeded. {zooKeeper.FirstName} {zooKeeper.LastName} doesn`t have needed experience.");
            }    
            if (FavoriteFood.Contains(food.GetType().Name))
            {
                FeedTimes.Add(new FeedTime(DateTime.Now, zooKeeper));
                _console?.WriteLine($"Feeding {GetType().Name}: {GetType().Name} ID {ID} was fed by {zooKeeper.FirstName} {zooKeeper.LastName}.");
            }
            else
            {
                _console?.WriteLine($"Feeding {GetType().Name}: Trying to feed {GetType().Name} ID {ID} with not its favorite food.");
                throw new NotFavoriteFoodException($"Feeding {GetType().Name}: The animal does not eat this type of food.");
            }
        }
        public void AddFeedSchedule(List<int> hours)
        {
            if (hours == null)
            {
                _console?.WriteLine($"Feed schedule change {GetType().Name}: The feed schedule of {GetType().Name} ID {ID} was not changed.");
                throw new NullReferenceException();
            }
            
            bool isChanged = false;
            foreach (int hour in hours)
                if (!FeedSchedule.Contains(hour))
                {
                    FeedSchedule.AddRange(hours);
                    isChanged = true;
                }
            if (isChanged)
                _console?.WriteLine($"Feed schedule change {GetType().Name}: The feed schedule of {GetType().Name} ID {ID} was changed.");
            else
            {
                _console?.WriteLine($"Feed schedule change {GetType().Name}: The feed schedule of {GetType().Name} ID {ID} was not changed.");
                throw new SameScheduleException("The animal already has such values in feed schedule.");
            }          
        }
        public void Heal(Medicine medicine) 
        {
            if(IsSick == false)
            {
                _console?.WriteLine($"Healing {GetType().Name}: The {GetType().Name} is no need healing.");
                return;
            }
            IsSick = false;
            _console?.WriteLine($"Healing {GetType().Name}: The {GetType().Name}#{ID} is healed by {medicine.GetType().Name}.");
        }
    }
}

using Characters;

namespace Robots
{
    public class Robot
    {
        public string? Name { get; set; }
        public Character? Character { get; set; }

        public Robot()
        {
            Name = "Cici";
        }

        public Character? RobotChoise()
        {
            Random random = new Random((int)(DateTime.Now.Ticks));
            int number = random.Next(1, 6);
            switch (number)
            {
                case 1:
                    Character warrior = new Warrior();
                    Console.WriteLine($"{Name} chose Warrior!");
                    return warrior;
                case 2:
                    Character archer = new Archer();
                    Console.WriteLine($"{Name} chose Archer! ");
                    return archer;
                case 3:
                    Character healer = new Healer();
                    Console.WriteLine($"{Name} chose Healer! ");
                    return healer;
                case 4:
                    Character mage = new Mage();
                    Console.WriteLine($"{Name} chose Mage! ");
                    return mage;
                case 5:
                    Character assasin = new Assasin();
                    Console.WriteLine($"{Name} chose Assasin! ");
                    return assasin;
                default:
                    return null;
            }
        }
    }
}
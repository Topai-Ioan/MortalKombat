using Xunit;
using Moq;
using Arenas;
using Characters;
using Players;
using Robots;

namespace UnitTests
{
    public class ArenaTests
    {

        [Theory]
        [InlineData(100)]
        [InlineData(1000)]
        public void Fight_ShouldBeFairWarriorAndArcher(int iterations)
        {
            Arena arena = new Arena();

            Arena.playerWins = 0;
            Arena.robotWins = 0;
            for (int i = 0; i < iterations; i++)
            {
                Player player = new Player();
                player.Character = new Warrior();
                Robot robot = new Robot();
                robot.Character = new Archer();
                arena.Fight(player, robot);

            }
            Console.WriteLine($"The Player won {Arena.playerWins} times");
            Console.WriteLine($"The Robot won {Arena.robotWins} times");

            Assert.InRange(Arena.playerWins, iterations / 2 - 0.15 * iterations , iterations / 2 + 0.15 * iterations);
        }        
        [Theory]
        [InlineData(100)]
        [InlineData(1000)]
        public void Fight_ShouldBeFairWarriorAndAssasin(int iterations)
        {
            Arena arena = new Arena();

            Arena.playerWins = 0;
            Arena.robotWins = 0;
            for (int i = 0; i < iterations; i++)
            {
                Player player = new Player();
                player.Character = new Warrior();
                Robot robot = new Robot();
                robot.Character = new Assasin();
                arena.Fight(player, robot);

            }
            Console.WriteLine($"The Player won {Arena.playerWins} times");
            Console.WriteLine($"The Robot won {Arena.robotWins} times");

            Assert.InRange(Arena.playerWins, iterations/2 - 0.15*iterations , iterations/2 + 0.15 * iterations);
        }

        [Theory]
        [InlineData(100)]
        [InlineData(1000)]
        public void Fight_ShouldBeFairWarriorAndHealer(int iterations)
        {
            Arena arena = new Arena();

            Arena.playerWins = 0;
            Arena.robotWins = 0;
            for (int i = 0; i < iterations; i++)
            {
                Player player = new Player();
                player.Character = new Warrior();
                Robot robot = new Robot();
                robot.Character = new Healer();
                arena.Fight(player, robot);

            }
            Console.WriteLine($"The Player won {Arena.playerWins} times");
            Console.WriteLine($"The Robot won {Arena.robotWins} times");

            Assert.InRange(Arena.playerWins, iterations/2 - 0.1*iterations , iterations/2 + 0.1 * iterations);
        }        
        [Theory]
        [InlineData(100)]
        [InlineData(1000)]
        public void Fight_ShouldBeFairWarriorAndMage(int iterations)
        {
            Arena arena = new Arena();

            Arena.playerWins = 0;
            Arena.robotWins = 0;
            for (int i = 0; i < iterations; i++)
            {
                Player player = new Player();
                player.Character = new Warrior();
                Robot robot = new Robot();
                robot.Character = new Mage();
                arena.Fight(player, robot);

            }
            Console.WriteLine($"The Player won {Arena.playerWins} times");
            Console.WriteLine($"The Robot won {Arena.robotWins} times");

            Assert.InRange(Arena.playerWins, iterations/2 - 0.1*iterations , iterations/2 + 0.1 * iterations);
        }

        [Theory]
        [InlineData(100)]
        [InlineData(1000)]
        public void Fight_ShouldBeFairMageAndArcher(int iterations)
        {
            Arena arena = new Arena();

            Arena.playerWins = 0;
            Arena.robotWins = 0;
            for (int i = 0; i < iterations; i++)
            {
                Player player = new Player();
                player.Character = new Mage();
                Robot robot = new Robot();
                robot.Character = new Archer();
                arena.Fight(player, robot);
            }
            Console.WriteLine($"The Player won {Arena.playerWins} times");
            Console.WriteLine($"The Robot won {Arena.robotWins} times");

            Assert.InRange(Arena.playerWins, iterations/2 - 0.1*iterations , iterations/2 + 0.1 * iterations);
        }  
        [Theory]
        [InlineData(100)]
        [InlineData(1000)]
        public void Fight_ShouldBeFairMageAndAssasin(int iterations)
        {
            Arena arena = new Arena();

            Arena.playerWins = 0;
            Arena.robotWins = 0;
            for (int i = 0; i < iterations; i++)
            {
                Player player = new Player();
                player.Character = new Mage();
                Robot robot = new Robot();
                robot.Character = new Assasin();
                arena.Fight(player, robot);
            }
            Console.WriteLine($"The Player won {Arena.playerWins} times");
            Console.WriteLine($"The Robot won {Arena.robotWins} times");

            Assert.InRange(Arena.playerWins, iterations/2 - 0.1*iterations , iterations/2 + 0.1 * iterations);
        }
        [Theory]
        [InlineData(100)]
        [InlineData(1000)]
        public void Fight_ShouldBeFairMageAndHealer(int iterations)
        {
            Arena arena = new Arena();

            Arena.playerWins = 0;
            Arena.robotWins = 0;
            for (int i = 0; i < iterations; i++)
            {
                Player player = new Player();
                player.Character = new Mage();
                Robot robot = new Robot();
                robot.Character = new Healer();
                arena.Fight(player, robot);
            }
            Console.WriteLine($"The Player won {Arena.playerWins} times");
            Console.WriteLine($"The Robot won {Arena.robotWins} times");

            Assert.InRange(Arena.playerWins, iterations / 2 - 0.15 * iterations, iterations / 2 + 0.15 * iterations);
        }
        [Theory]
        [InlineData(100)]
        [InlineData(1000)]
        public void Fight_ShouldBeFairHealerAndArcher(int iterations)
        {
            Arena arena = new Arena();

            Arena.playerWins = 0;
            Arena.robotWins = 0;
            for (int i = 0; i < iterations; i++)
            {
                Player player = new Player();
                player.Character = new Healer();
                Robot robot = new Robot();
                robot.Character = new Archer();
                arena.Fight(player, robot);
            }
            Console.WriteLine($"The Player won {Arena.playerWins} times");
            Console.WriteLine($"The Robot won {Arena.robotWins} times");

            Assert.InRange(Arena.playerWins, iterations/2 - 0.1*iterations , iterations/2 + 0.1 * iterations);
        } 
        [Theory]
        [InlineData(100)]
        [InlineData(1000)]
        public void Fight_ShouldBeFairHealerAndAssasin(int iterations)
        {
            Arena arena = new Arena();

            Arena.playerWins = 0;
            Arena.robotWins = 0;
            for (int i = 0; i < iterations; i++)
            {
                Player player = new Player();
                player.Character = new Healer();
                Robot robot = new Robot();
                robot.Character = new Assasin();
                arena.Fight(player, robot);
            }
            Console.WriteLine($"The Player won {Arena.playerWins} times");
            Console.WriteLine($"The Robot won {Arena.robotWins} times");

            Assert.InRange(Arena.playerWins, iterations/2 - 0.15*iterations , iterations/2 + 0.15 * iterations);
        } 
        [Theory]
        [InlineData(100)]
        [InlineData(1000)]
        public void Fight_ShouldBeFairAssasinAndArcher(int iterations)
        {
            Arena arena = new Arena();

            Arena.playerWins = 0;
            Arena.robotWins = 0;
            for (int i = 0; i < iterations; i++)
            {
                Player player = new Player();
                player.Character = new Assasin();
                Robot robot = new Robot();
                robot.Character = new Archer();
                arena.Fight(player, robot);
            }
            Console.WriteLine($"The Player won {Arena.playerWins} times");
            Console.WriteLine($"The Robot won {Arena.robotWins} times");

            Assert.InRange(Arena.playerWins, iterations/2 - 0.15*iterations , iterations/2 + 0.15 * iterations);
        } 
       
    }
}
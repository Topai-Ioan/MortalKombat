using Xunit;
using Moq;
using Arenas;
using Characters;
using static System.Net.Mime.MediaTypeNames;

namespace UnitTests
{
    public class ArenaTests
    {

        [Theory]
        [InlineData(10)]
        [InlineData(100)]
        [InlineData(1000)]
        public void Fight_ShouldBeFairWarriorAndArcher(int iterations)
        {
            Arena arena = new Arena();

            Arena.playerWins = 0;
            Arena.robotWins = 0;
            for (int i = 0; i < iterations; i++)
            {
                Warrior warrior = new Warrior();
                Archer archer = new Archer();
                arena.Fight(warrior,"alex", archer);

            }
            Console.WriteLine($"The Player won {Arena.playerWins} times");
            Console.WriteLine($"The Robot won {Arena.robotWins} times");

            Assert.InRange(Arena.playerWins, iterations / 2 - 0.15 * iterations , iterations / 2 + 0.15 * iterations);
        }        
        [Theory]
        [InlineData(10)]
        [InlineData(100)]
        [InlineData(1000)]
        public void Fight_ShouldBeFairWarriorAndAssasin(int iterations)
        {
            Arena arena = new Arena();

            Arena.playerWins = 0;
            Arena.robotWins = 0;
            for (int i = 0; i < iterations; i++)
            {
                Warrior warrior = new Warrior();
                Assasin assasin = new Assasin();
                arena.Fight(warrior,"alex", assasin);

            }
            Console.WriteLine($"The Player won {Arena.playerWins} times");
            Console.WriteLine($"The Robot won {Arena.robotWins} times");

            Assert.InRange(Arena.playerWins, iterations/2 - 0.15*iterations , iterations/2 + 0.15 * iterations);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(100)]
        [InlineData(1000)]
        public void Fight_ShouldBeFairWarriorAndHealer(int iterations)
        {
            Arena arena = new Arena();

            Arena.playerWins = 0;
            Arena.robotWins = 0;
            for (int i = 0; i < iterations; i++)
            {
                Warrior warrior = new Warrior();
                Healer healer = new Healer();
                arena.Fight(warrior,"alex", healer);

            }
            Console.WriteLine($"The Player won {Arena.playerWins} times");
            Console.WriteLine($"The Robot won {Arena.robotWins} times");

            Assert.InRange(Arena.playerWins, iterations/2 - 0.1*iterations , iterations/2 + 0.1 * iterations);
        }        
        [Theory]
        [InlineData(10)]
        [InlineData(100)]
        [InlineData(1000)]
        public void Fight_ShouldBeFairWarriorAndMage(int iterations)
        {
            Arena arena = new Arena();

            Arena.playerWins = 0;
            Arena.robotWins = 0;
            for (int i = 0; i < iterations; i++)
            {
                Warrior warrior = new Warrior();
                Mage mage = new Mage();
                arena.Fight(warrior,"alex", mage);

            }
            Console.WriteLine($"The Player won {Arena.playerWins} times");
            Console.WriteLine($"The Robot won {Arena.robotWins} times");

            Assert.InRange(Arena.playerWins, iterations/2 - 0.1*iterations , iterations/2 + 0.1 * iterations);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(100)]
        [InlineData(1000)]
        public void Fight_ShouldBeFairMageAndArcher(int iterations)
        {
            Arena arena = new Arena();

            Arena.playerWins = 0;
            Arena.robotWins = 0;
            for (int i = 0; i < iterations; i++)
            {
                Mage mage = new Mage();
                Archer archer = new Archer();
                arena.Fight(mage,"alex", archer);
            }
            Console.WriteLine($"The Player won {Arena.playerWins} times");
            Console.WriteLine($"The Robot won {Arena.robotWins} times");

            Assert.InRange(Arena.playerWins, iterations/2 - 0.1*iterations , iterations/2 + 0.1 * iterations);
        }  
        [Theory]
        [InlineData(10)]
        [InlineData(100)]
        [InlineData(1000)]
        public void Fight_ShouldBeFairMageAndAssasin(int iterations)
        {
            Arena arena = new Arena();

            Arena.playerWins = 0;
            Arena.robotWins = 0;
            for (int i = 0; i < iterations; i++)
            {
                Mage mage = new Mage();
                Assasin assasin = new Assasin();
                arena.Fight(mage,"alex", assasin);
            }
            Console.WriteLine($"The Player won {Arena.playerWins} times");
            Console.WriteLine($"The Robot won {Arena.robotWins} times");

            Assert.InRange(Arena.playerWins, iterations/2 - 0.1*iterations , iterations/2 + 0.1 * iterations);
        }
        [Theory]
        [InlineData(10)]
        [InlineData(100)]
        [InlineData(1000)]
        public void Fight_ShouldBeFairMageAndHealer(int iterations)
        {
            Arena arena = new Arena();

            Arena.playerWins = 0;
            Arena.robotWins = 0;
            for (int i = 0; i < iterations; i++)
            {
                Mage mage = new Mage();
                Healer healer = new Healer();
                arena.Fight(mage, "alex", healer);
            }
            Console.WriteLine($"The Player won {Arena.playerWins} times");
            Console.WriteLine($"The Robot won {Arena.robotWins} times");

            Assert.InRange(Arena.playerWins, iterations / 2 - 0.15 * iterations, iterations / 2 + 0.15 * iterations);
        }
        [Theory]
        [InlineData(10)]
        [InlineData(100)]
        [InlineData(1000)]
        public void Fight_ShouldBeFairHealerAndArcher(int iterations)
        {
            Arena arena = new Arena();

            Arena.playerWins = 0;
            Arena.robotWins = 0;
            for (int i = 0; i < iterations; i++)
            {
                Healer healer = new Healer();
                Archer archer = new Archer();
                arena.Fight(healer, "alex", archer);
            }
            Console.WriteLine($"The Player won {Arena.playerWins} times");
            Console.WriteLine($"The Robot won {Arena.robotWins} times");

            Assert.InRange(Arena.playerWins, iterations/2 - 0.1*iterations , iterations/2 + 0.1 * iterations);
        } 
        [Theory]
        [InlineData(10)]
        [InlineData(100)]
        [InlineData(1000)]
        public void Fight_ShouldBeFairHealerAndAssasin(int iterations)
        {
            Arena arena = new Arena();

            Arena.playerWins = 0;
            Arena.robotWins = 0;
            for (int i = 0; i < iterations; i++)
            {
                Healer healer = new Healer();
                Assasin assasin = new Assasin();
                arena.Fight(healer, "alex", assasin);
            }
            Console.WriteLine($"The Player won {Arena.playerWins} times");
            Console.WriteLine($"The Robot won {Arena.robotWins} times");

            Assert.InRange(Arena.playerWins, iterations/2 - 0.15*iterations , iterations/2 + 0.15 * iterations);
        } 
        [Theory]
        [InlineData(10)]
        [InlineData(100)]
        [InlineData(1000)]
        public void Fight_ShouldBeFairAssasinAndArcher(int iterations)
        {
            Arena arena = new Arena();

            Arena.playerWins = 0;
            Arena.robotWins = 0;
            for (int i = 0; i < iterations; i++)
            {
                Assasin assasin  = new Assasin();
                Archer archer= new Archer();
                arena.Fight(assasin,"alex", archer);
            }
            Console.WriteLine($"The Player won {Arena.playerWins} times");
            Console.WriteLine($"The Robot won {Arena.robotWins} times");

            Assert.InRange(Arena.playerWins, iterations/2 - 0.15*iterations , iterations/2 + 0.15 * iterations);
        } 
       
    }
}
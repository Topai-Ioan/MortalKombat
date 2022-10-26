using Characters;
using Arenas;

namespace MortalKombat
{
    internal class Program
    {
        // functie de reset
        static void Main(string[] args)
        {

            Arena arena = new Arena();
            Console.WriteLine("Hello!");
            Console.WriteLine("Enter your name");

            string? playerName = Console.ReadLine();
            string? characterLetter;

            Console.WriteLine("The Characters are: \nWarrior (W)\nArcher (A)\nHealer (H)\nMage (M)\nAssasin (K)");
            do
            {
                Console.Write($"{playerName} choose character: ");
                characterLetter = Console.ReadLine();

                characterLetter = characterLetter.ToLower();

            } while (PlayerHasValidCharacter(characterLetter) != true);

            // fa player class
            switch (characterLetter)
            {
                case "w":
                    Warrior warrior = new Warrior();
                    Console.WriteLine($"{playerName} chosed Warrior! Great Choise");
                    try
                    {
                        arena.Fight( warrior, playerName, arena.RobotChoise());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Eroare in {nameof(Main)} ex {ex.Message}");
                        Console.WriteLine(ex.StackTrace);
                    }
                    break;
                case "a":
                    Archer archer = new Archer();
                    Console.WriteLine($"{playerName} chosed Archer! Great Choise");
                    arena.Fight( archer, playerName, arena.RobotChoise());
                    break;
                case "h":
                    Healer healer = new Healer();
                    Console.WriteLine($"{playerName} chosed Healer! Great Choise");
                    arena.Fight( healer, playerName, arena.RobotChoise());
                    break;
                case "m":
                    Mage mage = new Mage();
                    Console.WriteLine($"{playerName} chosed Mage! Great Choise");
                    arena.Fight( mage, playerName, arena.RobotChoise());
                    break;
                case "k":
                    Assasin assasin = new Assasin();
                    Console.WriteLine($"{playerName} chosed Assasin! Great Choise");
                    arena.Fight( assasin, playerName, arena.RobotChoise());
                    break;
            }

        }
        public static bool PlayerHasValidCharacter(string choise)
        {
            if (choise == "w")
                return true;
            else if (choise == "a")
                return true;
            else if (choise == "h")
                return true;
            else if (choise == "m")
                return true;
            else if (choise == "k")
                return true;

            return false;
        }
    }

}
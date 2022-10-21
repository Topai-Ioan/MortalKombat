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
            /*string? name = null;
            try
            {
                name = Console.ReadLine();
                if (name == null)
                {
                    throw new ArgumentNullException(nameof(name));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Eroare in {nameof(Main)} ex {ex.Message}");
                Console.WriteLine($"Draga utilizator, te rugam sa introduci un nume valid");
            }*/
            string? name = Console.ReadLine();
            string? characterLetter;

            Console.WriteLine("The Characters are: \nWarrior (W)\nArcher (A)\nHealer (H)\nMage (M)\nAssasin (K)");
            do
            {
                Console.Write($"{name} choose character: ");
                characterLetter = Console.ReadLine();

                characterLetter = characterLetter.ToLower();

            } while (PlayerHasValidCharacter(characterLetter) != true);

            switch (characterLetter)
            {
                case "w":
                    Warrior warrior = new Warrior();
                    Console.WriteLine($"{name} chosed Warrior! Great Choise");
                    try
                    {
                        arena.Fight(warrior, name);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Eroare in {nameof(Main)} ex {ex.Message}");
                        Console.WriteLine(ex.StackTrace);
                    }
                    break;
                case "a":
                    Archer archer = new Archer();
                    Console.WriteLine($"{name} chosed Archer! Great Choise");
                    arena.Fight(archer, name);
                    break;
                case "h":
                    Healer healer = new Healer();
                    Console.WriteLine($"{name} chosed Healer! Great Choise");
                    arena.Fight(healer, name);
                    break;
                case "m":
                    Mage mage = new Mage();
                    Console.WriteLine($"{name} chosed Mage! Great Choise");
                    arena.Fight(mage, name);
                    break;
                case "k":
                    Assasin assasin = new Assasin();
                    Console.WriteLine($"{name} chosed Assasin! Great Choise");
                    arena.Fight(assasin, name);
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
using Characters;
using System.Threading;

namespace Players
{
    public class Player
    {
        public string? Name { get; set; }
        public Character? Character { get; set; }

        public void SetName()
        {
            Console.WriteLine("Enter your name");

            Name = Console.ReadLine();
        }
        public Character? PlayerChoise()
        {
            string? type;
            Console.WriteLine("The Characters are: \nWarrior (W)\nArcher (A)\nHealer (H)\nMage (M)\nAssasin (K)");
            do
            {
                Console.Write($"{Name} choose character: ");
                type = Console.ReadLine();

                type = type?.ToLower();

            } while (PlayerHasValidCharacter(type) != true);

            switch (type)
            {
                case "w":
                    try
                    {
                        Warrior warrior = new Warrior();
                        Console.WriteLine($"{Name} chosed Warrior! Great Choise");
                        return warrior;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Eroare in {nameof(PlayerChoise)} la Warrior ex {ex.Message}");
                        Console.WriteLine(ex.StackTrace);
                    }
                    return null;
                case "a":
                    try
                    {
                        Archer archer = new Archer();
                        Console.WriteLine($"{Name} chosed Archer! Great Choise");
                        return archer;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Eroare in {nameof(PlayerChoise)} la Archer ex {ex.Message}");
                        Console.WriteLine(ex.StackTrace);
                    }
                    return null;

                case "h":
                    try
                    {
                        Healer healer = new Healer();
                        Console.WriteLine($"{Name} chosed Healer! Great Choise");
                        return healer;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Eroare in {nameof(PlayerChoise)} la Healer ex {ex.Message}");
                        Console.WriteLine(ex.StackTrace);
                    }
                    return null;
                   

                case "m":
                    try
                    {
                        Mage mage = new Mage();
                        Console.WriteLine($"{Name} chosed Mage! Great Choise");
                        return mage;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Eroare in {nameof(PlayerChoise)} la Mage ex {ex.Message}");
                        Console.WriteLine(ex.StackTrace);
                    }
                    return null;
                    
                
                case "k":
                    try
                    {
                        Assasin assasin = new Assasin();
                        Console.WriteLine($"{Name} chosed Assasin! Great Choise");
                        return assasin;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Eroare in {nameof(PlayerChoise)} la Assasin ex {ex.Message}");
                        Console.WriteLine(ex.StackTrace);
                    }
                    return null;
                   

                default:
                    return null;
            }
        }
        public bool PlayerHasValidCharacter(string? choise)
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
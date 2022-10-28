using Characters;

namespace Players
{
    public class Player
    {
        public string? Name { get; set; }
        public string? CharacterLetter { get; set; }

        public void SetName()
        {
            Console.WriteLine("Enter your name");

            Name = Console.ReadLine();
        }
        public void ChoseCharacter()
        {
            Console.WriteLine("The Characters are: \nWarrior (W)\nArcher (A)\nHealer (H)\nMage (M)\nAssasin (K)");
            do
            {
                Console.Write($"{Name} choose character: ");
                CharacterLetter = Console.ReadLine();

                CharacterLetter = CharacterLetter.ToLower();

            } while (PlayerHasValidCharacter(CharacterLetter) != true);
        }
        public Character PlayerChoise()
        {
            switch (CharacterLetter)
            {
                case "w":
                    Warrior warrior = new Warrior();
                    Console.WriteLine($"{Name} chosed Warrior! Great Choise");
                    return warrior;
                  /*  try
                    {
                        arena.Fight(warrior, PlayerName, arena.RobotChoise());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Eroare in {nameof(Main)} ex {ex.Message}");
                        Console.WriteLine(ex.StackTrace);
                    }*/
                case "a":
                    Archer archer = new Archer();
                    Console.WriteLine($"{Name} chosed Archer! Great Choise");
                    return archer;

                case "h":
                    Healer healer = new Healer();
                    Console.WriteLine($"{Name} chosed Healer! Great Choise");
                    return healer;

                case "m":
                    Mage mage = new Mage();
                    Console.WriteLine($"{Name} chosed Mage! Great Choise");
                    return mage;
                
                case "k":
                    Assasin assasin = new Assasin();
                    Console.WriteLine($"{Name} chosed Assasin! Great Choise");
                    return assasin;

                default:
                    return null;
            }
        }
        public bool PlayerHasValidCharacter(string choise)
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
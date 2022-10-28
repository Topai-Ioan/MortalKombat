using Characters;
using Arenas;
using Players;

namespace MortalKombat
{
    internal class Program
    {
        // functie de reset
        static void Main(string[] args)
        {

            Arena arena = new Arena();
            Console.WriteLine("Hello!");

            Player player = new Player();
            player.SetName();
            player.ChoseCharacter();

            switch (player.CharacterLetter)
            {
                case "w":
                    Warrior warrior = new Warrior();
                    Console.WriteLine($"{player.Name} chosed Warrior! Great Choise");
                    try
                    {
                        arena.Fight( warrior, player.Name, arena.RobotChoise());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Eroare in {nameof(Main)} ex {ex.Message}");
                        Console.WriteLine(ex.StackTrace);
                    }
                    break;
                case "a":
                    Archer archer = new Archer();
                    Console.WriteLine($"{player.Name} chosed Archer! Great Choise");
                    arena.Fight( archer, player.Name, arena.RobotChoise());
                    break;
                case "h":
                    Healer healer = new Healer();
                    Console.WriteLine($"{player.Name} chosed Healer! Great Choise");
                    arena.Fight( healer, player.Name, arena.RobotChoise());
                    break;
                case "m":
                    Mage mage = new Mage();
                    Console.WriteLine($"{player.Name} chosed Mage! Great Choise");
                    arena.Fight( mage, player.Name, arena.RobotChoise());
                    break;
                case "k":
                    Assasin assasin = new Assasin();
                    Console.WriteLine($"{player.Name} chosed Assasin! Great Choise");
                    arena.Fight( assasin, player.Name, arena.RobotChoise());
                    break;
            }

        }
       
    }

}
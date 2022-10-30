using Characters;
using Arenas;
using Players;
using Robots;

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
            player.Character = player.PlayerChoise();
            Robot robot = new Robot();
            robot.Character = robot.RobotChoise();

            arena.Fight(player, robot);
        }
       
    }

}
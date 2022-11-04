using Characters;
using Players;
using Robots;
using System.ComponentModel;
using System.Numerics;
using System.Xml.Linq;

namespace Arenas
{
    public class Arena
    {
        public static int robotWins;
        public static int playerWins;

        public void Fight( Player player,  Robot robot)
        {
            GetBalanced(ref player, ref robot);
            int numberToStartTurn = WhoIsStarting(player, robot);

           
            int stepForPLayerLevelingUp = 0;
            int stepForRobotLevelingUp = 0;
            double totalDamageDealtByPlayer = 0;
            double totalDamageDealtByRobot = 0;
            int turns = 1;
            while (player?.Character?.IsHPZeroOrLess() == false && robot?.Character?.IsHPZeroOrLess() == false)
            {
                double copieRobotCurrentHP = robot.Character.CurrentHP;
                double copiePlayerCurrentHP = player.Character.CurrentHP;

                if (numberToStartTurn == 1)
                {
                    // player hit first 
                    CharacterTurn(player.Character, robot.Character, player.Name, copieRobotCurrentHP,
                        totalDamageDealtByPlayer, stepForPLayerLevelingUp);
                    if (robot.Character.IsHPZeroOrLess() == true)
                        break;
                    Console.WriteLine();

                    //robot turn        
                    CharacterTurn(robot.Character, player.Character, robot.Name, copiePlayerCurrentHP,
                        totalDamageDealtByRobot, stepForRobotLevelingUp);
                    if (player.Character.IsHPZeroOrLess() == true)
                        break;
                    Console.WriteLine();
                }
                else
                {
                    // robot hit first    
                    CharacterTurn(robot.Character, player.Character, robot.Name, copiePlayerCurrentHP,
                        totalDamageDealtByRobot, stepForRobotLevelingUp);
                    if (player.Character.IsHPZeroOrLess() == true)
                        break;
                    Console.WriteLine();

                    // player turn        
                    CharacterTurn(player.Character, robot.Character, player.Name, copieRobotCurrentHP,
                        totalDamageDealtByPlayer, stepForPLayerLevelingUp);
                    if (robot.Character.IsHPZeroOrLess() == true)
                        break;
                    Console.WriteLine();
                }

                turns++;
            }
            if (player?.Character?.IsHPZeroOrLess() == true)
            {
                Console.WriteLine($"Sorry {player?.Name}, you lost the duel");
                robotWins++;
            }
            else if (robot?.Character?.IsHPZeroOrLess() == true)
            {
                Console.WriteLine($"congratulation {player?.Name}, you won!");
                playerWins++;
            }
            else
                Console.WriteLine("DRAW");
        }
        public int WhoIsStarting(Player player, Robot robot)
        {
            Random random = new Random((int)(DateTime.Now.Ticks));

            int numberToStartTurn = random.Next(1, 3);
            if (numberToStartTurn == 1)
                Console.WriteLine($"First Turn: {player.Name}");
            else
                Console.WriteLine($"First Turn: {robot.Name}");
            Console.WriteLine();
            return numberToStartTurn;
        }
        public void GetBalanced(ref Player player, ref Robot robot)
        {
            if(player.Character is Warrior)
            {
                if(robot.Character is Archer)
                {
                    robot.Character.ExtraDamage = 3;
                    player.Character.AttackDamage = 7;
                }
                else if (robot.Character is Assasin)
                {
                    player.Character.ExtraDamage = 2;
                    player.Character.AttackDamage = 9.9;
                } 
                else if (robot.Character is Healer)
                {
                    player.Character.AttackDamage = 8.3;
                }
                else if (robot.Character is Mage)
                {
                    player.Character.AttackDamage = 9.6;
                }
            }
            if(player.Character is Mage)
            {
                if(robot.Character is Archer)
                {
                    player.Character.AttackDamage = 8;
                }
                else if(robot.Character is Assasin)
                {
                    player.Character.Armor = 8.5;
                }
                else if(robot.Character is Healer)
                {
                    robot.Character.ExtraDamage = 2;
                    player.Character.AttackDamage = 6;
                    player.Character.Armor = 2;
                }
            }
            if (player.Character is Healer)
            {
                if (robot.Character is Archer)
                {
                    player.Character.Armor = 6.5;
                    player.Character.Passive = 7;
                }
                else if (robot.Character is Assasin)
                {
                    robot.Character.ExtraDamage = 3;
                    player.Character.AttackDamage = 10;
                    player.Character.Armor = 6.5;
                    player.Character.Passive = 8;
                }
                else if (robot.Character is Mage)
                {
                    player.Character.ExtraDamage = 2;
                }
                else if (robot.Character is Warrior)
                {
                    player.Character.Passive = 6;
                    player.Character.AttackDamage = 7.5;
                    player.Character.Armor = 4.25;
                }
            }
            if (player.Character is Assasin)
            {
                if (robot.Character is Archer)
                {
                    player.Character.ExtraDamage = 3;
                    player.Character.Armor = 2;
                    player.Character.AttackDamage = 15;
                }
                else if (robot.Character is Healer)
                {
                    player.Character.ExtraDamage = 3;
                }
                else if (robot.Character is Warrior)
                {
                    robot.Character.ExtraDamage = 2;
                    player.Character.AttackDamage = 25;
                    player.Character.Armor = 7;
                }
            } 
            if (player.Character is Archer)
            {

                if (robot.Character is Assasin)
                {
                    robot.Character.ExtraDamage = 3;
                    player.Character.Armor = 17;
                }
                else if (robot.Character is Warrior)
                {
                    player.Character.ExtraDamage = 2;
                }
            }
        }
        public void CharacterTurn(Character character, Character opponent, string? name, 
            double opponentCurentHP, double totalDamage, int step)
        {
            character.GetPassive();
            character.Hit(ref opponent);
            Notifier notifier = new Notifier();
            notifier.GettingHit += OnGettingHit(this, EventArgs.Empty, name, opponentCurentHP, opponent, character.ExtraDamage);

            CalculateTotalDamage(ref totalDamage, opponentCurentHP, opponent, character.ExtraDamage);
            character.TryToLevelUp(ref step, totalDamage, name);

            Console.WriteLine();
        }
        public void CalculateTotalDamage(ref double totalDamage, double opponentCurrentHp, Character opponentCharacter, double damage)
        {
            totalDamage = totalDamage + opponentCurrentHp - opponentCharacter.CurrentHP + damage;
        }

        public Notifier.GettingHitEventHandler OnGettingHit(object source, EventArgs e, string? name, double opponentCurrentHp, Character opponent,  double damage)
        {
            if (damage != 0)
            {
                Console.WriteLine($"{name} dealt {opponentCurrentHp - opponent.CurrentHP:N2} + {damage}  extra damage");
            }
            else
            {
                Console.WriteLine($"{name} dealt {(opponentCurrentHp - opponent.CurrentHP):N2}");
            }
            return null;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Characters
{
    public class Healer : Character
    {

        public Healer()
        {
            Type = "healer";
            MaxHP = 70;
            CurrentHP = 70;
            AttackDamage = 7;
            Armor = 2.15;
            Passive = 6; // heals x hp
        }
        public override void GetPassivesAndCounters(Character character, ref double extraDamage)
        {
            switch (character.Type)
            {
                case "archer":
                    Armor = 6.5;
                    Passive = 7;
                    break;
                case "assasin":
                    CurrentHP -= 3; // assasin counters healer
                    Armor = 6.5;
                    Passive = 11;
                    AttackDamage = 10;
                    break;
                case "healer":
                    break;
                case "mage":
                    extraDamage = 2;
                    break;
                case "warrior":
                    AttackDamage = 7.5;
                    Armor = 4.25;
                    Passive = 6;
                    break;
            }
            CurrentHP += Passive;
            CheckCurrentAndMaxHP();
            Console.WriteLine($"Healer healed {Passive} HP");
        }
    }
}

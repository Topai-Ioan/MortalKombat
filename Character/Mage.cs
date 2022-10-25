using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Characters
{
    public class Mage : Character
    {
        public Mage()
        {
            Type = "mage";
            MaxHP = 82.5;
            CurrentHP = 82.5;
            AttackDamage = 13;
            Armor = 7;
            Passive = 1; // permanetly increasing damage by 1
        }
        public override void GetPassivesAndCounters(Character character, ref double extraDamage)
        {
            CheckCurrentAndMaxHP();
            AttackDamage += Passive;
            switch (character.Type)
            {
                case "archer":
                    AttackDamage = 12;
                    break;
                case "assasin":
                    Armor = 8.5;
                    break;
                case "healer":
                    CurrentHP -= 2; // healer counter mage
                    AttackDamage = 13;
                    Armor = 6;
                    break;
                case "mage":
                    break;
                case "warrior":
                    break;
            }

        }
    }
}

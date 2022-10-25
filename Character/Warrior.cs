using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Characters
{
    public class Warrior : Character
    {

        public Warrior()
        {
            Type = "warrior";
            MaxHP = 100;
            CurrentHP = 100;
            AttackDamage = 10;
            Armor = 10;
            Passive = 1.25; //permanetly incresing armor by 10%
        }
        public override void GetPassivesAndCounters(Character character, ref double extraDamage)
        {
            CheckCurrentAndMaxHP();
            Armor += Passive;
            switch (character.Type)
            {
                case "archer":
                    CurrentHP -= 3; // archer counters warrior
                    AttackDamage = 10.2;
                    break;
                case "assasin":
                    extraDamage = 2;
                    break;
                case "healer":
                    AttackDamage = 9.9;
                    break;
                case "mage":
                    AttackDamage = 9.7;
                    break;
                case "warrior":
                    break;
            }

        }

    }

}


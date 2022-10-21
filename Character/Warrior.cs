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


    }

}


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

    }
}

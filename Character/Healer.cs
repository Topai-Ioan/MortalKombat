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
    }
}

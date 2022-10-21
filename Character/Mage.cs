using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Characters
{
    public class Mage : ICharacter
    {
        public string Type { get; set; }
        public double MaxHP { get; set; }
        public double CurrentHP { get; set; }
        public double AttackDamage { get; set; }
        public double Armor { get; set; }
        public double Passive { get; set; }
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

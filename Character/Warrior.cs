using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Characters
{
    public class Warrior : ICharacter
    {
        public string Type { get; set; }
        public double MaxHP { get; set; }
        public double CurrentHP { get; set; }
        public double AttackDamage { get; set; }
        public double Armor { get; set; }
        public double Passive { get; set; }
        public Warrior()
        {
            Type = "warrior";
            MaxHP = 100;
            CurrentHP = 100;
            AttackDamage = 10;
            Armor = 10;
            Passive = 1; //permanetly incresing armor by 10%
        }
    }

}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Characters
{
    public class Healer : ICharacter
    {
        public string Type { get; set; }
        public double MaxHP { get; set; }
        public double CurrentHP { get; set; }
        public double AttackDamage { get; set; }
        public double Armor { get; set; }
        public double Passive { get; set; }
        public Healer()
        {
            Type = "healer";
            MaxHP = 90;
            CurrentHP = 90;
            AttackDamage = 7;
            Armor = 3;
            Passive = 5; // heals 5hp
        }
    }
}

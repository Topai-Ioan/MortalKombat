namespace Characters
{
    public class Assasin : ICharacter
    {
        public string Type { get; set; }
        public double MaxHP { get; set; }
        public double CurrentHP { get; set; }
        public double AttackDamage { get; set; }
        public double Armor { get; set; }
        public double Passive { get; set; }
        public Assasin()
        {
            Type = "assasin";
            MaxHP = 70;
            CurrentHP = 70;
            AttackDamage = 13;
            Armor = 1;
            Passive = 20; // 5 % of +20 damage
        }


    }
}

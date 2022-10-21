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
            MaxHP = 80;
            CurrentHP = 80;
            AttackDamage = 20;
            Armor = 5;
            Passive = 20; // 10 % of +20 damage
        }


    }
}

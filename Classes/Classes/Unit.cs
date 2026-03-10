namespace Classes
{
    public class Unit
    {   //Открытые свойства
        private float _health;

        public string Name { get; }

        public float Health => _health;

        public int Damage { get; }

        public float Armor { get; }

        //Конструкторы
        public Unit() : this(name: "Unknown Unit")
        {
        }

        public Unit(string name)
        {
            Name = name;
            _health = 100f;
            Damage = 5;
            Armor = 0.6f;
        }

        public float GetRealHealth() 
        {
            return Health * (1f + Armor);
        }

        public bool SetDamage(int value)
        {
            _health = _health - value * Armor;

            if (_health <= 0f)
            {
                return true;
            }

            return false;
        }
    }
}

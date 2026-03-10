using System;

namespace Memory
{
    public class Unit
    {   //Открытые свойства
        private float _health;

        public string Name { get; }

        public float Health => _health;

        public Interval Damage { get; }

        public float Armor { get; }

        //Конструкторы
        public Unit() : this("Unknown Unit", 0, 5)
        {
        }

        public Unit(string name) : this(name, 0, 5)
        {
        }

        public Unit(string name, int minDamage, int maxDamage)
        {
            Name = name;
            _health = 100f;
            Damage = new Interval(minDamage, maxDamage);
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

using System;

namespace Memory
{
    public class Weapon
    {   //Открытые свойства:
        public string Name { get; }

        public Interval Damage { get; private set; }

        public float Durability { get; }

        //Конструкторы:
        public Weapon(string name)
        {
            Name = name;
            Durability = 1f;
            Damage = new Interval(1, 10);
        }

        public Weapon(string name, int minDamage, int maxDamage) : this(name)
        {
            Damage = new Interval(minDamage, maxDamage);
        }

        public int GetDamage()
        {
            return (int)Damage.Get();
        }
    }
}

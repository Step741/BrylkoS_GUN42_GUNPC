using System;

namespace Memory
{
    public struct Room
    {
        public Unit Unit;
        public Weapon Weapon;

        //Конструктор
        public Room(Unit unit, Weapon weapon)
        {
            Unit = unit;
            Weapon = weapon;
        }
    }
}

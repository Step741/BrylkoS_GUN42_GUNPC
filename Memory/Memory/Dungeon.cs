using System;

namespace Memory
{
    public class Dungeon
    {
        private Room[] rooms;

        //Конструктор
        public Dungeon()
        {
            rooms = new Room[]
            {
            new Room(new Unit("Knight"), new Weapon("Sword", 5, 8)),
            new Room(new Unit("Mage"), new Weapon("Staff", 6, 10)),
            new Room(new Unit("Goblin"), new Weapon("Spear", 3, 7)),
            new Room(new Unit("Demon"), new Weapon("Demonic Sword", 6, 9)),
            new Room(new Unit("Thief"), new Weapon("Dagger", 2, 6))
            };
        }

        //Метод
        public void ShowRooms()
        {
            for (int i = 0; i < rooms.Length; i++)
            {
                var room = rooms[i];

                Console.WriteLine("Unit of room: " + room.Unit.Name);
                Console.WriteLine("Weapon of room: " + room.Weapon.Name);
                Console.WriteLine("-");
            }
        }
    }
}

using GamePrototype.Items.EquipItems;
using GamePrototype.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePrototype.Utils
{
    //Задание 3 - Сложное подземелье
    public class HardUnitFactory : UnitFactory
    {
        public override Unit CreatePlayer(string name)
        {
            var player = new Player(name, 25, 25, 5);

            player.AddItemToInventory(new Weapon(8, 10, "Rusty Sword"));

            return player;
        }

        public override Unit CreateGoblinEnemy()
        {
            return new Goblin("Strong Goblin", 30, 30, 6);
        }
    }
}

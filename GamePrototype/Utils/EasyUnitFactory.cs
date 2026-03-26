using GamePrototype.Items.EconomicItems;
using GamePrototype.Items.EquipItems;
using GamePrototype.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePrototype.Utils
{
    //Задание 3 - Легкое подземелье
    public class EasyUnitFactory : UnitFactory
    {
        public override Unit CreatePlayer(string name)
        {
            var player = new Player(name, 40, 40, 8);

            player.AddItemToInventory(new Weapon(15, 20, "Sword"));
            player.AddItemToInventory(new Armour(15, 20, "Armour"));
            player.AddItemToInventory(new HealthPotion("Potion"));

            return player;
        }

        public override Unit CreateGoblinEnemy()
        {
            return new Goblin("Weak Goblin", 12, 12, 1);
        }
    }
}

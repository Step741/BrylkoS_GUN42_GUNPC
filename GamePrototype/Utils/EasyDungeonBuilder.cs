using GamePrototype.Dungeon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePrototype.Utils
{
    //Задание 3 - Легкое подземелье
    public class EasyDungeonBuilder : DungeonBuilder
    {
        private UnitFactory _factory;

        public EasyDungeonBuilder(UnitFactory factory)
        {
            _factory = factory;
        }

        public override DungeonRoom BuildDungeon()
        {
            var enter = new DungeonRoom("Enter");

            var monsterRoom =
                new DungeonRoom("Monster", _factory.CreateGoblinEnemy());

            var final = new DungeonRoom("Final");

            enter.TrySetDirection(Direction.Forward, monsterRoom);

            monsterRoom.TrySetDirection(Direction.Forward, final);

            return enter;
        }
    }
}

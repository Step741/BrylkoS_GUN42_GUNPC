using GamePrototype.Dungeon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePrototype.Utils
{
    //Задание 3 - Сложное подземелье
    public class HardDungeonBuilder : DungeonBuilder
    {
        private UnitFactory _factory;

        public HardDungeonBuilder(UnitFactory factory)
        {
            _factory = factory;
        }

        public override DungeonRoom BuildDungeon()
        {
            var enter = new DungeonRoom("Enter");

            var monster1 =
                new DungeonRoom("Monster1", _factory.CreateGoblinEnemy());

            var monster2 =
                new DungeonRoom("Monster2", _factory.CreateGoblinEnemy());

            var final = new DungeonRoom("Final");

            enter.TrySetDirection(Direction.Forward, monster1);

            monster1.TrySetDirection(Direction.Forward, monster2);

            monster2.TrySetDirection(Direction.Forward, final);

            return enter;
        }
    }
}

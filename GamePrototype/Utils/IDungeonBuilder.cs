using GamePrototype.Dungeon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePrototype.Utils
{
    //Задание 3 - Абстракция
    public abstract class DungeonBuilder
    {
        public abstract DungeonRoom BuildDungeon();
    }
}

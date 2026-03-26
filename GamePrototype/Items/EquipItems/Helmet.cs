using GamePrototype.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePrototype.Items.EquipItems
{
    //Задание 2 - Создал новый класс экипировки
    public sealed class Helmet : EquipItem
    {
        public uint Defence { get; }

        public Helmet(uint defence, uint durability, string name)
            : base(durability, name)
        {
            Defence = defence;
        }

        public override EquipSlot Slot => EquipSlot.Helmet;
    }
}

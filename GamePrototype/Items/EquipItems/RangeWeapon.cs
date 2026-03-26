using GamePrototype.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePrototype.Items.EquipItems
{
    //Задание 2 - Создал новый класс экипировки
    public sealed class RangeWeapon : EquipItem
    {
        public uint Damage { get; }

        public RangeWeapon(uint damage, uint durability, string name)
            : base(durability, name)
        {
            Damage = damage;
        }

        public override EquipSlot Slot => EquipSlot.RangeWeapon;
    }
}

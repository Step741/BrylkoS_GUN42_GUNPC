using GamePrototype.Items.EconomicItems;
using GamePrototype.Items.EquipItems;
using GamePrototype.Utils;
using System.Text;

namespace GamePrototype.Units
{
    public sealed class Player : Unit
    {
        private readonly Dictionary<EquipSlot, EquipItem> _equipment = new();

        public Player(string name, uint health, uint maxHealth, uint baseDamage) : base(name, health, maxHealth, baseDamage)
        {            
        }
        //Задание 2 - Добавил использование RangeWeapon если нет Weapon
        public override uint GetUnitDamage()
        {
            if (_equipment.TryGetValue(EquipSlot.Weapon, out var item) && item is Weapon weapon)
            {
                return BaseDamage + weapon.Damage;
            }

            if (_equipment.TryGetValue(EquipSlot.RangeWeapon, out var rItem) && rItem is RangeWeapon rangeWeapon)
            {
                return BaseDamage + rangeWeapon.Damage;
            }

            return BaseDamage;
        }

        public override void HandleCombatComplete()
        {
            var items = Inventory.Items;
            for (int i = 0; i < items.Count; i++) 
            {
                if (items[i] is EconomicItem economicItem) 
                {
                    UseEconomicItem(economicItem);
                    Inventory.TryRemove(items[i]);
                }
            }
        }
        //Задание 2 - Сделал замену экипировки
        public override void AddItemToInventory(Item item)
        {
            if (item is EquipItem equipItem)
            {
                if (_equipment.ContainsKey(equipItem.Slot))
                {
                    Console.WriteLine($"Slot {equipItem.Slot} already has equipment.");
                    Console.WriteLine("Replace? Yes / No");

                    var input = Console.ReadLine();

                    if (input?.ToLower() == "yes")
                    {
                        Console.WriteLine($"{_equipment[equipItem.Slot].Name} replaced with {equipItem.Name}");

                        _equipment[equipItem.Slot] = equipItem;
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Item added to inventory");
                        base.AddItemToInventory(item);
                        return;
                    }
                }
                else
                {
                    _equipment.Add(equipItem.Slot, equipItem);

                    Console.WriteLine($"{equipItem.Name} equipped");

                    return;
                }
            }

            base.AddItemToInventory(item);
        }

        private void UseEconomicItem(EconomicItem economicItem)
        {
            if (economicItem is HealthPotion healthPotion) 
            {
                Health += healthPotion.HealthRestore;
            }
            //Задание 1 - Реализовал Grindstone
            if (economicItem is Grindstone)
            {
                if (_equipment.TryGetValue(EquipSlot.Weapon, out var item) && item is Weapon weapon)
                {
                    weapon.Repair(5);
                }
            }
        }
        //Задание 2 - Добавил защиту Helmet
        protected override uint CalculateAppliedDamage(uint damage)
        {
            if (_equipment.TryGetValue(EquipSlot.Armour, out var item) && item is Armour armour)
            {
                damage -= (uint)(damage * (armour.Defence / 100f));
            }

            if (_equipment.TryGetValue(EquipSlot.Helmet, out var hItem) && hItem is Helmet helmet)
            {
                damage -= (uint)(damage * (helmet.Defence / 100f));
            }

            return damage;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine(Name);
            builder.AppendLine($"Health {Health}/{MaxHealth}");
            builder.AppendLine("Loot:");
            var items = Inventory.Items;
            for (int i = 0; i < items.Count; i++)
            {
                builder.AppendLine($"[{items[i].Name}] : {items[i].Amount}");
            }
            return builder.ToString();
        }
        //Задание 1 - добавил потерю прочности броне
        protected override void DamageReceiveHandler()
        {
            if (_equipment.TryGetValue(EquipSlot.Armour, out var item) && item is Armour armour)
            {
                armour.ReduceDurability(1);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1
{
    class Item
    {
        //allows appearance of items on shop list and player list
        public int ItemId;
        public string ItemName;
        public int Cost;

        public Item()
        {

        }

        public Item(int itemID, string itemName, int cost)
        {
            ItemId = itemID;
            ItemName = itemName;
            Cost = cost;
        }

        virtual public void DisplayItemData()
        {
            Console.WriteLine(ItemName + ", worth " + Cost + " gold.");
        }
    }

    class Potion : Item
    {
        int RestoreAmount = 50;

        public Potion()
        {

        }

        public Potion(int _ItemId, string _ItemName, int _Cost, int _RestoreAmount)
        {
            ItemId = _ItemId;
            ItemName = _ItemName;
            Cost = _Cost;
            RestoreAmount = _RestoreAmount;
        }

        public override void DisplayItemData()
        {
            //base.DisplayItemData();
            Console.WriteLine(ItemName + ", worth " + Cost + " gold and restores " + RestoreAmount + " health on use.");
        }
    }

    class Sword : Item
    {
        int Damage = 100;
        int Durability = 10;

        public Sword()
        {

        }

        public Sword(int _ItemId, string _ItemName, int _Cost, int _Damage, int _Durability)
        {
            ItemId = _ItemId;
            ItemName = _ItemName;
            Cost = _Cost;
            Damage = _Damage;
            Durability = _Durability;
        }

        public override void DisplayItemData()
        {
            //base.DisplayItemData();
            Console.WriteLine(ItemName + ", worth " + Cost + " gold and does " + Damage + " damage and has " + Durability + " left.");
        }
    }
}

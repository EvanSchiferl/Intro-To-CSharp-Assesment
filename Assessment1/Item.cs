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
    }
}

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1
{
    class Program
    {
        static void Main(string[] args)
        {
            string command;
            int gold = 100; //player starting gold

            List<Item> shopInventory = new List<Item>();
            List<Item> playerInventory = new List<Item>();

            Item testItem1 = new Item();
            Item testItem2 = new Item(10, "Test Item", 999);
            Item testItem3 = testItem2;

            while (true)
            {
                Console.WriteLine("Would you like to (quest), (shop), check your (inventory), or check your (coinpurse)?");

                command = Console.ReadLine();
                command = command.ToLower();

                if (command == "inventory")
                {
                    using (StreamReader sr = new StreamReader("Inventory.csv")) //player inv
                    {
                        sr.ReadLine();

                        while (!sr.EndOfStream)
                        {
                            string Line = sr.ReadLine();
                            string[] Values = Line.Split(',');

                            Item tmpItem = new Item();

                            tmpItem.ItemId = int.Parse(Values[0]);
                            tmpItem.ItemName = Values[1];
                            tmpItem.Cost = int.Parse(Values[2]);
                            shopInventory.Add(tmpItem);
                        }

                        foreach (Item it in playerInventory)
                            Console.WriteLine(it.ItemId + ": " + it.ItemName);
                    }
                }

                if (command == "coinpurse")
                    Console.WriteLine("Gold: " + gold);

                if (command == "shop")
                {
                    Console.WriteLine("MERCHANT: Welcome to my shop! What is your name?");

                    string name = Console.ReadLine();

                    Console.WriteLine("MERCHANT: Greetings, " + name + ". What would you like to buy?");

                    if (shopInventory.Count == 0)
                    {
                        using (StreamReader sr = new StreamReader("Inventory.csv")) //shop list
                        {
                            sr.ReadLine();

                            while (!sr.EndOfStream)
                            {
                                string Line = sr.ReadLine();
                                string[] Values = Line.Split(',');
                                Item tmpItem = new Item();
                                tmpItem.ItemId = int.Parse(Values[0]);
                                tmpItem.ItemName = Values[1];
                                tmpItem.Cost = int.Parse(Values[2]);
                                shopInventory.Add(tmpItem);
                            }

                            sr.Close();
                        }
                    }

                    for (int IDX = 0; IDX < shopInventory.Count; IDX++)
                        Console.WriteLine(IDX + 1 + ": " + shopInventory[IDX].ItemName + ", " + shopInventory[IDX].Cost + "g");

                    Console.WriteLine("Gold: " + gold);
                    Console.WriteLine("Select item number (1-5) to purchase, or (leave) the store");

                    command = Console.ReadLine();

                    if (command == "leave")
                        Console.WriteLine("You leave the shop.");

                    if (int.TryParse(command, out int indexOfItemChosen))
                    {
                        //indexOfItemChosen = item player wants to buy
                        if (gold >= shopInventory[indexOfItemChosen - 1].Cost)
                        {
                            gold -= shopInventory[indexOfItemChosen - 1].Cost;
                            Console.WriteLine("MERCHANT: Thank you for your business!");

                            playerInventory.Add(shopInventory[indexOfItemChosen - 1]);
                            shopInventory.RemoveAt(indexOfItemChosen - 1);
                        } else Console.WriteLine("You don't have enough gold!");
                    }
                }

                if (command == "quest")
                {
                    Random random = new Random();

                    int questNumber = random.Next(0, 5);
                    string[] Quests = {"You clean a cellar of rats for a small fee! (10 Gold)", "You've slain a bandit and looted their pack! (25 Gold)", "You clear out goblins from a local mine and are rewarded! (50 Gold)",
                                       "You decimated a nearby bandit camp, leaving with newfound loot! (100 Gold)", "You fell a dragon and are greatly rewarded by the King! (200 Gold)"};
                    int[] Rewards = { 10, 25, 50, 100, 200 };

                    Console.WriteLine(Quests[questNumber]);

                    gold += Rewards[questNumber];
                }
            }
        }
    }
}
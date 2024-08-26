using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Assignment5
{
    public class Inventory
    {
        // The dictionary items consist of the item and the quantity
        private Dictionary<Item, int> items;

        public int AvailableSlots
        {
            get
            {
                return availableSlots;
            }
        }
        public int MaxSlots
        {
            get
            {
                return maxSlots;
            }
        }

        // The available slots to add item, once it's 0, you cannot add any more items.
        private int availableSlots;

        // The max available slots which is set only in the constructor.
        private int maxSlots;
        public Inventory(int slots)
        {
            maxSlots = slots;
            availableSlots = maxSlots;

            // Initialize the items dictionary
            items = new Dictionary<Item, int>();
        }

        /// <summary>
        /// Removes all the items, and restore the original number of slots.
        /// </summary>
        public void Reset()
        {
            items.Clear();
            availableSlots = maxSlots;
        }

        /// <summary>
        /// Removes the item from the items dictionary if the count is 1 otherwise decrease the quantity.
        /// </summary>
        /// <param name="name">The item name</param>
        /// <param name="found">The item if found</param>
        /// <returns>True if you find the item, and false if it does not exist.</returns>
        public bool TakeItem(string name, out Item found)
        {
            var result = items.FirstOrDefault(pair => pair.Key.Name == name);

            if (result.Key != null)
            {
                items[result.Key]--;

                if (items[result.Key] <= 0)
                {
                    items.Remove(result.Key);
                    availableSlots++;
                }

                found = result.Key;
                return true;
            }
            else
            {
                found = null;
                return false;
            }
        }

        /// <summary>
        /// Checks if there is space for a unique item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool AddItem(Item item)
        {
            if (availableSlots <= 0)
            {
                return false;
            }

            if (items.ContainsKey(item))
            {
                items[item]++;
            }
            else
            {
                items.Add(item, 1);
                availableSlots--;
            }

            return true;
        }

        /// <summary>
        /// Iterates through the dictionary and create a list of all the items.
        /// </summary>
        /// <returns></returns>
        public List<Item> ListAllItems()
        {
            List<Item> allItems = new List<Item>();

            foreach (var pair in items)
            {
                for (int i = 0; i < pair.Value; i++)
                {
                    allItems.Add(pair.Key);
                }
            }

            return allItems;
        }
    }
}

using System;
using System.Collections.Generic;

namespace Assignment5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Adventure of Assignment 5!");

            // Create Inventory
            Inventory inventory = new Inventory(5);

            // Create two items
            Item sword = new Item("Sword", 1, ItemGroup.Equipment);
            Item potion = new Item("Potion", 2, ItemGroup.Consumable);

            inventory.AddItem(sword);
            inventory.AddItem(potion);

            // Verify the number of items in the inventory
            List<Item> allItems = inventory.ListAllItems();
            Console.WriteLine($"The inventory has {allItems.Count} items.");
        }
    }
}

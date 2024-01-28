using System;

public class Player
{

    public string Name { get; private set; }

    public Inventory Inventory { get; private set; }

    public Player(string name, List<Item> inventoryItems)
    {
        Name = name;
        Inventory = new Inventory();

        for (int i = 0; i < inventoryItems.Count; i++)
        {
            Inventory.AddItem(inventoryItems[i]);
        }
    }

    public void TakeItem(Item item)
    {
        Inventory.AddItem(item);
    }

    public void CheckInventory()
    {
        for (int i = 0; i < Inventory.Items.Count; i++)
        {
            Console.WriteLine($"You have a {Inventory.Items[i]}");
        }
    }
}
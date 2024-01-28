using System;
using System.Numerics;

public class Location
{
    #region VARIABLES

    public string Name { get; private set; }
    public Vector2 Coordinates { get; private set; }
    public List<Item> ItemsOnLocation { get; private set; }


    #endregion

    #region CONSTRUCTOR

    public Location(string locationName, Vector2 coordinates, List<Item> itemsOnLocation)
    {
        Name = locationName;
        Coordinates = coordinates;
        ItemsOnLocation = itemsOnLocation;
    }
    public Location(string locationName, Vector2 coordinates)
    {
        Name = locationName;
        Coordinates = coordinates;
        ItemsOnLocation = new List<Item>();
    }
    #endregion

    #region METHODS
    public void RemoveItem(Item item)
    {
        ItemsOnLocation.Remove(item);
    }

    #endregion
}

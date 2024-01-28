using System;
using System.Numerics;
using System.ComponentModel;
using System.Diagnostics;
using DGD203_Final2;

public class Map
{
    private Game _theGame;

    private Vector2 coordinates;
    private int[] widthBoundaries;
    private int[] heightBoundaries;
    public bool hasRiddle=false;    
    public bool hasNote = false;


    private Location[] _locations;
    public Map(Game game, int width, int height)
    {
        _theGame = game;

        int widthBoundary = (width - 1) / 2;

        widthBoundaries = new int[2];
        widthBoundaries[0] = -widthBoundary;
        widthBoundaries[1] = widthBoundary;

        int heightBoundary = (height - 1) / 2;

        heightBoundaries = new int[2];
        heightBoundaries[0] = -heightBoundary;
        heightBoundaries[1] = heightBoundary;

        coordinates = new Vector2(0, 0);
        GenerateLocations();

        Console.WriteLine($"Created map with size {width}x{height}");
    }


    public Vector2 GetCoordinates()
    {
        return coordinates;
    }

    public void SetCoordinates(Vector2 newCoordinates)
    {
        coordinates = newCoordinates;
    }
    public void MovePlayer(int x, int y)
    {
        int newXcoordinate = (int)coordinates[0] + x;
        int newYcoordinate = (int)coordinates[1] + y;

        if (!CanMoveTo(newXcoordinate, newYcoordinate))
        {
            Console.WriteLine("You can't go that way");
            return;
        }

        coordinates[0] = newXcoordinate;
        coordinates[1] = newYcoordinate;

        CheckForLocation(coordinates);
    }

    private bool CanMoveTo(int x, int y)
    {
        return !(x < widthBoundaries[0] || x > widthBoundaries[1] || y < heightBoundaries[0] || y > heightBoundaries[1]);

    }
    private void GenerateLocations()
    {
        _locations = new Location[2];

        Vector2 someoneLocation = new Vector2(2, 1);
        List<Item> someoneItems = new List<Item>();
        someoneItems.Add(Item.Riddle);
        Location someone = new Location("Someone", someoneLocation, someoneItems);
        _locations[0] = someone;

        Vector2 drawerLocation = new Vector2(-2, 2);
        List<Item> drawerItems = new List<Item>();
        drawerItems.Add(Item.Note);
        Location drawer = new Location("drawer", drawerLocation, drawerItems);
        _locations[1] = drawer;
    }
    public void CheckForLocation(Vector2 coordinates)
    {
        Console.WriteLine($"You are now standing on {coordinates[0]},{coordinates[1]}");
        if (IsOnLocation(coordinates, out Location location))
        {
            if (HasItem(location))
            {
                Console.WriteLine($"There is a {location.ItemsOnLocation[0]} here");
            }
        }
    }

    private bool IsOnLocation(Vector2 coords, out Location foundLocation)
    {
        for (int i = 0; i < _locations.Length; i++)
        {
            if (_locations[i].Coordinates == coords)
            {
                foundLocation = _locations[i];
                return true;
            }
        }

        foundLocation = null;
        return false;
    }
    private bool HasItem(Location location)
    {
        return location.ItemsOnLocation.Count != 0;
    }
    public void TakeItem(Location location)
    {

    }
    public void TakeItem(Player player, Vector2 coordinates)
    {
        if (IsOnLocation(coordinates, out Location location))
        {
            if (HasItem(location))
            {
                Item itemOnLocation = location.ItemsOnLocation[0];

                player.TakeItem(itemOnLocation);
                location.RemoveItem(itemOnLocation);

                Console.WriteLine($"You took the {itemOnLocation}");

                return;
            }
        }

        Console.WriteLine("There is nothing to take here!");
    }
    public void ReadCmd()
    {
        Console.WriteLine("If you want to read note type 'read note' if you want to read riddle'read riddle'. ");
        
    }
    public void readNote()
    {
        if(hasNote=true) 
        {
        ShowNoteMessage();
        }
        else {
            Console.WriteLine("You don't have a note.");
                }
    }
    public void readRiddle()
    {
        if (hasRiddle = true)
        {
            ShowRiddleMessage();
        }
        else {
            Console.WriteLine("You don't have a riddle.");
                }
    }
    static void ShowRiddleMessage()
    {
        Console.WriteLine("What is the best Shrek movie? 1,2 or 3?");
    }
    static void ShowNoteMessage()
    {
        Console.WriteLine("3 maybe?");
    }
    private void TakeItem(Item item)
    {
        if (item == Item.Note)
        {
            hasNote = true; // hasNote durumunu güncelle
        }
        else if (item == Item.Riddle)
        {
            hasRiddle = true; // hasRiddle durumunu güncelle
        }
    }
    public void RemoveItemFromLocation(Item item)
    {
        for (int i = 0; i <_locations.Length; i++)
        {
            if (_locations[i].ItemsOnLocation.Contains(item))
            {
                _locations[i].RemoveItem(item);
            }
        }
    }
}

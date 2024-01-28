using System.Data;
using System.IO;
using System.Numerics;

namespace DGD203_Final2;


public class Game
{
    private string PlayerName;

    private const int defaultMapWidth = 5;
    private const int defaultMapHeight = 5;
    public Player Player { get; private set; }
    private List<Item> _loadedItems;

    private bool gameRunning;

    public Map gameMap;

    private string playerInput;

    private Location[] _locations;
    


    public void StartGame(Game gameInstance)
    {
        CreateNewMap();
        LoadGame();
        CreatePlayer();
        InitializeGameConditions();
        gameRunning = true;
        StartGameLoop();

    }
    private void CreateNewMap()
    {
        gameMap = new Map(this, defaultMapWidth, defaultMapHeight);

    }
    private void CreatePlayer()
    {
        if (PlayerName == null)
        {
            GetPlayerName();
        }

        if (_loadedItems == null)
        {
            _loadedItems = new List<Item>();
        }

        Player = new Player(PlayerName, _loadedItems);
    }
    private void GetPlayerName()
    {
        Console.WriteLine("Hey, did you finally wake up?");
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("To continue, press Enter. (If there is an asterisk (*) at the beginning of the text, please enter the requested information.)");
        Console.ReadKey();
        Console.ResetColor();

        Console.WriteLine("Welcome to the most realistic game in the world; everything you've experienced so far was just a dream. The real reality is now.");
        Console.ReadKey();
        Console.WriteLine("I'm just joking. When we arrived, you were sleeping, and we didn't want to wake you up, but we have some questions.");
        Console.ReadKey();
        Console.WriteLine("Who are you, and why are you in our house?");
        Console.ReadKey();
        Console.WriteLine("Okay, calm down. You just woke up, and considering you're in our house right now, your mind may not be clear.");
        Console.ReadKey();
        Console.WriteLine("Of course, let's take it step by step.");
        Console.ReadKey();
        Console.WriteLine("*Firstly, what is your name?");
        PlayerName = Console.ReadLine();

        do
        {
            if (PlayerName == "")
            {
                Console.WriteLine("Come on, my friend, it's not that difficult. What's your name?");
                PlayerName = Console.ReadLine();

            }
            else
            {
                Console.WriteLine($"Okay, we've made a good start. Nice to meet you {PlayerName}.");
                break;

            }
        } while (true);
        Console.WriteLine($"You didn't ask, but let me tell you, my name is Dahmer. Nice to meet you {PlayerName}.");
        Console.ReadKey();
        Console.WriteLine("It's not nice for you to enter our house without permission, but it's okay. We would love to have you as our guest today. Now, relax and take a sniff of this.");
        Console.ReadKey();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("He forcibly held you and made you smell a chemical-soaked cloth, and you suddenly fainted.");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("You woke up alone in a dark room.");
        Console.ResetColor();
        Console.WriteLine();
        Console.ReadKey();
    }
    private void InitializeGameConditions()
    {
        gameMap.CheckForLocation(gameMap.GetCoordinates());
    }

    private void StartGameLoop()
    {
        while (gameRunning)
        {
            GetInput();
            ProcessInput();
        }
    }
    private void GetInput()
    {
        playerInput = Console.ReadLine();

    }
    private void ProcessInput()
    {
        if (playerInput == "" || playerInput == null)
        {
            Console.WriteLine("Give me a command!");
            return;
        }
        switch (playerInput)
        {
            case "N":
                Console.ForegroundColor = ConsoleColor.Green;
                gameMap.MovePlayer(0, 1);
                Console.ResetColor();
                break;
            case "S":
                Console.ForegroundColor = ConsoleColor.Green;
                gameMap.MovePlayer(0, -1);
                Console.ResetColor();
                break;
            case "E":
                Console.ForegroundColor = ConsoleColor.Green;
                gameMap.MovePlayer(1, 0);
                Console.ResetColor();
                break;
            case "W":
                Console.ForegroundColor = ConsoleColor.Green;
                gameMap.MovePlayer(-1, 0);
                Console.ResetColor();
                break;
            case "exit":
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Byeee!");
                Console.ResetColor();
                gameRunning = false;
                
                break;
            case "save":
                Console.ForegroundColor = ConsoleColor.Green;
                SaveGame();
                Console.WriteLine("Game saved");
                Console.ResetColor();
                break;
            case "load":
                Console.ForegroundColor = ConsoleColor.Green;
                LoadGame();
                Console.WriteLine("Game loaded");
                Console.ResetColor();
                break;
            case "help":
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(HelpMessage());
                Console.ResetColor();
                break;
            case "where":
                Console.ForegroundColor = ConsoleColor.Green;
                gameMap.CheckForLocation(gameMap.GetCoordinates());
                Console.ResetColor();
                break;
            case "clear":
                Console.Clear();
                break;
            case "take":
                gameMap.TakeItem(Player, gameMap.GetCoordinates());
                break;
            case "inventory":
                Player.CheckInventory();
                break;
            case "read":
                Console.ForegroundColor = ConsoleColor.Green;
                gameMap.ReadCmd();
                Console.ResetColor();
                break;
            case "read note":
                Console.ForegroundColor = ConsoleColor.Green;
                gameMap.readNote();
                Console.ResetColor();
                break;
            case "read riddle":
                Console.ForegroundColor = ConsoleColor.Green;
                gameMap.readRiddle();
                Console.ResetColor();
                break;
            case "answer":
                RiddleCon();
                break;
            case "1":
                if (gameMap.hasRiddle = true)
                {
                    answerOne();
                }
                break;
            case "2":
                if (gameMap.hasRiddle = true)
                {
                    answerTwo();
                }
                break;
            case "3":
                if (gameMap.hasRiddle = true)
                {
                    answerThree();
                }
                break;
            default:
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Command not recognized. Please type 'help' for a list of available commands");
                Console.ResetColor();
                break;
        }
    }
    private void EndGame()
    {
        gameRunning = false;
    }
    private void RiddleCon()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("You only have one chance, otherwise Dahmer will kill you");
        Console.WriteLine();
        Console.WriteLine("So what is the answer?");
        Console.ResetColor();
    }
    private void answerOne()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Wrong answer Dahmer didn't like it.");
        Console.WriteLine("You are dead,I'm sorry you fell victim to Dahmer's game.");
        Console.ResetColor();
        EndGame();
    }
    private void answerTwo()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Wrong answer Dahmer didn't like it.");
        Console.WriteLine("You are dead,I'm sorry you fell victim to Dahmer's game.");
        Console.ResetColor();
        EndGame();
    }
    private void answerThree()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("You solved the puzzle, congratulations");
        Console.WriteLine("I'm sorry you fell victim to Dahmer's game, stay safe!");
        Console.ResetColor();
        EndGame();
    }
    private void LoadGame()
    {
        string path = SaveFilePath();
        if (File.Exists(path))
            return;

        string[] saveContent = File.ReadAllLines(path);

        PlayerName = saveContent[0];

        List<int> coords = saveContent[1].Split(",").Select(int.Parse).ToList();
        Vector2 coordArray = new Vector2(coords[0],coords[1]);

        _loadedItems = new List<Item>();

        List<string> itemStrings = saveContent[2].Split(',').ToList();

        for (int i = 0; i < itemStrings.Count; i++)
        {
            if (Enum.TryParse(itemStrings[i], out Item result))
            {
                Item item = result;
                _loadedItems.Add(item);
                gameMap.RemoveItemFromLocation(item);
            }
        }
        gameMap.SetCoordinates(coordArray);
    }
    private void SaveGame()
    {
        
        string xCoord = gameMap.GetCoordinates()[0].ToString(); 
        string yCoord = gameMap.GetCoordinates()[1].ToString();

        string playerCoords = $"{xCoord},{yCoord}";

        List<Item> items = Player.Inventory.Items;
        string playerItems = "";
        for (int i = 0; i < items.Count; i++)
        {
            playerItems += items[i].ToString();

            if (i != items.Count - 1)
            {
                playerItems += ",";
            }
        }

        string saveContent = $"{PlayerName}{Environment.NewLine}{playerCoords}{Environment.NewLine}{playerItems}";
        string path = SaveFilePath();
        File.WriteAllText(path, saveContent);
    }
    private string SaveFilePath()
    {
        string workingDirectory = Environment.CurrentDirectory;
        string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
        string path = projectDirectory + @"\save.txt";
        return path;
    }
    private string HelpMessage()
    {
        return @"Here are the current commands:
N: Go North
S: Go South
E: Go East
W: Go West
load: Load saved game
save: Save current game
clear: Clear the screen
take: Take the item present on the location
inventory: View your inventory
read: Read something
asnwer: Answer the question
exit: Exit the game";
    }
}
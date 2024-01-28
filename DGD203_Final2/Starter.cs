using System;
using DGD203_Final2;

public class Starter
{
    private static void Main(string[] args)
    {
        Game gameInstance = new Game();


        gameInstance.StartGame(gameInstance);
    }
}

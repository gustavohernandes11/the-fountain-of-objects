using BoardSystem;
using ManagerSystem;


Console.Clear();

Board myBoard = new(Difficulty.Hard);
GameManager gameManager = new(myBoard);
gameManager.Init();

Console.ForegroundColor = ConsoleColor.White;

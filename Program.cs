using BoardSystem;
using ManagerSystem;


Console.Clear();

Board myBoard = new(4);
GameManager gameManager = new(myBoard);
gameManager.Init();

Console.ForegroundColor = ConsoleColor.White;





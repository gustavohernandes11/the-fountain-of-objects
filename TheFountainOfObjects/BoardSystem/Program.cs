using BoardSystem;
using ManagerSystem;
using Utilities;

Board? board = null;

while (board == null)
{
    string? input = Helper.GetPrompt("Qual o tamanho do mapa você quer jogar? (small, medium, large).");

    switch (input)
    {
        case "small":
            board = new SmallBoard();
            break;
        case "medium":
            board = new MediumBoard();
            break;
        case "large":
            board = new LargeBoard();
            break;
        default:
            Console.WriteLine("Invalid Option.");
            break;
    }

}

GameManager gameManager = new(board);
gameManager.Init();



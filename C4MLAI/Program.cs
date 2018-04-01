using C4MLAI.ConnectFour;

namespace C4MLAI
{
    class Program
    {
        static void Main(string[] args)
        {
            Board gameBoard = new Board();
            Tile CurrentPlayer = Tile.Player1;
            gameBoard.InitializeBoard();
            gameBoard.PrintBoard();
            while (!gameBoard.CheckWin())
            {
                gameBoard.MakeMove(CurrentPlayer);
                if (CurrentPlayer == Tile.Player1)
                {
                    CurrentPlayer = Tile.Player2;
                }
                else
                {
                    CurrentPlayer = Tile.Player1;
                }
            }
        }
    }
}

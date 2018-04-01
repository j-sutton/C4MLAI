using System;
using System.Linq;

namespace C4MLAI.ConnectFour
{
    public class Board
    {

        private int Height { get; set; }
        private int Width { get; set; }
        private Tile[,] Grid { get; set; }

        public Board()
        {
            Console.WriteLine("Creating Board");
            this.Height = 6;
            this.Width = 7;
        }

        public Board(int width, int height)
        {
            Console.WriteLine("Creating Board");
            this.Height = width;
            this.Width = height;
        }

        public void InitializeBoard()
        {

            Console.WriteLine("Initializing Board");
            Grid = new Tile[Width, Height];
            for (var i = 0; i < this.Width; i++)
            {
                for (var j = 0; j < this.Height; j++)
                {
                    Grid[i, j] = Tile.Empty;
                }
            }
        }

        public bool MakeMove(Tile player)
        {
            if (player == Tile.Empty)
            {
                throw new Exception("Player is not set.");
            }
            Console.WriteLine(string.Format("{1}'s Turn. Please enter a position (1-{0})", this.Width, player));
            string input = Console.ReadLine();
            int index;
            bool isNumeric = int.TryParse(input, out index);
            if (!isNumeric)
            {
                Console.WriteLine("That is not a valid number, please try again");
                return MakeMove(player);
            }
            index--;
            if (index < 0 || index > this.Width - 1)
            {
                Console.WriteLine("Choice is outside of bounds");
                return false;
            }
            for (int j = this.Height - 1; j >= 0; j--)
            {
                if (Grid[index, j] == Tile.Empty)
                {
                    Grid[index, j] = player;
                    break;
                }
                if (j == 0)
                {
                    Console.WriteLine("This row is full, please select another");
                    PrintBoard();
                    return MakeMove(player);
                }
            }

            PrintBoard();
            return true;
        }

        public void PrintBoard()
        {
            PrintRowSpace();
            for (var i = 0; i < this.Height; i++)
            {
                for (var j = 0; j < this.Width; j++)
                {
                    Console.Write("|" + SpaceValue(Grid[j, i]));
                }
                Console.WriteLine();
                PrintRowSpace();
            }
        }

        public void PrintRowSpace()
        {
            Enumerable.Range(0, Height + 1).ToList().ForEach(x => Console.Write("--"));
            Console.WriteLine();
        }

        public string SpaceValue(Tile space)
        {
            switch (space)
            {
                case Tile.Empty:
                    return " ";
                case Tile.Player1:
                    return "X";
                case Tile.Player2:
                    return "O";
                default:
                    return " ";
            }
        }

        public bool CheckWin()
        {
            // Check horizontal wins
            for (int i = 0; i < this.Height; i++)
            {
                int consecutiveP1 = 0;
                int consecutiveP2 = 0;
                for (int j = 0; j < this.Width; j++)
                {
                    if (Grid[j, i] == Tile.Player1)
                    {
                        consecutiveP1++;
                        consecutiveP2 = 0;
                    }

                    if (Grid[j, i] == Tile.Player2)
                    {
                        consecutiveP2++;
                        consecutiveP1 = 0;
                    }

                    if (consecutiveP1 == 4)
                    {
                        Console.WriteLine("Player 1 wins!");
                        return true;
                    }

                    if (consecutiveP2 == 4)
                    {
                        Console.WriteLine("Player 2 wins!");
                        return true;
                    }
                }
            }
            return false;
        }
    }
}

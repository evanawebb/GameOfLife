using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GameOfLife
{
    public class ConsoleInterface
    {
        //prints menu to select game
        public void RunInterface()
        {
            bool printMenu = true;
            while (printMenu)
            {
                printMenu = false;
                Console.WriteLine("Welcome to Conway's Game Of Life:\n");
                Console.WriteLine("Press 1 to select defult gameboard.\n");
                Console.WriteLine("Press 2 to select 'OHIO' gameboard.\n");
                Console.WriteLine("If you prefer, simply enter name of file to read from the current directory(ohio.txt, tc.txt, bs.txt): \n");
                string input = Console.ReadLine();
                Console.Clear();

                string directory = Environment.CurrentDirectory;
                string fullPath = Path.Combine(directory, input);
                if (input == "1")
                {
                    GameBoard newGame = new GameBoard();
                    PrintStartingGrid(newGame);
                }
                else if (input == "2")
                {
                    DataFileAccess newFile = new DataFileAccess("ohio.txt");
                    GameBoard newGame = new GameBoard(newFile.GetFileGrid());
                    PrintStartingGrid(newGame);
                }
                else if (File.Exists(fullPath))
                {
                    DataFileAccess newFile = new DataFileAccess(input);
                    GameBoard newGame = new GameBoard(newFile.GetFileGrid());
                    PrintStartingGrid(newGame);
                }
                else
                {
                    Console.WriteLine("Not a valid file. Press enter to return to the menu.");
                    Console.ReadLine();
                    Console.Clear();
                    printMenu = true;
                }
            }
        }

        //uses selected gameboard to print new game
        public void PrintStartingGrid(GameBoard newGame)
        {
            Console.WriteLine("Original Grid \n");
            for (int i = 0; i < newGame.GridState.Length; i++)
            {
                for (int j = 0; j < newGame.GridState[i].Length; j++)
                {
                    Console.Write(newGame.GridState[i][j]);
                }
                Console.Write("\n");
            }
            UpdateStartingGridBoard(newGame);
        }

        //prints updated board and loops through it after game is initiated
        public void UpdateStartingGridBoard(GameBoard newGame)
        {
            Console.WriteLine("\nUpdated Grid \n");
            for (int i = 0; i < newGame.GridState.Length; i++)
            {
                for (int j = 0; j < newGame.GridState[i].Length; j++)
                {
                    Console.Write(newGame.GridState[i][j]);
                }
                Console.Write("\n");
            }
            Console.WriteLine("\n Press enter to begin game.");
            Console.ReadLine();
            //begins loop to constantly update grid
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Conway's Game of Life \n");
                newGame.UpdateGameboard();
                for (int i = 0; i < newGame.GridState.Length; i++)
                {
                    for (int j = 0; j < newGame.GridState[i].Length; j++)
                    {
                        Console.Write(newGame.GridState[i][j]);
                    }
                    Console.Write("\n");
                }
                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
            }
        }
    }
}

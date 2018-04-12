using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class GameBoard
    {
        private string[][] gridState;
        public string[][] GridState
        {
            get
            {
                return gridState;
            }
        }

        //constructor using only the example grid
        public GameBoard()
        {
            gridState = new string[6][]
                {
                    new string[] {".",".",".",".",".",".","0","."},
                    new string[] {"0","0","0",".",".",".","0","."},
                    new string[] {".",".",".",".",".",".","0","."},
                    new string[] {".",".",".",".",".",".",".","."},
                    new string[] {".",".",".","0","0",".",".","."},
                    new string[] {".",".",".","0","0",".",".","."},
                };
        }

        //Constructor using input file to populate grid
        public GameBoard(string[][] fileGrid)
        {
            gridState = fileGrid;
        }

        //returns updated gameboard
        public string[][] UpdateGameboard()
        {
            string[][] updatedState = new string[gridState.Length][];

            for (int i = 0; i < gridState.Length; i++)
            {
                //sets length of interrior array to the same size as the specific array in the original grid
                updatedState[i] = new string[gridState[i].Length];

                for (int j = 0; j < gridState[i].Length; j++)
                {
                    string selectedPopulation = gridState[i][j];
                    updatedState[i][j] = UpdateCell(selectedPopulation, NeighborPopulation(i, j));
                }
            }
            gridState = updatedState;
            return updatedState;
        }

        // returns array of all neighbors to the selected value
        public string[] NeighborPopulation(int i, int j)
        {
            string[] popOfNeighbors;
            //check to see if we are in the top or bottom line of grid to determine number of neighbors
            if (i > 0 && i < gridState.Length - 1)
            {
                popOfNeighbors = CenterOfGridNeighbors(i, j);
            }
            else if (i == 0)
            {
                popOfNeighbors = TopOfGridNeighbors(i, j);
            }
            else
            {
                popOfNeighbors = BottomOfGridNeighbors(i, j);
            }
            return popOfNeighbors;
        }

        // checks the value of j(to determine if it is on end of street) and returns array of neighbors for "streets" not on top/bottom of grid
        public string[] CenterOfGridNeighbors(int i, int j)
        {
            //this code is longer than otherwise required it could have been reduced to a limited number of lines with {} in 
            //array creation but I have written it this way to make it clear and increase readability            
            string[] popOfNeighbor;

            if (j > 0 && j < gridState[i].Length - 1)
            {
                popOfNeighbor = new string[8];
                popOfNeighbor[0] = gridState[i - 1][j - 1]; //popTopLeft
                popOfNeighbor[1] = gridState[i + 1][j - 1]; //popBottomLeft
                popOfNeighbor[2] = gridState[i - 1][j]; //popTopCenter
                popOfNeighbor[3] = gridState[i + 1][j]; //popBottomCenter
                popOfNeighbor[4] = gridState[i - 1][j + 1]; //popTopRight
                popOfNeighbor[5] = gridState[i + 1][j + 1]; // popBottomRight
                popOfNeighbor[6] = gridState[i][j - 1]; // popLeft
                popOfNeighbor[7] = gridState[i][j + 1]; // popRight
            }
            else if (j == 0)
            {
                popOfNeighbor = new string[5];
                popOfNeighbor[0] = gridState[i - 1][j]; //popTopCenter
                popOfNeighbor[1] = gridState[i + 1][j]; //popBottomCenter
                popOfNeighbor[2] = gridState[i - 1][j + 1]; //popTopRight
                popOfNeighbor[3] = gridState[i + 1][j + 1]; // popBottomRight
                popOfNeighbor[4] = gridState[i][j + 1]; // popRight
            }
            else
            {
                popOfNeighbor = new string[5];
                popOfNeighbor[0] = gridState[i - 1][j - 1]; //popTopLeft
                popOfNeighbor[1] = gridState[i + 1][j - 1]; //popBottomLeft
                popOfNeighbor[2] = gridState[i - 1][j]; //popTopCenter
                popOfNeighbor[3] = gridState[i + 1][j]; //popBottomCenter
                popOfNeighbor[4] = gridState[i][j - 1]; // popLeft
            }
            return popOfNeighbor;
        }

        // checks the value of j(to determine if it is on end of street) and returns array of neighbors for "streets" on top of grid
        public string[] TopOfGridNeighbors(int i, int j)
        {
            string[] popOfNeighbor;
            if (j > 0 && j < gridState[i].Length - 1)
            {
                popOfNeighbor = new string[5];
                popOfNeighbor[0] = gridState[i + 1][j - 1]; //popBottomLeft
                popOfNeighbor[1] = gridState[i + 1][j]; //popBottomCenter
                popOfNeighbor[2] = gridState[i + 1][j + 1]; // popBottomRight
                popOfNeighbor[3] = gridState[i][j - 1]; // popLeft
                popOfNeighbor[4] = gridState[i][j + 1]; // popRight
            }
            else if (j == 0)
            {
                popOfNeighbor = new string[3];
                popOfNeighbor[0] = gridState[i + 1][j]; //popBottomCenter
                popOfNeighbor[1] = gridState[i + 1][j + 1]; // popBottomRight
                popOfNeighbor[2] = gridState[i][j + 1]; // popRight
            }
            else
            {
                popOfNeighbor = new string[3];
                popOfNeighbor[0] = gridState[i + 1][j - 1]; //popBottomLeft
                popOfNeighbor[1] = gridState[i + 1][j]; //popBottomCenter
                popOfNeighbor[2] = gridState[i][j - 1]; // popLeft
            }
            return popOfNeighbor;
        }

        // checks the value of j(to determine if it is on end of street) and returns array of neighbors for "streets" on bottom of grid
        public string[] BottomOfGridNeighbors(int i, int j)
        {
            string[] popOfNeighbor;
            if (j > 0 && j < gridState[i].Length - 1)
            {
                popOfNeighbor = new string[5];
                popOfNeighbor[0] = gridState[i - 1][j - 1]; //popTopLeft
                popOfNeighbor[1] = gridState[i - 1][j]; //popTopCenter
                popOfNeighbor[2] = gridState[i - 1][j + 1]; //popTopRight
                popOfNeighbor[3] = gridState[i][j - 1]; // popLeft
                popOfNeighbor[4] = gridState[i][j + 1]; // popRight
            }
            else if (j == 0)
            {
                popOfNeighbor = new string[3];
                popOfNeighbor[0] = gridState[i - 1][j]; //popTopCenter
                popOfNeighbor[1] = gridState[i - 1][j + 1]; //popTopRight
                popOfNeighbor[2] = gridState[i][j + 1]; // popRight
            }
            else
            {
                popOfNeighbor = new string[3];
                popOfNeighbor[0] = gridState[i - 1][j - 1]; //popTopLeft
                popOfNeighbor[1] = gridState[i - 1][j]; //popTopCenter
                popOfNeighbor[2] = gridState[i][j - 1]; // popLeft
            }
            return popOfNeighbor;
        }

        //updates state based on neighbors of a cell by passing its current state, array of its neighbors, 
        //and a bool that is true if it is a liveCell and false if it is a deadCell
        public string UpdateCell(string currentState, string[] neighbors)
        {
            string newState = ".";
            int[] neighborCells = GetLiveandDeadCells(neighbors);
            if (currentState == "0")
            {
                //neighborCells[0] refers to the number of living cells.
                if ((neighborCells[0] < 2) ^ (neighborCells[0] > 3))
                {
                    newState = ".";
                }
                else if ((neighborCells[0] == 2) || (neighborCells[0] == 3))
                {
                    newState = "0";
                }
            }
            else if (currentState == ".")
            {
                if (neighborCells[0] == 3)
                {
                    newState = "0";
                }
                else
                {
                    newState = ".";
                }
            }
            else
            {
                newState = currentState;
            }
            return newState;
        }

        // returns an array of 2 ints with the first representing number of liveCells and the second representing the number of deadCells
        public int[] GetLiveandDeadCells(string[] neighbors)
        {
            int liveCells = 0;
            int deadCells = 0;
            foreach (string pop in neighbors)
            {
                if (pop == "0")
                {
                    liveCells++;
                }
                else
                {
                    deadCells++;
                }
            }
            int[] liveAndDeadCells = new int[2] { liveCells, deadCells };
            return liveAndDeadCells;
        }
    }
}



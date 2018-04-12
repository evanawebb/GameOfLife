using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameOfLife;

namespace GameOfLifeTests
{
    [TestClass]
    public class GameBoardTests
    {
        GameBoard newBoard = new GameBoard();

        string[][] firstRoundUpdateGrid = new string[6][]
        {
                    new string[] {".","0",".",".",".",".",".","."},
                    new string[] {".","0",".",".",".","0","0","0"},
                    new string[] {".","0",".",".",".",".",".","."},
                    new string[] {".",".",".",".",".",".",".","."},
                    new string[] {".",".",".","0","0",".",".","."},
                    new string[] {".",".",".","0","0",".",".","."},
        };

        [TestMethod]
        public void GetLiveandDeadCellsTest()
        {
            string[] neighbors = { "0", "0", "0" };
            int[] result = { 3, 0 };
            Assert.AreEqual(result[0], newBoard.GetLiveandDeadCells(neighbors)[0]);
            Assert.AreEqual(result[1], newBoard.GetLiveandDeadCells(neighbors)[1]);
            neighbors[0] = ".";
            result = new int[] { 2, 1 };
            Assert.AreEqual(result[0], newBoard.GetLiveandDeadCells(neighbors)[0]);
            Assert.AreEqual(result[1], newBoard.GetLiveandDeadCells(neighbors)[1]);

        }

        [TestMethod]
        public void UpdateCellTest()
        {
           
            string[] neighbors = { "0", "0","0" };
            //testing else statement w/ current state being dead.
            Assert.AreEqual("0", newBoard.UpdateCell(".", neighbors));
            neighbors[1] = ".";
            //testing the two brances of the if else within if statment that checks current state and current state being alive
            Assert.AreEqual("0", newBoard.UpdateCell("0", neighbors));
            neighbors[2] = ".";
            Assert.AreEqual(".", newBoard.UpdateCell("0", neighbors));
        }

        [TestMethod]
        public void TopOfGridNeighborsTest()
        {
            //testing the three brances of the if else
            Assert.AreEqual(5, newBoard.TopOfGridNeighbors(0,3).Length);
            Assert.AreEqual(3, newBoard.TopOfGridNeighbors(0,0).Length);
            Assert.AreEqual(3, newBoard.TopOfGridNeighbors(0,7).Length);
        }

        [TestMethod]
        public void BottomOfGridNeighborsTest()
        {
            //testing the three brances of the if else
            Assert.AreEqual(5, newBoard.BottomOfGridNeighbors(5,2).Length);
            Assert.AreEqual(3, newBoard.BottomOfGridNeighbors(5,0).Length);
            Assert.AreEqual(3, newBoard.BottomOfGridNeighbors(5,7).Length);
        }
        
        [TestMethod]
        public void CenterOfGridNeighborsTest()
        {
            //testing the three brances of the if else
            Assert.AreEqual(8, newBoard.CenterOfGridNeighbors(2,3).Length);
            Assert.AreEqual(5, newBoard.CenterOfGridNeighbors(3,0).Length);
            Assert.AreEqual(5, newBoard.CenterOfGridNeighbors(4,7).Length);
        }

        [TestMethod]
        public void NeighborPopulationTest()
        {
        //Tests to ensure the expected array containing the neighbors of a cell is returned by the NeighborPopulation() method
        //For simplicity I only tested one iteration as the entire iteration will be tested by the UpdateGameboardTest() method
            int i = 0;
            int j = 0;
            string[] methodResults = newBoard.NeighborPopulation(i, j);
            string[] results = new string[] { "0", "0", "." };
            for (int k = 0; k < results.Length; k++)
            {
                Assert.AreEqual(results[k], methodResults[k]);
            }
            
        }

        [TestMethod]
        public void UpdateGameboardTest()
        {
            string[][] updatedGame = newBoard.UpdateGameboard();
            for (int i = 0; i < firstRoundUpdateGrid.Length; i++)
            {
                for (int j = 0; j < firstRoundUpdateGrid[i].Length; j++)
                {
                    Assert.AreEqual(firstRoundUpdateGrid[i][j], updatedGame[i][j]);
                    
                }
            }
        }
    }
}

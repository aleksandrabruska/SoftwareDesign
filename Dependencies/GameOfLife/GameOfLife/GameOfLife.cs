﻿using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
//using System.Threading;

namespace GameOfLife
{
    class GameOfLife
    {
        private readonly int _gridSize;
        private const int AliveThreshold = 25;
        private int[,] _curGrid;
        private int[,] _newGrid;


        public GameOfLife(int gridSize)
        {
            _gridSize = gridSize;
            _curGrid = new int[_gridSize, _gridSize];
            _newGrid = new int[_gridSize, _gridSize];

            var rnd = new Random();
            for (var row = 0; row < _gridSize; row++)
            {
                for (var col = 0; col < _gridSize; col++)
                {
                    _curGrid[row, col] = (rnd.Next(100) < AliveThreshold) ? 1 : 0;
                }
            }
        }



        public void Run(int numberOfIterations)
        {
            while (numberOfIterations > 0)
            {
                var locationsAlive = 0;
                for (var row = 0; row < _gridSize; row++)
                {
                    for (var col = 0; col < _gridSize; col++)
                    {
                        if (ShallLocationBeAlive(row, col))
                        {
                            ++locationsAlive;
                            _newGrid[row, col] = 1;
                        }
                        else
                        {
                            _newGrid[row, col] = 0;
                        }
                    }
                }
                Swap(ref _curGrid, ref _newGrid);
                //Console.WriteLine(locationsAlive);
                numberOfIterations--;
            }
        }


        public void RunParallel(int numberOfIterations)
        {
            while (numberOfIterations > 0)
            {
                var locationsAlive = 0;
                Parallel.For(0, _gridSize, row =>
                {
                    for (var col = 0; col < _gridSize; col++)
                    {
                        if (ShallLocationBeAlive(row, col))
                        {
                            ++locationsAlive;
                            _newGrid[row, col] = 1;
                        }
                        else
                        {
                            _newGrid[row, col] = 0;
                        }
                    }
                });
                Swap(ref _curGrid, ref _newGrid);
                //Console.WriteLine(locationsAlive);
                //printGrid(_curGrid);
                numberOfIterations--;
            }
        }

        public void RunWithBarrier(int numberOfIterations)
        {
            int numTask = Environment.ProcessorCount;
            var tasks = new Task[numTask];

            var stepBarrier = new Barrier(numTask, _ => Swap(ref _curGrid, ref _newGrid));
            int chunkSize = (_gridSize - 2) / numTask;

            Console.WriteLine("tasks " + numTask);
            for (int i = 0; i < numTask; i++)
            {
                Console.WriteLine("Creating task " + i);
                int yStart = 1 + (chunkSize * i);
                int yEnd = (i == numTask - 1) ? _gridSize - 1 : yStart + chunkSize;
                var localI = i;
                var localNumOfIter = numberOfIterations;
                tasks[i] = Task.Run(() =>
                {
                    Console.WriteLine("Started task " + localI);
                    var locationsAlive = 0;
                    while (localNumOfIter > 0)
                    {
                        Console.WriteLine("Started iter " + localNumOfIter + " for task " + localI);
                        for (int row = 0; row < _gridSize; row++)
                        {

                            for (var col = 0; col < _gridSize; col++)
                            {
                                if (ShallLocationBeAlive(row, col))
                                {
                                    ++locationsAlive;
                                    _newGrid[row, col] = 1;
                                }
                                else
                                {
                                    _newGrid[row, col] = 0;
                                }
                            }


                        }

                        Console.WriteLine(" ??"+locationsAlive);
                        //printGrid(_curGrid);
                        stepBarrier.SignalAndWait();
                        localNumOfIter--;
                    }


                });
            }
        }


        private bool ShallLocationBeAlive(int row, int col)
        {
            var liveNeighbors = CalcAliveNeighbors(row, col);

            if (_curGrid[row, col] == 1)
            {
                if ((liveNeighbors == 2) || (liveNeighbors == 3))
                    return true;    // Alive and with two or three neighbors - live on
            }
            else if (liveNeighbors == 3)
            {
                return true; // Dead and with exactly three neighbors - live
            }
            return false;   // Die
        }

        private int CalcAliveNeighbors(int row, int col)
        {
            int liveNeighbors;

            // Implementation of GameOfLife-rules
            if (row == 0)   // Top row
            {
                if (col == 0)    // Top left-hand corner
                    liveNeighbors = _curGrid[row, col + 1] +
                                       _curGrid[row + 1, col] + _curGrid[row + 1, col + 1];

                else if (col == _gridSize - 1) // Top right-hand corner
                    liveNeighbors = _curGrid[row, col - 1] +
                                       _curGrid[row + 1, col - 1] + _curGrid[row + 1, col];

                else // On top edge
                    liveNeighbors = _curGrid[row, col - 1] + _curGrid[row, col + 1] +
                                       _curGrid[row + 1, col - 1] + _curGrid[row + 1, col] + _curGrid[row + 1, col + 1];
            }
            else if (row == _gridSize - 1) // Bottom row
            {
                if (col == 0) // Bottom left-hand corner
                    liveNeighbors = _curGrid[row - 1, col] + _curGrid[row - 1, col + 1] +
                                                                   _curGrid[row, col + 1];

                else if (col == _gridSize - 1) // Bottom right-hand corner
                    liveNeighbors = _curGrid[row - 1, col - 1] + _curGrid[row - 1, col] +
                                       _curGrid[row, col - 1];

                else // On bottom edge
                    liveNeighbors = _curGrid[row - 1, col - 1] + _curGrid[row - 1, col] + _curGrid[row - 1, col + 1] +
                                    _curGrid[row, col - 1] + _curGrid[row, col + 1];
            }
            else if (col == 0)
            {
                // Must be left edge, since corners are covered above
                liveNeighbors = _curGrid[row - 1, col] + _curGrid[row - 1, col + 1] +
                                                            _curGrid[row, col + 1] +
                                _curGrid[row + 1, col] + _curGrid[row + 1, col + 1];
            }
            else if (col == _gridSize - 1)
            {
                // Must be right edge, since corners are covered above
                liveNeighbors = _curGrid[row - 1, col - 1] + _curGrid[row - 1, col] +
                                  _curGrid[row, col - 1] +
                                  _curGrid[row + 1, col - 1] + _curGrid[row + 1, col];

            }
            else
            {
                // Interior field
                liveNeighbors = _curGrid[row - 1, col - 1] + _curGrid[row - 1, col] + _curGrid[row, col + 1] +
                                    _curGrid[row + 1, col - 1] + _curGrid[row + 1, col] +
                                    _curGrid[row + 1, col - 1] + _curGrid[row + 1, col] + _curGrid[row + 1, col + 1];
            }


            return liveNeighbors;
        }

        private void Swap<T>(ref T a, ref T b)
        {
            var temp = a;
            a = b;
            b = temp;
        }
        
        private void printGrid(int[,] grid)
        {
            int row_num = _gridSize;
            int col_num = _gridSize;
            Console.Clear();
            for (int i = 0; i < row_num; i++)
            {
                for (int j = 0; j < col_num; j++)
                {
                    if (grid[i,j] == 0)
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
                Console.WriteLine();
            }
            //Thread.Sleep(1000);
        }
    }
}

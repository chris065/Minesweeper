﻿using System;
using System.Collections.Generic;

namespace Minesweeper
{
    class Minefield
    {
        private bool[,] mines = new bool[5, 10];
        private bool[,] openedCells = new bool[5, 10];

        // Constructor
        public Minefield()
        {
            this.AddMines();
        }

        public bool[,] Mines
        { 
            get
            {
                // TODO: return copy
                return this.mines;
            }
        }

        public bool[,] OpenedCells 
        {
            get
            {
                // TODO: return copy
                return this.openedCells;
            }
        }

        public MinefieldState OpenNewCell(Cell cell)
        {
            var isInside = this.IsInsideMatrix(cell.Row, cell.Col);
            if (!isInside)
            {
                return MinefieldState.OutOfRange;
            }

            if (openedCells[cell.Row, cell.Col])
            {
                return MinefieldState.AlreadyOpened;
            }
            else
            {
                openedCells[cell.Row, cell.Col] = true;

                if (mines[cell.Row, cell.Col])
                {
                    return MinefieldState.Boom;
                }

                return MinefieldState.Normal;
            }
        }

        private void AddMines()
        {
            Random random = new Random();
            for (int i = 0; i < 15; i++)
            {
                int index = random.Next(50);
                while (mines[(index / 10), (index % 10)])
                {
                    index = random.Next(50);
                }

                mines[(index / 10), (index % 10)] = true;
            }
        }

        public int CountNeighborMines(Cell currentPosition) //(int i, int j)
        {
            int counter = 0;

            for (int row = -1; row < 2; row++)
            {
                for (int col = -1; col < 2; col++)
                {
                    if (col == 0 && row == 0)
                    {
                        continue;
                    }

                    if (IsInsideMatrix(currentPosition.Row + row, currentPosition.Col + col) &&
                        mines[currentPosition.Row + row, currentPosition.Col + col])
                    {
                        counter++;
                    }
                }
            }

            return counter;
        }

        private bool IsInsideMatrix(int row, int col)
        {
            return (0 <= row && row <= 4) && (0 <= col && col <= 9);
        }

        public int CountOpen()
        {
            int res = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (openedCells[i, j])
                    {
                        res++;
                    }
                }
            }

            return res;
        }
    }
}
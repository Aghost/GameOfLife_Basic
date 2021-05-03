using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using TermOs.Utils;

namespace GameOfLife
{
    public class CellGrid
    {
        public Cell[][] Cells;
        public int GridSize;

        public CellGrid(string filename, int gridsize) {
            GridSize = gridsize;
            Cells = FileToCells(filename, gridsize);
        }

        public int CountNeighbors(int x, int y) {
            if (x == 0 || y == 0 || x == GridSize - 1 || y == GridSize - 1) {
                return 0;
            } else {
                int sum = 0;
                for (int i = -1; i < 2; i++)
                    for (int j = -1; j < 2; j++)
                        if (Cells[x + i][y+ j].isAlive)
                            sum += 1;

                if (Cells[x][y].isAlive)
                    sum -= 1;

                return sum;
            }
        }

        // Conway's game of life
        public void ApplyRules() {
            Cell[][] newCells = CreateEmptyCells(GridSize);

            for (int i = 0; i < GridSize; i++) {
                for (int j = 0; j < GridSize; j++) {
                    int neighs = CountNeighbors(i, j);
                    if (Cells[i][j].isAlive) {
                        if (neighs == 2 || neighs == 3) {
                            newCells[i][j].Resurrect();
                        }
                    } else {
                        if (neighs == 3) {
                            newCells[i][j].Resurrect();
                        } else {
                            newCells[i][j].Die();
                        }
                    }
                }
            }

            Cells = newCells;
        }

        // HighLife
        public void ApplyRules2() {
            Cell[][] newCells = CreateEmptyCells(GridSize);
            for (int i = 0; i < GridSize; i++) {
                for (int j = 0; j < GridSize; j++) {
                    int neighs = CountNeighbors(i, j);
                    if (Cells[i][j].isAlive) {
                        if (neighs == 2 || neighs == 3) {
                            newCells[i][j].Resurrect();
                        }
                    } else {
                        if (neighs == 3 || neighs == 6) {
                            newCells[i][j].Resurrect();
                        } else {
                            newCells[i][j].Die();
                        }
                    }
                }
            }

            Cells = newCells;
        }

        // OCA Day and night
        public void ApplyRules3() {
            Cell[][] newCells = CreateEmptyCells(GridSize);
            for (int i = 0; i < GridSize; i++) {
                for (int j = 0; j < GridSize; j++) {
                    int neighs = CountNeighbors(i, j);

                    if (Cells[i][j].isAlive) {
                        if (neighs == 3 || neighs == 4 || neighs == 6 || neighs == 7 || neighs == 8) {
                            newCells[i][j].Resurrect();
                        }
                    } else {
                        if (neighs == 3 || neighs == 6 || neighs == 7 || neighs == 8) {
                            newCells[i][j].Resurrect();
                        } else {
                            newCells[i][j].Die();
                        }
                    }
                }
            }

            Cells = newCells;
        }

        public string SendCells(int size) {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < size; i++) {
                for (int j = 0; j < size; j++) {
                    sb.Append(Cells[i][j].isAlive ? "O " : "  ");
                }

                sb.Append("\n");
            }

            return sb.ToString();
        }

        public void PrintCells(int size) {
            for (int i = 0; i < size; i++) {
                for (int j = 0; j < size; j++) {
                    Console.Write(Cells[i][j].isAlive ? "O" : " ");
                }

                Console.WriteLine();
            }
        }

        public Cell[][] FileToCells(string filename, int size) {
            string[] cellgridstrarr = Blocks.FileToBlocks(filename, size);
            char[][] cellgridchar = new char[size][];

            Cell[][] tmp = new Cell[size][];
            for (int i = 0; i < size; i++) {
                cellgridchar[i] = cellgridstrarr[i].ToCharArray();
                tmp[i] = new Cell[size];

                for (int j = 0; j < size; j++) {
                    tmp[i][j] = cellgridchar[i][j] == 49 ? new Cell(i, j, true) : new Cell(i, j);
                }
            }

            return tmp;
        }

        public Cell[][] CreateEmptyCells(int size) {
            Cell[][] tmp = new Cell[size][];
            for (int i = 0; i < size; i++) {
                tmp[i] = new Cell[size];

                for (int j = 0; j < size; j++) {
                    tmp[i][j] = new Cell(i, j);
                }
            }

            return tmp;
        }

    }
}

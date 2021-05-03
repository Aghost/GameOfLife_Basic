using System;
using GameOfLife.Data;

namespace GameOfLife.App
{
    class Program
    {
        static void Main(string[] args)
        {
            int GridSize = 64;
            CellGrid cg = new CellGrid("maps/default_map", GridSize);

            // Simpele loop om te laten zien dat de classes werken
            while (true) {
                if (Console.ReadLine() == "exit")
                    break;

                cg.ApplyRules();
                cg.PrintCells(GridSize); 
            }
        }

    }
}

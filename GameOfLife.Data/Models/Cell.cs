using System;

namespace GameOfLife.Data
{
    public class Cell
    {
        public int X { get; set;}
        public int Y { get; set;}
        public bool isAlive { get; set; }
        public bool markedForExecution { get; set; }

        public Cell(int x, int y, bool isalive = false) {
            X = x;
            Y = y;
            isAlive = isalive;
        }

        public void Die() {
            this.markedForExecution = true;
        }

        public void Resurrect() {
            this.isAlive = true;
        }

        public int[] getCoords() {
            return new int[] { X, Y };
        }

        public string getCoordsString() {
            return $"({X} {Y}) ";
        }
    }
}

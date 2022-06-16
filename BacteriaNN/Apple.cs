using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacteriaNN
{
    class Apple
    {
        private static Random rnd = new Random();
        public int[] Position = new int[2];
        public bool isAlive = true;

        public void setRandomPosition(int fieldSize) { Position[0] = rnd.Next(0, fieldSize); Position[1] = rnd.Next(0, fieldSize); }
        public int getX() => Position[1];
        public int getY() => Position[0];
        public bool getisAlive() => isAlive;
    }
}

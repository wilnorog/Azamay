using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace panoss
{
    class Program
    {
        public static char[,] mass;
        public static int x, y, q, z, n = 0, pole = 0, speed;
        public static ConsoleKeyInfo memory;
        public static int[] snakeX = new int[256];
        public static int[] snakeY = new int[256];
        public static bool crash = false;

        static void Main(string[] args)
        {
            CreateMass();
            Outmass();
            Zmeyka();
        }

    }
}

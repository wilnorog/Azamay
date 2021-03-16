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
       public static char[,] CreateMass()
        {
            int slojnost;
        B:
            Console.WriteLine("Введите уровень сложности (1-3)");
            slojnost = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            switch (slojnost)
            {
                case 1:
                    pole = 10;
                    speed = 450;
                    break;
                case 2:
                    pole = 15;
                    speed = 300;
                    break;
                case 3:
                    pole = 20;
                    speed = 150;
                    break;
                default:
                    Console.WriteLine("error");
                    goto B;
            }
            mass = new char[pole, pole];

            for (int i = 0; i < pole; i++)
            {
                for (int j = 0; j < pole; j++)
                {
                    if (i == 0 || j == 0 || i == pole - 1 || j == pole - 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        mass[i, j] = '#';
                    }
                    else
                        mass[i, j] = ' ';
                }
            }

            Random rand = new Random();
        A:
            x = rand.Next(2, pole - 2);
            y = rand.Next(2, pole - 2);
            q = rand.Next(2, pole - 2);
            z = rand.Next(2, pole - 2);
            if (x == q && y == z)
            {
                goto A;
            }
            else
            {
                mass[x, y] = 'X';
                mass[q, z] = 'O';
            }

            return mass;
        }
        public static char[,] Outmass()
        {
            for (int i = 0; i < pole; i++)
            {
                for (int j = 0; j < pole; j++)
                {
                    Console.Write(mass[i, j] + " ");
                }
                Console.WriteLine();
            }
            //Console.WriteLine("n - " + n);
            //Console.WriteLine(x + " " + y);
            //for (int i = 0; i < n; i++)
            //    Console.WriteLine(snakeX[i] + " " + snakeY[i]);                                
            return mass;
        }
    }
    }
}

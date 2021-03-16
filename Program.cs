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
         public static ConsoleKeyInfo move()
        {
            ConsoleKeyInfo cki;
            cki = Console.ReadKey();
            memory = cki;
            return cki;
        }

        public static char[,] Zmeyka()
        {
            while (x != 0 && y != 0 && x != pole && y != pole && crash == false)
            {
                if (Console.KeyAvailable == true)
                {
                    ConsoleKeyInfo cki = move();
                    if (cki.Key.ToString() == "A")
                    {
                        Movehvost();
                        mass[x, y - 1] = mass[x, y];
                        if (n == 0)
                            mass[x, y] = ' ';
                        y -= 1;
                        mass[x, y] = 'X';
                    }
                    else if (cki.Key.ToString() == "W")
                    {
                        Movehvost();
                        mass[x - 1, y] = mass[x, y];
                        if (n == 0)
                            mass[x, y] = ' ';
                        x -= 1;
                        mass[x, y] = 'X';
                    }
                    else if (cki.Key.ToString() == "S")
                    {
                        Movehvost();
                        mass[x + 1, y] = mass[x, y];
                        if (n == 0)
                            mass[x, y] = ' ';
                        x += 1;
                        mass[x, y] = 'X';
                    }
                    else if (cki.Key.ToString() == "D")
                    {
                        Movehvost();
                        mass[x, y + 1] = mass[x, y];
                        if (n == 0)
                            mass[x, y] = ' ';
                        y += 1;
                        mass[x, y] = 'X';
                    }

                }
                else if (Console.KeyAvailable == false)
                {
                    if (memory.Key.ToString() == "A")
                    {
                        Movehvost();
                        mass[x, y - 1] = mass[x, y];
                        if (n == 0)
                            mass[x, y] = ' ';
                        y -= 1;
                        mass[x, y] = 'X';
                    }
                    else if (memory.Key.ToString() == "W")
                    {
                        Movehvost();
                        mass[x - 1, y] = mass[x, y];
                        if (n == 0) 
                            mass[x, y] = ' ';
                        x -= 1;
                        mass[x, y] = 'X';
                    }
                    else if (memory.Key.ToString() == "S")
                    {
                        Movehvost();
                        mass[x + 1, y] = mass[x, y];
                        if (n == 0) 
                            mass[x, y] = ' ';
                        x += 1;
                        mass[x, y] = 'X';
                    }
                    else if (memory.Key.ToString() == "D")
                    {
                        Movehvost();
                        mass[x, y + 1] = mass[x, y];
                        if (n == 0) 
                            mass[x, y] = ' ';
                        y += 1;
                        mass[x, y] = 'X';
                    }
                }

                if (x == q && y == z)
                {
                    CreateEda(mass);
                    Plushvost();
                }

                Console.SetCursorPosition(0, 0);
                Outmass();

                for (int i = 1; i < n - 1; i++)
                {
                    if (x == snakeX[i] && y == snakeY[i])
                    {
                        crash = true;
                    }
                }

                Thread.Sleep(speed);
            }
            Console.WriteLine("Defeat");
            return mass;
        }
        public static void Movehvost() 
        {
            for (int i = 0; i < n; i++)
            {
                mass[snakeX[i], snakeY[i]] = ' ';
            }

            for (int i = n; i >= 1; i--)
            {
                snakeX[i] = snakeX[i - 1];
                snakeY[i] = snakeY[i - 1];
            }

            snakeX[0] = x;
            snakeY[0] = y;

            for (int i = 0; i < n; i++)
            {
                mass[snakeX[i], snakeY[i]] = '*';
            }
        }
        public static void Plushvost() 
        {
            snakeX[n] = x;
            snakeY[n] = y;
            n++;
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

using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Mail;
using System.Xml.Linq;

namespace Labirint
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] l = new int[,]
             {
                {1, 1, 1, 1, 1, 1, 1 },
                {1, 0, 0, 0, 0, 0, 1 },
                {1, 0, 1, 1, 1, 0, 1 },
                {0, 0, 0, 0, 1, 0, 0 },
                {1, 1, 0, 0, 1, 1, 1 },
                {1, 1, 1, 0, 1, 1, 1 },
                {1, 1, 1, 0, 1, 1, 1 }
             };

            Labyrinth.HasExit(3, 0, l);

            Console.ReadKey();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labirint
{
    public class Labyrinth
    {
        private int startI = 0;
        private int startJ = 0;
        private int[,] labyrinth;


        public Labyrinth()
        {
        }

        public Labyrinth(int startI, int startJ, int[,] labyrinth)
        {
            this.startI = startI;   
            this.startJ = startJ;
            this.labyrinth = labyrinth;
        }  

        public int GetStartI()
        {
           return startI;
        }

        public int GetStartJ()
        {
            return startJ;
        }

        public int[,] GetLabyrinth()
        {
            return labyrinth;
        }


        public static bool ExitPointFound(int startI, int startJ, int[,] labyrinth)
        {
            // Если вышли за границы массива возвращаем true.
            // Это и будет признаком того, что на этом шаге(итерации цикла) был обнаружен выход.
            if ((startI < 0 || startI == labyrinth.GetLength(0)) || (startJ < 0 || startJ == labyrinth.GetLength(1)))
            {
                return true;
            }

            //  Если false то выход не найден.
            return false;
        }


        public static bool HasExit(int startI, int startJ, int[,] labyrinth)
        {

            Stack<Tuple<int, int>> next = new Stack<Tuple<int, int>>();

            // В этот список будут заноситься координаты найденных выходов.
            List<Tuple<int, int>> listOfDetectedExit = new List<Tuple<int, int>>();

            // Проверяем, точно ли заданная точка я вляется входом в лабиринт.
            if (labyrinth[startI, startJ] == 0)
            {
                //  Добавляем элемент в стэк(в верхушку стэка).
                //  Элементом является кортэж с координатами элемента двумерного массива.
                next.Push(new Tuple<int, int>(startI, startJ));
            }
            else
            {
                Console.WriteLine($"Заданные координаты -  [{startI}, {startJ}] не являются точкой входа в лабиринт!");
                return false;
            }

            while (next.Count > 0)
            {
                var current = next.Pop();

                //  Проверяем выход за пределы лабиринта(массива).
                if (ExitPointFound(current.Item1, current.Item2, labyrinth) == true) continue;

                //  Если "упёрлись в стрену(в цифру 1)", тогда пропускаем итерацию цикла
                if (labyrinth[current.Item1, current.Item2] == 1) continue;

                //  Отмечаем цифрой 1 пройденный шаг
                labyrinth[current.Item1, current.Item2] = 1;


                next.Push(new Tuple<int, int>(current.Item1 - 1, current.Item2));
                if (ExitPointFound(next.Peek().Item1, next.Peek().Item2, labyrinth))
                {
                    listOfDetectedExit.Add(current);
                }

                next.Push(new Tuple<int, int>(current.Item1 + 1, current.Item2));
                if (ExitPointFound(next.Peek().Item1, next.Peek().Item2, labyrinth))
                {
                    listOfDetectedExit.Add(current);
                }

                next.Push(new Tuple<int, int>(current.Item1, current.Item2 - 1));
                if (ExitPointFound(next.Peek().Item1, next.Peek().Item2, labyrinth))
                {
                    listOfDetectedExit.Add(current);
                }

                next.Push(new Tuple<int, int>(current.Item1, current.Item2 + 1));
                if (ExitPointFound(next.Peek().Item1, next.Peek().Item2, labyrinth))
                {
                    listOfDetectedExit.Add(current);
                }
            }

            //  Тут проверяем, найдены ли точки выхода из лабиринта и выводим информацию на экран.
            if ((listOfDetectedExit.Count - 1) == 0)
            {
                Console.WriteLine($"Выход из лабиринта не найден");
            }
            else
            {

                Console.WriteLine($"Число найденных выходов = {listOfDetectedExit.Count - 1}");

                for (int i = 0; i < listOfDetectedExit.Count; i++)
                {
                    if (i == 0)
                    {
                        Console.WriteLine($"Точка входа - [{listOfDetectedExit[i].Item1},{listOfDetectedExit[i].Item2}]");
                    }
                    else
                    {
                        Console.WriteLine($"Координаты Выхода № {i} = [{listOfDetectedExit[i].Item1},{listOfDetectedExit[i].Item2}]");
                    }
                }
            }

            return false;
        }
    }
}

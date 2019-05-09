using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace task9UP
{
    class Program
    {
        static void Main(string[] args)
        {

            Point p2 = new Point();
            int size = 0;
            int a = 0;
            int N1 = 1;

            a = 0;
            Console.WriteLine("Введите размер списка");
            while (a == 0)
            {
                size = p2.wwww();
                if (size <= 0)
                {
                    Console.WriteLine("Ошибка, список не существует или пуст! Повторите ввод.");
                }
                else
                {
                    a++;
                }
            }
            p2 = p2.MakeList2(size);
            p2.ShowList1(p2);
            Console.WriteLine("Первый включенный в список элемент, имеющий номер 1, оказывается в хвосте списка: ");
            p2 = p2.SwapBeg(p2);
            p2.ShowList1(p2);
            Console.WriteLine("Введите номер элемента который хотите найти: ");
            N1--;
            int number = p2.wwww();
            p2.Search(p2, N1, number);
            Console.WriteLine("Введите номер элемента который хотите удалить: ");
            N1++;
            number = p2.wwww();
            p2 = p2.Dell(p2, N1, number);
            p2.ShowList1(p2);

            Console.ReadKey();
        }

        class Point
        {
            public int data;
            public Point next,
                pred;
            public Point()
            {
                data = 0;
                next = null;
                pred = null;
            }
            public Point(int d)
            {
                data = d;
                next = null;
                pred = null;
            }
            public override string ToString()
            {
                return data + " ";
            }
            public Point MakePoint1(int d)
            {
                Point p = new Point(d);
                return p;
            }
            public Point MakeList1(Point beg, int N, int size)
            {
                Point r = beg;
                N++;
                Point p = MakePoint1(N);
                r.next = p;
                p.pred = r;
                r = p;
                
                if (N!=size) { MakeList1(r, N, size); }
                return beg;
            }
            public Point MakeList2(int size)
            {
                int N = 1;
                Point beg = MakePoint1(N);
                if (N!=size) { beg = MakeList1(beg, N, size); }
                return beg;
            } 
            public void ShowList1(Point beg)
            {
                Console.Write("Вывод списка: ");
                if (beg == null)
                {
                    Console.WriteLine("Ошибка, список пуст! Повторите ввод.");
                    return;
                }
                Point p = beg;
                while (p != null)
                {
                    Console.Write(p);
                    p = p.next;
                }
                Console.WriteLine();
            }
            public Point SwapBeg(Point beg)
            {
                Point p = beg;
                Point NewPoint = MakePoint1(1);
                while (p.next!=null) { p = p.next;}
                p.next = NewPoint;
                beg = beg.next;
                return beg;
            }
            public void Search(Point beg, int N1, int number)
            {
                Point p = beg;
                N1++;
                if (N1 == number) { Console.WriteLine("элемент с номеройм {0} найден: {1}", number, p); return; }
                if (p.next == null) { Console.WriteLine("элемент не найден"); return; }
                Search(p.next, N1, number);
            }
            public Point Dell(Point beg, int N1, int number)
            {
                Point p = beg;
                if (p == null) return beg;
                if (number == 1) return p.next;
                N1++;
                if (N1 == number) p.next = p.next.next;
                else Dell(p.next, N1, number);
                return p;
            }
            public int wwww()
            {
                while (true)
                {
                    int number;
                    if (int.TryParse(Console.ReadLine(), out number))
                        return number;
                    else
                        Console.WriteLine("Ошибка, введите еще раз");
                }
            }
        }
    }
}

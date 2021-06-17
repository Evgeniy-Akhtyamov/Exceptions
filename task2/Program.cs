using System;
using System.Collections.Generic;

namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> lastNames = new List<string>()
            {
                "Иванов",
                "Сидоров",
                "Петров",
                "Александров",
                "Бобков"
            };
            Console.WriteLine("Дан список фамилий:");
            foreach (var item in lastNames)
            {
                Console.WriteLine(item);
            }
            NumberReader numberReader = new NumberReader();
            numberReader.NumberEnteredEvent += Sorter;
            while(true)
            {
                try
                {
                    numberReader.Read(lastNames);
                }
                catch (MyException)
                {
                    Console.WriteLine("Введено некорректное значение");
                }
            }
        }
        static void Sorter(int number, List<string> list)
        {
            switch(number)
            {
                case 1: Console.WriteLine("Введено значение 1"); 
                    list.Sort();
                    Console.WriteLine("Выполнена сортировка в алфавитном порядке:");
                    foreach (var item in list)
                    {
                        Console.WriteLine(item);
                    }
                    break;
                case 2: Console.WriteLine("Введено значение 2"); 
                    list.Sort(); 
                    list.Reverse();
                    Console.WriteLine("Выполнена сортировка в порядке обратном алфавитному:");
                    foreach (var item in list)
                    {
                        Console.WriteLine(item);
                    }
                    break;
            }
        }
    }
    class NumberReader
    {
        public delegate void NumberEnteredDelegate(int number, List<string> list);
        public event NumberEnteredDelegate NumberEnteredEvent;
        public void Read(List<string> list)
        {
            Console.WriteLine();
            Console.WriteLine("Введите значение: 1 или 2");
            string userAnswer = Console.ReadLine();
            int number;
            while (!int.TryParse(userAnswer, out number))
            {
                Console.WriteLine($"Введено не число");
                userAnswer = Console.ReadLine();
            }
            if (number != 1 && number != 2) throw new MyException("Введено некорректное значение");
            NuberEntered(number, list);
        }
        protected virtual void NuberEntered(int number, List<string> list)
        {
            NumberEnteredEvent?.Invoke(number, list);
        }
    }
    public class MyException : Exception
    {
        public MyException()
        { }
        public MyException(string message) : base(message)
        { }
    }
}

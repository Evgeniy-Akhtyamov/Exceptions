using System;

namespace Exceptions
{
    public class MyException : Exception
    {
        public MyException()
        { }
        public MyException(string message) : base(message)
        { }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Exception[] array = new Exception[5];
            array[0] = new ArgumentNullException();
            array[1] = new FormatException();
            array[2] = new IndexOutOfRangeException();
            array[3] = new InvalidCastException();
            array[4] = new MyException("Произошло собственное исключение MyException");
            try
            {
                Console.WriteLine("Создан массив исключений:");
                int i = 1;
                foreach (Exception e in array)
                {
                    Console.WriteLine($"{i}. {e.GetType()}");
                    i++;
                }
                Console.WriteLine("Введите номер исключения");
                int num = Convert.ToInt32(Console.ReadLine());
                throw array[num - 1];
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine ($"Сработало исключение 1: {array[0].Message}");
            }
            catch (FormatException)
            {
                Console.WriteLine($"Сработало исключение 2: {array[1].Message}");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine($"Сработало исключение 3: {array[2].Message}");
            }
            catch (InvalidCastException)
            {
                Console.WriteLine($"Сработало исключение 4: {array[3].Message}");
            }
            catch (MyException)
            {
                Console.WriteLine($"Сработало исключение 5: {array[4].Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошло непредвиденное исключение: {ex.Message}");
            }
            finally
            {
                Console.Read();
            }
        }
    }
}

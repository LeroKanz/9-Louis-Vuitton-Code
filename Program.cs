using System;

namespace LouisVuittonCode
{
    class Program
    {
        static void Main(string[] args)
        {
            //В методе Main можно вызывать любоые методы из классов
            //в зависимости от необходимого Кода Луи Витона и поставленной задачи.
            //например - так:

            Console.WriteLine("Code is: " + DateGenerator.GenerateLate1980Code("bc", 1987, 3));
        }
    }
}

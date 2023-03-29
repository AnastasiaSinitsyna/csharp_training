using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Practicum2
{
    internal class Program2
    {

        static bool ShouldFire2(bool enemyInFront, string enemyName, int robotHealth)
        {
            bool result = ((enemyInFront && enemyName != "boss") ||
                    (enemyInFront && enemyName == "boss" && robotHealth >= 50));
            return result;
        }
        static void Main()
        {


            /*char [] num = { 'J', 'a', 'v', 'a', '!' };
            Console.WriteLine("Элемент: " + num[2]);*/

           /* for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine("Номер элемента: " + i);
            }

            /*  double amount = 1.11; //количество биткоинов от одного человека
              int peopleCount = 60; // количество человек
              int totalMoney = (int)Math.Round(amount * peopleCount); // ← исправьте ошибку в этой строке
              Console.WriteLine(totalMoney);*/
            /*  string name;
              double salary;

              Console.WriteLine($"Hello, {name}, your salary is {salary}");*/

            /* Console.WriteLine(GetGreetingMessage("Student", 10.01));
             Console.WriteLine(GetGreetingMessage("Bill Gates", 10000000.5));
             Console.WriteLine(GetGreetingMessage("Steve Jobs", 1));*/

            /* var A = 34;
             if (((A < 50 && A != 37) && A >= 32) || A == 0 || A == 15)
                 Console.WriteLine("Working");
             else Console.WriteLine("Error!");*/

            //Сравнение строк
            /* Console.WriteLine("Введите первую строку: ");
             string FirstP = Console.ReadLine();
             Console.WriteLine("Введите вторую строку: ");
             string SecondP = Console.ReadLine();
             if (FirstP.Length > SecondP.Length)
                 Console.WriteLine("Первая строка длиннее, чем вторая");
             else if (FirstP.Length < SecondP.Length)
                 Console.WriteLine("Первая строка короче, чем вторая");
             else Console.WriteLine("Строки равны по длине");*/

            /*Console.WriteLine("Введите первое число: ");
            var num1 = Console.ReadLine();
            Console.WriteLine("Введите второе число: ");
            var num2 = Console.ReadLine();*/




        }

        /*public static string GetGreetingMessage(string name, double salary)
        {
            // возвращает "Hello, <name>, your salary is <salary>"
            salary = Math.Ceiling(salary);
            return "Hello, " + name + ", your salary is " + salary;
            
        }*/

    }
}

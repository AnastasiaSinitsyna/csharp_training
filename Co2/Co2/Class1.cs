using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Co2
{
    internal class Class1
    {
        static void Main()
        {
            /*short user_input = 11;
            switch (user_input)
            {
                case 10:
                    System.Console.WriteLine("Number is 10.");
                    break;
                case 15:
                    System.Console.WriteLine("Number is 15.");
                    break;
                default:
                    Console.WriteLine("Something else");
                    break;
            }*/
            /*Console.WriteLine("Please, write the first number: ");
             float a;
             a = Convert.ToSingle(Console.ReadLine());
             Console.WriteLine("Please, write the second number: ");
             float b;
             b = Convert.ToSingle(Console.ReadLine());
             Console.WriteLine("Please, write the arithmetic operation: ");
             string c;
             c = Console.ReadLine();    
             switch (c)
             {
                 case "+":
                     Console.WriteLine("Sum is " + (a + b));
                     break;
                     case "-":
                     Console.WriteLine("Dif is " + (a - b));
                     break;
                     case "*":
                     Console.WriteLine("Prod is " + ( a * b));
                     break;
                     case "/":
                     Console.WriteLine("Div is " + (a / b));
                     break;  
                     default:
                     Console.WriteLine("Error!");
                     break;
             }*/

            /*for (float i = 200; i > 10; i /= 2)
            {
                Console.WriteLine("Element: {0}", i);
            }*/
            /* byte i = 10; 
              while(i <= 10)
              {
                  Console.WriteLine("Element: {0}", i);
                  i--;
              }*/
            /*bool isHasCar = true;
            while (isHasCar)
            { 
                string end = Console.ReadLine();
                if (end == "end")
                    isHasCar = false;
            }*/
            /* byte i = 100;
             do
             {
                 Console.WriteLine("Element: " + i);
             }
                 while 
                 (i < 10);
         }*/
            /* for (short i = 0; i < 10; i++)
             {
                 //if (i > 5)
                 //break;
                 if (i % 2 == 0)
                 continue;
                 Console.WriteLine("Element: " + i);
             }*/
            /* for (short i = 25; i < 30; i++)
              {
                  if (i == 27) continue;
                  Console.WriteLine("Element: " + i);
              }*/
            /* int i = 24;
             while (i < 29) 
             {
                 i++;
                 if (i != 27)
                     Console.WriteLine("Element: " + i);
             }*/
            /* const int a = 13;
             int i;
             do {
                 Console.WriteLine("Please, write number 13: ");
                 i = Convert.ToInt32(Console.ReadLine());
             } while (i != a);
             Console.WriteLine("You win!");*/


            /* while (i != 13)
             {


                 byte i = Convert.ToByte(Console.ReadLine());
             }*/

            /* for (int i = -30; i <= 0; i += 3)
              {
                  if (i == -27 || i == -21 || i == -15) continue;
                  Console.WriteLine (i);
              }*/
            /* int i = -30;
             do
             {
                 if (i == -27 || i == -21 || i == -15)
                 {
                     i += 3;
                     continue;
                 }
                 Console.WriteLine(i);
                 i+= 3;
             }
             while (i <= 0);*/

            /* int i;
             do
             {
                 Console.WriteLine("Please, enter number: ");
                 int n = Convert.ToInt32(Console.ReadLine());
                 i = n;
                 if (i == 1) continue;
                 Console.WriteLine("One more iteration!");
             }
             while (i != 0);
             Console.WriteLine("That's finish.");*/

            //МАССИВЫ! Тема 8

            /*byte[] nums = new byte[5];
            nums[0] = 250;
            nums[1] = 40;
            nums[2] = 55;
            nums[3] = 61;
            nums[4] = 79;
            //System.Console.WriteLine("El: " + nums[0]);

            string[] words = new string[] { "John", "Bob", "Alex" };
            words[1] = "Josh";
            for (byte i = 0; i < nums.Length; i++)
                System.Console.WriteLine("El: " + nums[i]);
            for (byte a = 0; a < words.Length; a++)
                System.Console.WriteLine("El: " + words [a]);*/

            /* short[] numbers = new short[10];
             Random random = new Random();
             short summa = 0;
             for (byte i = 0; i < numbers.Length; i++)
             {
                 numbers[i] = Convert.ToInt16(random.Next(-15, 15));
                 Console.WriteLine("El: " + numbers[i]);

                 summa += numbers[i];
             }
             Console.WriteLine("Summa: " + summa);*/

            /*char[,] symbols = new char[2, 3];
            symbols[0, 0] = 'H';
            Console.WriteLine(symbols[0, 0]);

            int[,] nums = {
            {4, 6, 7},
            {8,9, 10},
            {3, 2, 1}
            };
            nums[1, 2] = 56; 
            */

            /*   int[] array_1 = { 1, 2, 3, 5, 7, 9, 10 };
               int[] array_2 = { 1, 4, 3, 5, 8, 9, 0 };
               string res = "";

               for (int i = 0; i < array_1.Length; i++)
               {
                   for (int a = 0; a < array_2.Length; a++);
                   if (array_1[i] == array_2[i])
                   {
                       res += array_1[i] + "; ";
                   }
               }
               Console.WriteLine(res);*/

            int[,] numbers = new int [2, 3] { { 0, 34, -2 }, { 3, -4, 5 } };
            int min_num = numbers [0, 0];
            for (int y = 0; y < 2; y++)
            { 
                for (int f = 0; f < 3; f++)
                {
                    if (numbers[y, f] < min_num)
                        min_num = numbers[y, f];
                }
            }
            Console.Write("Minimum number: " + min_num);
        }
    }
}

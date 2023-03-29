using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practicum
{
    internal class Program
    {
        static void Mai()
       {
            /* byte num_1 = 5;
              char sim = 'F';
              string sms = "Привет!";
              float num_2 = 90.2f;
              const byte num_3 = 67;
              Console.WriteLine(sms);*/

            /* Console.WriteLine("Введите имя: ");
             string name = Console.ReadLine();
             Console.WriteLine("Введите возраст: ");
             byte age = Convert.ToByte(Console.ReadLine());
             Console.WriteLine("Привет, " + name + "! Тебе уже " + age);
            
             int a = n * 2;
            Convert.ToString(a);
             */

            /* int a = 2642; // всего дней
             int b; //  Всего недель
             int c; // Кол-во недель
             int d; // Кол-во дней
             int e; // Кол-во лет

             d = a % 7; 
             b = (a - d) / 7; 
             c = b % 52; 
             e = (b - c) / 52;
             Console.WriteLine("Количество лет: " + e + " Количество недель: " + c + " Количество дней: " + d);*/

            /*  Console.WriteLine("Введите первое число: ");
              short a = Convert.ToInt16(Console.ReadLine());
              Console.WriteLine("Введите второе число: ");
              short b = Convert.ToInt16(Console.ReadLine());
              short c = a;
              a = b;
              b = c;
              Console.WriteLine("Первое число: " + a + " Второе число: " + b);*/

            // ПОЛУЧЕНИЕ ДАННЫХ - отметить выполненным
            /* Console.WriteLine("Введите имя: ");
             string name = Console.ReadLine();
             Console.WriteLine("Введите возраст: ");
             byte age = Convert.ToByte(Console.ReadLine());
             Console.WriteLine("Есть машина? True/False: ");
             bool car = Convert.ToBoolean(Console.ReadLine());
             Console.WriteLine("Имя: " + name + ", Возраст: " + age + ", Машина: " + car);*/

            // ОПЕРАЦИИ НАД ПЕРЕМЕННОЙ - отметить выполненным
            /*short a = -5;
            a *= 7;
            a--;
            Console.WriteLine(a);*/

            // РАЗНЫЕ ТИПЫ ПЕРЕМЕННЫХ - отметить выполненным
            /* short a = -34;
             byte b = 4;
             string c = "Hello";
             char d = 'R';
             double e = 23.093433222f;
             short i = 30000;
             bool f = true;
             byte g = 0;
            */

            // НАХОЖДЕНИЕ ЧИСЛА - отметить выполненным
            /*Console.WriteLine("Введите число N");
            string n = Console.ReadLine();
            int a = Convert.ToInt32(n);
            a = a * 2;
            Console.WriteLine(n + a);*/

            // - отметить выполненным
            /* Console.WriteLine("Введите число с 4 цифрами: ");
              int a = Convert.ToInt32(Console.ReadLine());
              int n1 = a / 1000 % 10;
              int n2 = a / 100 % 10;
              int n3 = a / 10 % 10;
              int n4 = a % 10;
              Console.WriteLine(n1);
              Console.WriteLine(n2);
              Console.WriteLine(n3);
              Console.WriteLine(n4);*/

            //ДАННЫЕ ОТ ПОЛЬЗОВАТЕЛЯ
            // Простой калькулятор - отметить выполненным

            /*Console.WriteLine("Введите первое число: ");
            int n1 = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Введите второе число: ");
            int n2 = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("1. Добавить.");
            Console.WriteLine("2. Отнять.");
            Console.WriteLine("3. Ничего.");
            byte x = Convert.ToByte(Console.ReadLine());
            int res;
            if (x == 1)
            {
            res = n1 + n2;
            Console.WriteLine("Результат сложения: " + res);
            }
            else if (x == 2)
            {
                res = n1 - n2;
                Console.WriteLine("Результат вычитания: " + res);
            }
            else if (x == 3)
            {
                Console.WriteLine("Всего хорошего!");
            }
            else
            {
                Console.WriteLine("Выберите действие 1, 2 или 3");
            }*/

            // Константы - отметить выполненным
            /*  const float a = 20f;
              Console.WriteLine("Введите число: ");
              float b = Convert.(Console.ReadLine());
              float res1 = a + b;
              float res2 = a - b;
              float res3 = a * b;
              float res4 = a / b;
              Console.WriteLine("Сложение: " + res1);
              Console.WriteLine("Вычитание: " + res2);
              Console.WriteLine("Умножение: " + res3);
              Console.WriteLine("Деление: " + res4);

            const float a = 20f;
            Console.WriteLine("Введите число: ");
            float b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Сложение: " + (a + b).ToString());
            Console.WriteLine("Вычитание: " + (a - b).ToString());
            Console.WriteLine("Умножение: " + (a * b).ToString());
            Console.WriteLine("Деление: " + (a / b).ToString());*/

            //Работа с переменными - отметить выполненным
            /* Console.WriteLine("Введите имя: ");
             string name = Console.ReadLine();
             Console.WriteLine("Введите фамилию: ");
             string sername = Console.ReadLine();
             Console.WriteLine("Введите возраст: ");
             byte age = Convert.ToByte(Console.ReadLine());
             Console.WriteLine("Ваше имя: " + name + ". Ваша фамилия: " + sername + ". Ваш возраст: " + age + ".");*/

            // Остаток при деление - отметить выполненным
            /* Console.WriteLine("Введите первое число: ");
             int n1 = Convert.ToInt32(Console.ReadLine());
             Console.WriteLine("Введите второе число: ");
             int n2 = Convert.ToInt32(Console.ReadLine());
             Console.WriteLine("Результат операции: " + (n1 % n2).ToString());*/

            // Поле из символов
            /*Console.WriteLine("Введите число: ");
            byte num = Convert.ToByte(Console.ReadLine());
            // string num2 = Convert.ToString(num);
            string num2 = num.ToString();
            Console.WriteLine(num2 + num2 + num2 + num2);
            Console.WriteLine(num2 + "  " + num2);
            Console.WriteLine(num2 + "  " + num2);
            Console.WriteLine(num2 + num2 + num2 + num2);*/

            /*Console.WriteLine("Введите число: ");
            byte num = Convert.ToByte(Console.ReadLine());
            Console.WriteLine("{0}{0}{0}{0}", num);
            Console.WriteLine("{0}  {0}", num);
            Console.WriteLine("{0}  {0}", num);
            Console.WriteLine("{0}{0}{0}{0}", num);*/

            /*  Console.WriteLine("Введите первое число: ");
              float n1 = Convert.ToInt32(Console.ReadLine());
              Console.WriteLine("Введите второе число: ");
              float n2 = Convert.ToInt32(Console.ReadLine());
              Console.WriteLine("Введите действие: ");
              char d = Convert.ToChar(Console.ReadLine());
              if (d == '+')
                  Console.WriteLine(n1 + n2);
              else if (d == '-')
                  Console.WriteLine(n1 - n2);
              else if (d == '*')
                  Console.WriteLine(n1 * n2);
              else if (d == '/')
                  if (n2 == 0)
                      Console.WriteLine("Делить на ноль нельзя!");
                  else Console.WriteLine(n1 / n2);
              else
                  Console.WriteLine("Введите действие: +, -, *, /");*/

            /*  Console.WriteLine("Введите первое число: ");
              int n1 = Convert.ToInt32(Console.ReadLine());
              Console.WriteLine("Введите второе число: ");
              int n2 = Convert.ToInt32(Console.ReadLine());
              if (n1 % 2 == 0 && n2 % 2 == 0)
                  Console.WriteLine("True");
              else
                  Console.WriteLine("False");*/

            /* Console.WriteLine("Введите первое число: ");
             int n1 = Convert.ToInt32(Console.ReadLine());
             Console.WriteLine("Введите второе число: ");
             int n2 = Convert.ToInt32(Console.ReadLine());
             bool res = ((n1 % 2 == 0) && (n2 % 2 == 0)) ? true : false;
             Console.WriteLine(res);*/

            /*Console.WriteLine("Здравствуйте! Введите выручку: ");
            long revenue = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Введите затраты: ");
            long expenses = Convert.ToInt64(Console.ReadLine());
            if (revenue > expenses)
                Console.WriteLine("Ваша прибыль равна: " + (revenue - expenses));
            else if (revenue < expenses)
                Console.WriteLine("Ваш убыток равен: " + (expenses - revenue));
            else if (revenue == expenses)
                Console.WriteLine("Вы вышли в ноль!");*/

            /*Console.WriteLine("Привет! Введите возраст: ");
            byte age = Convert.ToByte(Console.ReadLine());
            if (age == 18)
                Console.WriteLine("Hoho, you're 18!");
            else if (age > 18)
                Console.WriteLine("You can do everything");
            else if (age < 18)
            Console.WriteLine("You are too young");*/

            /*  Console.WriteLine("Введите день недели: ");
              byte day = Convert.ToByte(Console.ReadLine());
              switch (day)
              {
                  case 1 :
                      Console.WriteLine("Monday.");
                      break;
                  case 2 :
                      Console.WriteLine("Tuesday.");
                      break;
                  case 3 : 
                      Console.WriteLine("Wednesday.");
                      break;
                  case 4 :
                      Console.WriteLine("Thursday");
                      break;
                  case 5 :
                      Console.WriteLine("Friday.");
                      break;
                  case 6 :
                      Console.WriteLine("Saturday.");
                      break;
                  case 7 :
                      Console.WriteLine("Sunday.");
                      break;
                  default:
                      Console.WriteLine("Enter the correct day of the week.");
                      break;
              }   */

            /*   Console.WriteLine("Введите первое число: ");
               float n1 = Convert.ToInt32(Console.ReadLine());
               Console.WriteLine("Введите второе число: ");
               float n2 = Convert.ToInt32(Console.ReadLine());
               Console.WriteLine("Введите действие: ");
               char d = Convert.ToChar(Console.ReadLine());
               float res;
               switch (d)
               {
                   case '+' :
                       res = n1 + n2;
                       Console.WriteLine("Результат сложения: " + res);
                   break;
                   case '-' : 
                       res = n1 - n2;
                       Console.WriteLine("Результат вычитания: " + res);
                       break;
                   case '*' :
                       res = n1 * n2;
                       Console.WriteLine("Результат умножения: " + res);
                       break;
                   case '/' :
                       res = n1 / n2;
                       Console.WriteLine("Результат деления: " + res);
                       break;
                   default :
                       Console.WriteLine("Введите корректное действие (+, -, *, /)");
                       break;

               }*/

            /* Console.WriteLine("Введите первое число: ");
             int n1 = Convert.ToInt32(Console.ReadLine());
             Console.WriteLine("Введите второе число: ");
             int n2 = Convert.ToInt32(Console.ReadLine());
             if (n1 % 2 == 0 && n2 % 2 != 0) 
             {
                 Console.WriteLine("Четное число: " + n1);
             }
             else if (n2 % 2 == 0 && n1 % 2 != 0)
             {
                 Console.WriteLine("Четное число: " + n2);
             }
             else if (n2 % 2 == 0 && n1 % 2 == 0)
             {
                 Console.WriteLine("Оба числа четные.");
             }
             else 
             {
                 Console.WriteLine("Оба числа нечетные.");
             }*/

            /* byte a = 11;
             switch (a)
             {
                 case 10 :
                     Console.WriteLine("Number is 10");
                     break;
                 case 15 :
                     Console.WriteLine("Number is 15");
                     break;
                 default :
                     Console.WriteLine("Something else");
                     break;
             }*/
            /*
            Console.WriteLine("Hi! Enter number: ");
            int n1 = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i <= n1; i++)
            if (n1 % i == 0)
            Console.Write(i + ", ");
            */

            /*
            Console.WriteLine("Please, enter numbers of array: ");
            int n = Convert.ToInt32(Console.ReadLine());

            int [] num = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Enter " + (i + 1) + " element");
                num[i] = Convert.ToInt32(Console.ReadLine());
            }
            for (int b = 0; b < n; b++)
                Console.Write(num[b] + ", ");*/

            /*Console.WriteLine("Привет! Введите число рядов: ");
            int n1 = Convert.ToInt32(Console.ReadLine());
            
            for (int i = 1; i <= n1; i++)
            {
                for (int j = 1; j <= i; j++)
                Console.Write(i);
            
            Console.WriteLine("");
            }*/


            /*  int res = 0;
              for (int i = 1; i <= 100; i++)
              {
                  if (i % 4 == 0)
                      res += i;
              }   
              Console.WriteLine(res);*/

            /* Console.WriteLine("Введите первое число: ");
             double n1 = Convert.ToDouble(Console.ReadLine());
             Console.WriteLine("Введите второе число: ");
             double n2 = Convert.ToDouble(Console.ReadLine());
             Console.WriteLine("Введите третье число: ");
             double n3 = Convert.ToDouble(Console.ReadLine());

             double res = (n1 + n2 + n3) / 3;

             if (n1 == n2 && n2 == n3)
                 Console.WriteLine("Error!");
             else Console.WriteLine(res);*/

            /*int[] numbers = { 24, -63, 67, -12, 88, 94, -28, 82, 0, 53 };
            int max = numbers[0];
            int min = numbers[0];

            for (int i = 0; i < numbers.Length; i++)
            {   
               if (numbers [i] > max)
                max = numbers[i];
            }
            Console.WriteLine(max);
            for (int g = 0; g < numbers.Length; g++)
            {
                if (numbers[g] < min)
                    min = numbers[g];
            }
            Console.WriteLine(min);*/

            /*  double[] mass = { 5, 8, 18, 34, 3, 56, 43, 27, 4, 23 };
              double sum = 0;
              for (int i = 0; i < mass.Length; i++)
              {
                  sum += mass[i];
              }
              Console.WriteLine("Сумма: " + sum);
              double res = sum / mass.Length;
              Console.WriteLine("Среднее арифметическое: " + res);

              for (int g = 0; g < mass.Length; g++)
              {
                  if (mass[g] > res)
                      Console.Write(mass[g] + ", ");
              }*/

            /*  int[] array1 = {1, 2, 3, 5, 7, 9, 10 };
              int[] array2 = {1, 4, 3, 5, 8, 9, 0 };
              string res = "";

              for (int i = 0; i < array1.Length; i++) 
              { 
                  for (int g = 0; g < array2.Length; g++) 
                  { 
                      if (array1[i] == array2[g])
                          res += array2[g] + ", ";
                  }
              }
              Console.Write(res);*/

            /*  int[] array1 = { 0, 34, 2, 9, 12, 18, 3, 4, 5 };
              int temp;

              for (int i = 0; i < array1.Length - 1; i++)
              {
                  for (int g = 0; g < array1.Length - i - 1; g++)
                  {
                      if (array1[g] > array1[g + 1])
                      {
                          temp = array1[g];
                          array1[g] = array1[g + 1];
                          array1[g + 1] = temp;
                      }
                  }
              }
              Console.Write("Res: ");
              for (int a = 0; a < array1.Length; a++)
                  Console.Write(array1[a] + ", ");*/

            //Динамические массивы


            /*  List<string> numbers = new List<string> ()
              {
                  "Bye", "Oh", "Hello", "Hi", "Green"
              };

              foreach (string i in numbers)
              {
                  if (i == "Hi")
                      Console.WriteLine("Word \"Hi\" is in the array!");
                  Console.WriteLine(i + ", ");
              }*/

            /* List<int> num = new List<int> ();
             num.Add (50);
             num.Add(23);
             num.Add(1523);
             num.Add(45);
             num.Add(988);
             num.Add(4874);
             num.Add(0); 
             int max = num.Max ();

             Console.WriteLine (max);*/

            /* string num = "";
             while (string.IsNullOrWhiteSpace(num)) {
                 Console.WriteLine("Пожалуйстаю введите Вашу строку: ");
                 num = Console.ReadLine();
             }
             Console.WriteLine("Спасибо!");*/

            /*   Print("Hello!");
               string words = "Hello world!";
               Print(words);
               Print();*/

            /*  int res1 = Summa(5, 10);
               int a = 17, b = 2;
               int res2 = Summa(a, b);

               Print(res1.ToString());
               Print(res2.ToString());
           }

          public static void Print(string word) 
           {
               Console.WriteLine(word);
           }

           public static int Summa(int x, int y)
           {
               return x + y;*/
            /*  byte[] nums = { 10, 5, 89, 23, 0 };
              byte res1 = Summa(nums);
              Console.WriteLine("Результат: " + res1);

            int km = Dist(5, 1);
            Text(km);*/

            /*  Console.WriteLine("Напишите первое число: ");
              int a = Convert.ToInt32(Console.ReadLine());
              Console.WriteLine("Напишите второе число: ");
              int b = Convert.ToInt32(Console.ReadLine());
              char res = Res(a, b);
              Console.WriteLine("Ваш результат: " + a + res + b + ".");
          }*/

            /*public static byte Summa(byte[] digits)
                {
                    byte summ = 0;
                    foreach (byte el in digits)
                        summ += el;

                    return summ;
            }*/

            /* public static int Dist(int x, int y)
             {
                 int res = x * y;
                 return res;
             }

             public static void Text(int km)
             {
                 string word = km == 1 ? "Вы проедете 1 километр." : "Вы проедете: " + km + " километров.";
                     Console.WriteLine(word);

             }*/
            /*
             public static char Res(int num1, int num2)
             {
                 if (num1 < num2)
                 {
                     return '<';
                 }
                 else if (num1 > num2)
                 {
                     return '>';
                 } 
                 else if (num1 == num2)
                 {
                     return '=';
                 }
                 else {
                     return 'e';
                 }
             }*/


        }
    }
}

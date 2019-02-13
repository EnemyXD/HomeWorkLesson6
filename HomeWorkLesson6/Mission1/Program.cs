using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

//Калмыков

//Изменить программу вывода функции так, чтобы можно было передавать функции типа double (double,double). 
//Продемонстрировать работу на функции с функцией a*x^2 и функцией a*sin(x).

namespace Mission1
{
    
    public delegate double FunXA(double x, double a);

    class Program
    {       

        public static void TableFor2Args(FunXA F, double x, double b, double a)
        {
            Console.WriteLine("----- X ----- Y -----");
            while (x <= b)
            {
                Console.WriteLine("| {0,8:0.000} | {1,8:0.000} |", x, F(x, a));
                x += 1;
            }
            Console.WriteLine("---------------------");
        }
        
        public static double MyFuncAX2(double x, double a)
        {
            return a * x * x;
        }

        public static double MyFuncASINX(double x, double a)
        {
            return a * Math.Sin(x);
        }

        static void Main()
        {          
            Console.WriteLine("Таблица функции a*x^2");
            TableFor2Args(MyFuncAX2, -2, 2, 2);

            Console.WriteLine("Таблица функии a*sin(x)");
            TableFor2Args(new FunXA(MyFuncASINX), -2, 2, 2);

            Console.ReadKey();
        }

    }
}

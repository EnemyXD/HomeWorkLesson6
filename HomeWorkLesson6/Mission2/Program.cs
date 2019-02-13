using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Калмыков

//Модифицировать программу нахождения минимума функции так, чтобы можно было передавать функцию в виде делегата.
//а) Сделайте меню с различными функциями и предоставьте пользователю выбор, для какой функции и на каком отрезке находить минимум.
//б) Используйте массив(или список) делегатов, в котором хранятся различные функции.

namespace Mission2
{
    public delegate double Fun(double x);

    class Program
    {
        
        public static double FuncXXminus50Xplus10(double x)
        {
            return x * x - 50 * x + 10;
        }
        public static void SaveFunc(string fileName, double a, double b, double h,Fun F)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            double x = a;
            while (x <= b)
            {
                bw.Write(F(x));
                x += h;// x=x+h;
            }
            bw.Close();
            fs.Close();
        }
        public static double Load(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);
            double min = double.MaxValue;
            double d;
            for (int i = 0; i < fs.Length / sizeof(double); i++)
            {
                // Считываем значение и переходим к следующему
                d = bw.ReadDouble();
                if (d < min) min = d;
            }
            bw.Close();
            fs.Close();
            return min;
        }
        static void Main(string[] args)
        {
            Fun b = new Fun(FuncXXminus50Xplus10);
            Fun[] a = new Fun[3]; // (FuncXXminus50Xplus10);
            a[0] = FuncXXminus50Xplus10;
            a[1] = Math.Sin;
            a[2] = Math.Cos;

            while (true)
            {
                

                Console.WriteLine("Введите цифру: 1-Функция x * x - 50 * x + 10, 2-Функция sin(x), 3-Функция сos(x)");
                int i = Convert.ToInt32(Console.ReadLine());

                //switch (i)
                //{
                //    case 1:
                //        b = a[0];
                //        break;
                //    case 2:
                //        b = a[1];
                //        break;
                //    case 3:
                //        b = a[2];
                //        break;
                //    default:
                //        break;
                //}


                SaveFunc("data.bin", -100, 100, 0.5, a[i - 1]);
                Console.WriteLine(Load("data.bin"));
            }

            Console.ReadKey();
        }
    }
}

     
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace Problem_1_Multithreading2
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter the inputs");
            double a = Convert.ToDouble(Console.ReadLine());
            double b =Convert.ToDouble(Console.ReadLine());

            Thread t1 = new Thread(() => Operation("Addtion", a, b,(x,y)=>x+y, 1000));
            Thread t2 = new Thread(() => Operation("Substraction", a, b, (x, y) => x - y, 2000));
            Thread t3 = new Thread(() => Operation("Multiplication", a, b, (x, y) => x * y, 3000));
            Thread t4 = new Thread(() => Operation("Division", a, b, (x, y) => x / y, 4000));


            t1.Start();
            t2.Start();
            t3.Start(); 
            t4.Start();


            t1.Join();
            t2.Join();  
            t3.Join();
            t4.Join(); 
        }

        static void Operation(string Opeation_name,double a,double  b,Func<double,double,double>operation,int delay)
        {
            Thread.Sleep(delay);

            double result = operation(a, b);
            Console.WriteLine(result);
           string msg = $"{Opeation_name} of {a} and {b} is {result}";
 

            Console.WriteLine("Logging in log file");
            Log(msg);
        }

        static void Log(string msg)
        {
            using (StreamWriter str = new StreamWriter("C:\\Users\\sinanant\\C#\\Sheet Problem\\Problem-1-Multithreading2\\log.txt",true))
            {
                str.Write(msg);
                str.Write('\n');
                str.Flush();

            }
        }
    }
}

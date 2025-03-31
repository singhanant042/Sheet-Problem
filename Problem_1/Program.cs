using System;
using System.IO;



public abstract class Calculate
{
    public  abstract double area_of_triangle(int x, int y);
    public abstract int area_of_rectangle(int x, int y);   
}

public class Calculate_area:Calculate
{
    public override double  area_of_triangle(int x,int y)
    {
        return 0.5 * x * y;
    }

    public override int area_of_rectangle(int x, int y)
    {
        return x * y;
    }
}


namespace Problem_1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter the value of length");
            int x = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the value of breadth");
            int y = int.Parse(Console.ReadLine());

            Calculate_area c = new Calculate_area();

            double  area_1 = c.area_of_triangle(x, y);
            int area_2 = c.area_of_rectangle(x, y);

            Console.WriteLine("Area of triangle = {0} ", area_1 );
            Console.WriteLine("Area of rectangle = {0} ",area_2 );

            StreamWriter str = new StreamWriter(@"C:\Users\sinanant\C#\Sheet Problem\Problem_1\log.txt");
            str.Write("Area of triangle = {0} ", area_1);
            str.Write('\n');
            str.Write("Area of rectangle = {0} ", area_2);
            str.Close();


        }
    }
}

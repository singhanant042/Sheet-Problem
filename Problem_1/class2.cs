using System;

public interface ICalcualte
{
    double area_triangle(int x,int y);
      int  area_rectangle(int x, int y);
}

public  class Calculate_Area:ICalcualte
{
    public double area_triangle(int x,int y)
    {
        return 0.5* x * y;
    }

    public int area_rectangle(int x,int y)
    {
        return x * y;
    }
}
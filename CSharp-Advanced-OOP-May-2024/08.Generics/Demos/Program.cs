using System;

Square square = new(5);
Reactangle reactangle = new(5, 10);

SurfacePrinter<Square> sp = new();
SurfacePrinter<Reactangle> sp2 = new();
SurfacePrinter<Something> sp3 = new();

sp.PrintSurface(square);
sp2.PrintSurface(reactangle);
sp3.PrintSurface(new Something());

public class SurfacePrinter<T> where T : IGeometricFigure
{
    public void PrintSurface(T figure)
    {
        Console.WriteLine(figure.CalculateSurface());
    }
}

public interface IGeometricFigure
{
    double CalculateSurface();
}

public class Square : IGeometricFigure
{
    int side;

    public Square()
    {

    }

    public Square(int side)
    {
        this.side = side;
    }

    public double CalculateSurface()
    {
        return side * side;
    }
}

public class Reactangle : IGeometricFigure
{
    int length;
    int width;

    public Reactangle(int length, int width)
    {
        this.length = length;
        this.width = width;
    }

    public double CalculateSurface()
    {
        return length * width;
    }
}

public class Something : IGeometricFigure
{
    public double CalculateSurface()
    {
        return 42;
    }
}
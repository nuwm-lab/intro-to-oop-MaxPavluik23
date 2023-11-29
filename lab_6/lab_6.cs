using System;

interface IFraction
{
    void Print();
    double Calculate(double x);
}

abstract class AbstractFraction : IFraction
{
    public abstract void Print();
    public abstract double Calculate(double x);
}

class Fraction : AbstractFraction
{
    protected double a;

    public Fraction(double a)
    {
        this.a = a;
    }

    public override void Print()
    {
        Console.WriteLine($"Значення дробу: 1/{a}x");
    }

    public override double Calculate(double x)
    {
        if (x == 0)
        {
            Console.WriteLine("Ділення на нуль не допускається.");
            return double.NaN;
        }
        return 1 / (a * x);
    }
}

class ThreeDimensionalFraction : AbstractFraction
{
    private double a;
    private double a2;
    private double a3;

    public ThreeDimensionalFraction(double a, double a2, double a3)
    {
        this.a = a;
        this.a2 = a2;
        this.a3 = a3;
    }

    public override void Print()
    {
        Console.WriteLine($"Значення дробу: 1/({a}x + 1/({a2}x + 1/({a3}x)))");
    }

    public override double Calculate(double x)
    {
        if (x == 0 || a3 == 0)
        {
            Console.WriteLine("Ділення на нуль не допускається та a3 має бути нерівним нулю.");
            return double.NaN;
        }

        return 1 / (a * x + 1 / (a2 * x + 1 / (a3 * x)));
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Введіть значення a, a2, a3 та x для обчислення дробів:");

        double a = Convert.ToDouble(Console.ReadLine());
        double a2 = Convert.ToDouble(Console.ReadLine());
        double a3 = Convert.ToDouble(Console.ReadLine());
        double x = Convert.ToDouble(Console.ReadLine());

        AbstractFraction fraction;
        AbstractFraction threeDimensionalFraction;

        if (a2 == 0 && a3 == 0)
        {
            fraction = new Fraction(a);
            fraction.Print();
            double result = fraction.Calculate(x);
            Console.WriteLine($"Значення дробу 1/{a}x у точці x = {x} дорівнює {result}");
        }
        else
        {
            threeDimensionalFraction = new ThreeDimensionalFraction(a, a2, a3);
            threeDimensionalFraction.Print();
            double result = threeDimensionalFraction.Calculate(x);
            Console.WriteLine($"Значення тривимірного похідного дробу 1/({a}x + 1/({a2}x + 1/({a3}x))) у точці x = {x} дорівнює {result}");
        }
    }
}

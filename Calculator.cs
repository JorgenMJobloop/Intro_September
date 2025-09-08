public class Calculator : ICalculator
{
    public double Add(double a, double b)
    {
        return a + b;
    }
    public double Subtract(double a, double b)
    {
        return a - b;
    }
    public double Multiply(double a, double b)
    {
        return a * b;
    }
    public double Divide(double a, double b)
    {
        if (b == 0)
        {
            throw new DivideByZeroException("Cannot divide by 0!");
        }
        return a / b;
    }

    public double Power(double a, double exponent)
    {
        return Math.Pow(a, exponent);
    }

    public double Cosine(double a)
    {
        return Math.Cos(a);
    }
}
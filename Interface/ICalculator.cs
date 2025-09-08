public interface ICalculator
{
    /// <summary>
    /// This method takes in two numbers and adds them together
    /// </summary>
    /// <param name="a">the value of parameter a: double</param>
    /// <param name="b">the value of parameter b: double</param>
    /// <returns>a + b: double</returns>
    double Add(double a, double b);
    /// <summary>
    /// This method takes in two numbers and subtracts b from a
    /// </summary>
    /// <param name="a">the value of parameter a: double</param>
    /// <param name="b">the value of parameter b: double</param>
    /// <returns>a - b: double</returns>
    double Subtract(double a, double b);
    /// <summary>
    /// This method takes in two numbers and multiplies them together
    /// </summary>
    /// <param name="a">double</param>
    /// <param name="b">double</param>
    /// <returns>sum of a * b</returns>
    double Multiply(double a, double b);
    /// <summary>
    /// This method takes in two numbers and divides them, unless b is 0, then we throw an exception.
    /// </summary>
    /// <param name="a">double</param>
    /// <param name="b">double</param>
    /// <returns>sum of a / b when b != 0</returns>
    double Divide(double a, double b);
}
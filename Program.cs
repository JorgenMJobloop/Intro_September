namespace Intro;

class Program
{
    static void Main(string[] args)
    {
        Calculator calculator = new Calculator();

        // We can take in user-input, by utilizing the Console class.

        Console.WriteLine("To use the calculator:\nSelect an operator:\n+, -, *, /\nFunctions: ^, cos");

        while (true)
        {
            // Here, the user can select which operator to use in the calculator.
            string? userInput = Console.ReadLine();

            if (string.Equals(userInput, "q", StringComparison.OrdinalIgnoreCase) || string.Equals(userInput, "exit", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Exiting program..");
                break;
            }

            // We call the Tuple method we created to get the values of number a and number b
            (double a, double b)? values = GetUserInput();

            double a = values!.Value.a;
            double b = values!.Value.b;

            // We use a Tuple method to clean up the code.
            (double, double)? GetUserInput()
            {
                Console.WriteLine("Enter a number:");
                string? inputA = Console.ReadLine();

                Console.WriteLine("Enter a second number:");
                string? inputB = Console.ReadLine();

                bool validA = double.TryParse(inputA, out double a);
                bool validB = double.TryParse(inputB, out double b);

                if (!validA || !validB)
                {
                    return null;
                }

                return (a, b);
            }

            switch (userInput)
            {
                case "+":
                    Console.WriteLine($"Sum of {a} + {b} = {calculator.Add(a, b)}");
                    break;
                case "-":
                    Console.WriteLine($"Sum of {a} - {b} = {calculator.Subtract(a, b)}");
                    break;
                case "*":
                    Console.WriteLine($"Sum of {a} * {b} = {calculator.Multiply(a, b)}");
                    break;
                case "/":
                    Console.WriteLine($"Sum of {a} / {b} = {calculator.Divide(a, b)}");
                    break;
                case "^":
                    Console.WriteLine($"Power of {a} to {b} = {calculator.Power(a, b)}");
                    break;
                case "cos":
                    Console.WriteLine($"Cosine of {a} = {calculator.Cosine(a)}");
                    break;
                default:
                    break;
            }
        }
    }
}

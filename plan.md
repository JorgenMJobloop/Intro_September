# TODO
    - Write a CLI tool, that displays information about the user of the program, they submit themself, as well as a simple calculator in the commandline.

# Psuedocode

```csharp
// File: Program.cs
// Variables
double a = 25;
double b = 10;


// Classes
Calculator.cs implements ICalculator

Calculator calc = new Calculator();

// Interface
ICalculator.cs
```

# Calculator.cs class
```csharp
// File: Calculator.cs

public class Calculator : ICalculator 
{
    public double Add(double a, double b) 
    {
        return a + b;
    }
}
```

```java
public interface ICalculator {
    double addNumbers(double a, double b);
}

public class Calculator implements ICalculator {
    public double addNumbers(double a, double b) {
        return a + b;
    }
}



```


# Flowchart

using DotnetCalc;

/// <summary>
/// Entry point for the calculator command-line application.
/// </summary>
internal static class Program
{
    /// <summary>
    /// Execute the calculator with command-line arguments.
    /// </summary>
    /// <param name="args">The first number, second number, and operator.</param>
    /// <returns>A process exit code.</returns>
    private static int Main(string[] args)
    {
        if (args.Length != 3)
        {
            Console.Error.WriteLine("Usage: dotnet run --project DotnetCalc.csproj -- <number1> <number2> <operator>");
            return 1;
        }

        if (!double.TryParse(args[0], out var firstNumber) || !double.TryParse(args[1], out var secondNumber))
        {
            Console.Error.WriteLine("Both operands must be valid numbers.");
            return 1;
        }

        var engine = new CalculatorEngine();

        try
        {
            var result = engine.Calculate(firstNumber, secondNumber, args[2]);
            Console.WriteLine(result);
            return 0;
        }
        catch (Exception ex) when (ex is ArgumentException or InvalidOperationException or DivideByZeroException)
        {
            Console.Error.WriteLine(ex.Message);
            return 1;
        }
    }
}

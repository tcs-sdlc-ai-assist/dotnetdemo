namespace DotnetCalc;

/// <summary>
/// Provides arithmetic operations for the calculator application.
/// </summary>
public class CalculatorEngine
{
    /// <summary>
    /// Calculate the result for the supplied operands and operation.
    /// </summary>
    /// <param name="a">The left operand.</param>
    /// <param name="b">The right operand.</param>
    /// <param name="operation">The arithmetic operator symbol.</param>
    /// <returns>The computed numeric result.</returns>
    /// <exception cref="ArgumentException">Thrown when the operator is blank.</exception>
    /// <exception cref="DivideByZeroException">Thrown when division by zero is attempted.</exception>
    /// <exception cref="InvalidOperationException">Thrown when the operator is unsupported.</exception>
    public double Calculate(double a, double b, string operation)
    {
        if (string.IsNullOrWhiteSpace(operation))
        {
            throw new ArgumentException("Operation is required.", nameof(operation));
        }

        return operation.Trim() switch
        {
            "+" => a + b,
            "-" => a - b,
            "*" => a * b,
            "/" when b == 0 => throw new DivideByZeroException("Cannot divide by zero."),
            "/" => a / b,
            _ => throw new InvalidOperationException($"Unsupported operation '{operation}'.")
        };
    }
}

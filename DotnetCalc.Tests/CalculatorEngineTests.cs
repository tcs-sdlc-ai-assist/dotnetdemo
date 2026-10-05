using DotnetCalc;
using Xunit;

namespace DotnetCalc.Tests;

/// <summary>
/// Verifies calculator engine arithmetic behavior and error handling.
/// </summary>
public class CalculatorEngineTests
{
    private readonly CalculatorEngine _engine = new();

    /// <summary>
    /// Return expected results for supported calculator operations.
    /// </summary>
    /// <param name="left">The left operand.</param>
    /// <param name="right">The right operand.</param>
    /// <param name="operation">The operation symbol.</param>
    /// <param name="expected">The expected result.</param>
    [Theory]
    [InlineData(10, 5, "+", 15)]
    [InlineData(10, 5, "-", 5)]
    [InlineData(10, 5, "*", 50)]
    [InlineData(10, 5, "/", 2)]
    public void Calculate_supported_operation_returns_expected_result(double left, double right, string operation, double expected)
    {
        var result = _engine.Calculate(left, right, operation);

        Assert.Equal(expected, result);
    }

    /// <summary>
    /// Reject unsupported operation symbols.
    /// </summary>
    [Fact]
    public void Calculate_unsupported_operation_throws_invalid_operation_exception()
    {
        Action action = () => _engine.Calculate(4, 2, "%");

        var exception = Assert.Throws<InvalidOperationException>(action);

        Assert.Contains("Unsupported operation", exception.Message);
    }

    /// <summary>
    /// Reject divide-by-zero operations.
    /// </summary>
    [Fact]
    public void Calculate_divide_by_zero_throws_divide_by_zero_exception()
    {
        Action action = () => _engine.Calculate(4, 0, "/");

        var exception = Assert.Throws<DivideByZeroException>(action);

        Assert.Contains("Cannot divide by zero", exception.Message);
    }

    /// <summary>
    /// Reject blank operations before attempting calculation.
    /// </summary>
    [Fact]
    public void Calculate_blank_operation_throws_argument_exception()
    {
        Action action = () => _engine.Calculate(4, 2, " ");

        var exception = Assert.Throws<ArgumentException>(action);

        Assert.Contains("Operation is required", exception.Message);
    }
}

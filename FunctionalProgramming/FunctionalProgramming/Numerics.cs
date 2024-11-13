namespace FunctionalProgramming;

/// <summary>
/// Declare a delegate named Function that takes a parameter x of type double
/// and returns a value of type double. <br/>
/// Implement a static method called NewtonRootFinding that accepts a function f of type Function,
/// a derivative function df of type Function (with a default value of null),
/// an initial point x0 (with a default value of 0), and a precision eps (with a default value of 1e-6).
/// The method should return the calculated root of the equation using Newton's method.<br/>
/// If the derivative function df is null, it should be initialized at the beginning of the method using
/// the approximation: "(f(x + eps) - f(x - eps)) / (2 * eps)".<br/>
/// Newton's method: https://en.wikipedia.org/wiki/Newton%27s_method <br/>
/// Next, write three parameterless methods that return the roots of the following functions using Newton's method:<br/>
/// - FindLinearRoot - For the function f(x) = x - 2. Pass the exact derivative.<br/>
/// - FindQuadraticRoot - For the function f(x) = x * x + 2 * x + 1. Pass null as the derivative.<br/>
/// - FindSinRoot - For the function f(x) = sin(x). Pass the exact derivative and starting point x0 = 2.
///   Pass the functions Math.Sin and Math.Cos by reference to the method.
/// </summary>
public static class Numerics
{
    // TODO: Function

    // TODO: NewtonRootFinding

    public static double FindLinearRoot()
    {
        // TODO: FindLinearRoot f(x) = x - 2
        return default;
    }

    public static double FindQuadraticRoot()
    {
        // TODO: FindQuadraticRoot f(x) = x * x + 2 * x + 1
        return default;
    }

    public static double FindSinRoot()
    {
        // TODO: FindSinRoot f(x) = sin(x)
        return default;
    }
}

// SOLUTION
// public static class Numerics
// {
//     public delegate double Function(double x);
//
//     public static double NewtonRootFinding(Function f, Function? df = null, double x0 = 0, double eps = 1e-6)
//     {
//         df ??= x => (f(x + eps) - f(x - eps)) / (2 * eps);
//         double x;
//         double xn = x0;
//
//         do
//         {
//             x = xn;
//             xn = x - f(x) / df(x);
//         } while (Math.Abs(x - xn) >= eps);
//
//         return xn;
//     }
//
//     public static Function Const(double c) => _ => c;
//     public static Function Linear(double a, double b) => x => a * x + b;
//     public static Function Quadratic(double a, double b, double c) => x => (a * x + b) * x + c;
//
//     public static double FindLinearRoot()
//     {
//         return NewtonRootFinding(Linear(1, -2), Const(1));
//     }
//
//     public static double FindQuadraticRoot()
//     {
//         return NewtonRootFinding(Quadratic(1, 2, 1));
//     }
//
//     public static double FindSinRoot()
//     {
//         return NewtonRootFinding(Math.Sin, Math.Cos, 2);
//     }
// }
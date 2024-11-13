namespace FunctionalProgramming;

/// <summary>
/// Write a static function RandomValueFunctionFactory that returns an anonymous function,
/// which returns a (pseudo)random double value within the range specified by the parameters:
/// double min and double max.<br/>
/// Write a static function RandomPointFunctionFactory that returns an anonymous function,
/// which returns a (pseudo)random vector of two double values (as a tuple)
/// within the range specified by the parameters: double xMin, double xMax, double yMin, double yMax.
/// Use the previously defined method.<br/>
/// Write a static function MonteCarloPiEstimation that returns an approximation of the number π (of type double).
/// Use the previously defined method. The method should accept the number of samples (points) used
/// for the approximation as an int (with a default value of 1024).<br/>
/// Monte Carlo method: https://en.wikipedia.org/wiki/Monte_Carlo_method<br/>
/// Hint: Generate random points in a rectangle containing (a segment of) a unit circle and check
/// if they are inside (the segment of) the unit circle.
/// Calculate the ratio of points inside (the segment of) the circle to the total number of points to estimate the value of π.
/// </summary>
public static class FactoryMethods
{
    // TODO: RandomValueFunctionFactory

    // TODO: RandomPointFunctionFactory

    public static double MonteCarloPiEstimation(int samples = 1024)
    {
        // TODO: MonteCarloPiEstimation
        return default;
    }
}

// SOLUTION
// public static class FactoryMethods
// {
//     public static Func<double> RandomValueFunctionFactory(double min, double max, int seed = 0)
//     {
//         var random = new Random(seed);
//         return () => random.NextDouble() * (max - min) + min;
//     }
//
//     public static Func<(double, double)> RandomPointFunctionFactory(double xMin, double xMax, double yMin, double yMax, int seed = 0)
//     {
//         var xRandom = RandomValueFunctionFactory(xMin, xMax, seed);
//         var yRandom = RandomValueFunctionFactory(yMin, yMax, seed + 1);
//         return () => (xRandom(), yRandom());
//     }
//
//     public static double MonteCarloPiEstimation(int samples = 1024)
//     {
//         var random = RandomPointFunctionFactory(0, 1, 0, 1);
//         var inside = 0;
//         for (var i = 0; i < samples; i++)
//         {
//             var (x, y) = random();
//             if (x * x + y * y < 1.0) inside++;
//         }
//         return 4.0 * inside / samples;
//     }
// }
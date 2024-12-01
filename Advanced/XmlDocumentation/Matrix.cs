namespace XmlDocumentation;

/// <summary>
/// Abstract base class representing a mathematical matrix.
/// </summary>
public abstract class Matrix
{
    /// <summary>
    /// Gets the number of rows in the matrix.
    /// </summary>
    public abstract int Rows { get; }
    
    /// <summary>
    /// Gets the number of columns in the matrix.
    /// </summary>
    public abstract int Columns { get; }

    /// <summary>
    /// Gets or sets the value at the specified row and column in the matrix.
    /// </summary>
    /// <param name="row">The row index.</param>
    /// <param name="column">The column index.</param>
    /// <returns>The value at the specified position.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the row or column index is out of bounds.</exception>
    public abstract double this[int row, int column] { get; set; }

    /// <summary>
    /// Transposes the matrix, swapping rows and columns.
    /// </summary>
    /// <returns>A new matrix that is the transpose of the current matrix.</returns>
    /// <example>
    /// <code>
    /// Matrix m = new ArrayMatrix(2, 3);
    /// m[0, 0] = 1; m[0, 1] = 2; m[0, 2] = 3;
    /// m[1, 0] = 4; m[1, 1] = 5; m[1, 2] = 6;
    /// Matrix transposed = m.Transpose();
    /// Console.WriteLine(transposed[0, 0]); // Outputs 1
    /// </code>
    /// </example>
    public abstract Matrix Transpose();

    /// <summary>
    /// Adds two matrices together.
    /// </summary>
    /// <param name="other">The matrix to add to the current matrix.</param>
    /// <returns>A new matrix containing the sum of the two matrices.</returns>
    /// <exception cref="ArgumentException">Thrown if the matrices do not have the same dimensions.</exception>
    /// <example>
    /// <code>
    /// Matrix m1 = new ArrayMatrix(2, 2);
    /// m1[0, 0] = 1; m1[0, 1] = 2;
    /// m1[1, 0] = 3; m1[1, 1] = 4;
    ///
    /// Matrix m2 = new ArrayMatrix(2, 2);
    /// m2[0, 0] = 5; m2[0, 1] = 6;
    /// m2[1, 0] = 7; m2[1, 1] = 8;
    ///
    /// Matrix sum = m1.Add(m2);
    /// Console.WriteLine(sum[0, 0]); // Outputs 6
    /// </code>
    /// </example>
    public abstract Matrix Add(Matrix other);

    /// <summary>
    /// Multiplies the current matrix with another matrix.
    /// </summary>
    /// <param name="other">The matrix to multiply by.</param>
    /// <returns>A new matrix containing the result of the multiplication.</returns>
    /// <exception cref="ArgumentException">Thrown if the number of columns in the current matrix is not equal to the number of rows in the other matrix.</exception>
    /// <example>
    /// <code>
    /// Matrix m1 = new ArrayMatrix(2, 3);
    /// m1[0, 0] = 1; m1[0, 1] = 2; m1[0, 2] = 3;
    /// m1[1, 0] = 4; m1[1, 1] = 5; m1[1, 2] = 6;
    ///
    /// Matrix m2 = new ArrayMatrix(3, 2);
    /// m2[0, 0] = 7; m2[0, 1] = 8;
    /// m2[1, 0] = 9; m2[1, 1] = 10;
    /// m2[2, 0] = 11; m2[2, 1] = 12;
    ///
    /// Matrix product = m1.Multiply(m2);
    /// Console.WriteLine(product[0, 0]); // Outputs 58
    /// </code>
    /// </example>
    public abstract Matrix Multiply(Matrix other);
}
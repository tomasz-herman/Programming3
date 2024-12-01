namespace XmlDocumentation;

/// <summary>
/// Dense <see cref="Matrix"/> implementation using a 2D array.
/// </summary>
/// <seealso cref="SparseMatrix"/>
public class ArrayMatrix : Matrix
{
    private readonly double[,] _data;

    /// <inheritdoc />
    public override int Rows { get; }

    /// <inheritdoc />
    public override int Columns { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ArrayMatrix"/> class.
    /// </summary>
    /// <param name="rows">The number of rows in the matrix.</param>
    /// <param name="columns">The number of columns in the matrix.</param>
    public ArrayMatrix(int rows, int columns)
    {
        Rows = rows;
        Columns = columns;
        _data = new double[rows, columns];
    }

    /// <inheritdoc />
    public override double this[int row, int column]
    {
        get
        {
            if (row < 0 || row >= Rows || column < 0 || column >= Columns)
                throw new ArgumentOutOfRangeException(nameof(row), "Row or column is out of bounds.");
            return _data[row, column];
        }
        set
        {
            if (row < 0 || row >= Rows || column < 0 || column >= Columns)
                throw new ArgumentOutOfRangeException(nameof(row), "Row or column is out of bounds.");
            _data[row, column] = value;
        }
    }

    /// <inheritdoc />
    public override Matrix Transpose()
    {
        var result = new ArrayMatrix(Columns, Rows);
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                result[j, i] = this[i, j];
            }
        }
        return result;
    }

    /// <inheritdoc />
    public override Matrix Add(Matrix other)
    {
        if (Rows != other.Rows || Columns != other.Columns)
            throw new ArgumentException("Matrices must have the same dimensions to be added.");

        var result = new ArrayMatrix(Rows, Columns);
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                result[i, j] = this[i, j] + other[i, j];
            }
        }
        return result;
    }

    /// <inheritdoc />
    public override Matrix Multiply(Matrix other)
    {
        if (Columns != other.Rows)
            throw new ArgumentException("The number of columns in the first matrix must match the number of rows in the second matrix.");

        var result = new ArrayMatrix(Rows, other.Columns);
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < other.Columns; j++)
            {
                double sum = 0;
                for (int k = 0; k < Columns; k++)
                {
                    sum += this[i, k] * other[k, j];
                }
                result[i, j] = sum;
            }
        }
        return result;
    }
}
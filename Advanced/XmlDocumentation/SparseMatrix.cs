namespace XmlDocumentation;

/// <summary>
/// Sparse <see cref="Matrix"/> implementation using a dictionary to store non-zero values.
/// </summary>
/// <seealso cref="ArrayMatrix"/>
public class SparseMatrix : Matrix
{
    private readonly Dictionary<(int row, int column), double> _data;
    public override int Rows { get; }
    public override int Columns { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="SparseMatrix"/> class.
    /// </summary>
    /// <param name="rows">The number of rows in the matrix.</param>
    /// <param name="columns">The number of columns in the matrix.</param>
    public SparseMatrix(int rows, int columns)
    {
        Rows = rows;
        Columns = columns;
        _data = new Dictionary<(int row, int column), double>();
    }

    /// <inheritdoc />
    public override double this[int row, int column]
    {
        get
        {
            if (_data.TryGetValue((row, column), out var value))
                return value;
            return 0.0;
        }
        set
        {
            if (value == 0.0)
                _data.Remove((row, column));
            else
                _data[(row, column)] = value;
        }
    }

    /// <inheritdoc />
    public override Matrix Transpose()
    {
        var result = new SparseMatrix(Columns, Rows);
        foreach (var ((row, column), value) in _data)
        {
            result[column, row] = value;
        }
        return result;
    }

    /// <inheritdoc />
    public override Matrix Add(Matrix other)
    {
        if (Rows != other.Rows || Columns != other.Columns)
            throw new ArgumentException("Matrices must have the same dimensions to be added.");

        var result = new SparseMatrix(Rows, Columns);
        foreach (var ((row, column), value) in _data)
        {
            result[row, column] = value + other[row, column];
        }

        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                if (!_data.ContainsKey((i, j)))
                {
                    result[i, j] = other[i, j];
                }
            }
        }

        return result;
    }

    /// <inheritdoc />
    public override Matrix Multiply(Matrix other)
    {
        if (Columns != other.Rows)
            throw new ArgumentException("The number of columns in the first matrix must match the number of rows in the second matrix.");

        var result = new SparseMatrix(Rows, other.Columns);

        foreach (var ((row, column), value) in _data)
        {
            for (int j = 0; j < other.Columns; j++)
            {
                result[row, j] += value * other[column, j];
            }
        }

        return result;
    }
}
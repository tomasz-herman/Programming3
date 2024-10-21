namespace Structs;

public readonly struct Vector3
{
    public float X { get; }
    public float Y { get; }
    public float Z { get; }

    public Vector3(float x, float y, float z) => (X, Y, Z) = (x, y, z);

    public void Scale(float scale)
    {
        // X *= scale; // Compile error
        // Y *= scale;
        // Z *= scale;
    }

    public readonly void Add(Vector3 vector)
    {
        // X += vector.X; // Compile error
        // Y += vector.Y;
        // Z += vector.Z;
    }
}
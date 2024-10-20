namespace VariablesAndParameters;

public struct Matrix4
{
    public float M11, M12, M13, M14;
    public float M21, M22, M23, M24;
    public float M31, M32, M33, M34;
    public float M41, M42, M43, M44;

    public static Matrix4 Identity =>
        new Matrix4
        {
            M11 = 1, M12 = 0, M13 = 0, M14 = 0,
            M21 = 0, M22 = 1, M23 = 0, M24 = 0,
            M31 = 0, M32 = 0, M33 = 1, M34 = 0,
            M41 = 0, M42 = 0, M43 = 0, M44 = 1
        };

    public static Matrix4 CreateRotationX(float degrees)
    {
        float radians = float.DegreesToRadians(degrees);
        float cos = float.Cos(radians);
        float sin = float.Sin(radians);

        return new Matrix4
        {
            M11 = 1,  M12 = 0,   M13 = 0,    M14 = 0,
            M21 = 0,  M22 = cos, M23 = -sin, M24 = 0,
            M31 = 0,  M32 = sin, M33 = cos,  M34 = 0,
            M41 = 0,  M42 = 0,   M43 = 0,    M44 = 1
        };
    }

    public static Matrix4 CreateRotationY(float degrees)
    {
        float radians = float.DegreesToRadians(degrees);
        float cos = float.Cos(radians);
        float sin = float.Sin(radians);

        return new Matrix4
        {
            M11 = cos,  M12 = 0, M13 = sin,  M14 = 0,
            M21 = 0,    M22 = 1, M23 = 0,    M24 = 0,
            M31 = -sin, M32 = 0, M33 = cos,  M34 = 0,
            M41 = 0,    M42 = 0, M43 = 0,    M44 = 1
        };
    }

    public override string ToString()
    {
        return $"[{M11,4:0.0}, {M12,4:0.0}, {M13,4:0.0}, {M14,4:0.0}]\n" +
               $"[{M21,4:0.0}, {M22,4:0.0}, {M23,4:0.0}, {M24,4:0.0}]\n" +
               $"[{M31,4:0.0}, {M32,4:0.0}, {M33,4:0.0}, {M34,4:0.0}]\n" +
               $"[{M41,4:0.0}, {M42,4:0.0}, {M43,4:0.0}, {M44,4:0.0}]";
    }
}
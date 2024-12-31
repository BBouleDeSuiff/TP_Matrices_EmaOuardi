namespace Maths_Matrices.Tests;

public class Vector3
{
    private float[] _vector;

    public float x
    {
        get => _vector[0];
        set => _vector[0] = value;
    }

    public float y
    {
        get => _vector[1];
        set => _vector[1] = value;
    }

    public float z
    {
        get => _vector[2];
        set => _vector[2] = value;
    }

    public Vector3()
    {
        _vector = new float[3];
    }

    public Vector3(float _x, float _y, float _z)
    {
        _vector = new float[3];
        _vector[0] = _x;
        _vector[1] = _y;
        _vector[2] = _z;
    }

    public float this[int i]
    {
        get => _vector[i];
        set => _vector[i] = value;
    }

    public static Vector3 operator +(Vector3 v1, Vector3 v2)
    {
        v1.x += v2.x;
        v1.y += v2.y;
        v1.z += v2.z;
        return v1;
    }

    public static Vector3 operator -(Vector3 v1, Vector3 v2) => v1 + new Vector3(-v2.x, -v2.y, -v2.z);
    public static Vector3 operator *(Vector3 v, float f) => new Vector3(v.x * f, v.y * f, v.z * f);
    public static Vector3 operator *(float f, Vector3 v) => new Vector3(v.x * f, v.y * f, v.z * f);

    public static Vector3 operator *(Vector3 v1, Vector3 v2)
    {
        v1.x *= v2.x;
        v1.y *= v2.y;
        v1.z *= v2.z;
        return v1;
    }

    public static Vector3 operator /(Vector3 v1, Vector3 v2)
    {
        v1.x /= v2.x;
        v1.y /= v2.y;
        v1.z /= v2.z;
        return v1;
    }

    public Vector3 MultiplyByMatrix(MatrixFloat matrix)
    {
        return new Vector3(x * matrix[0, 0] + y * matrix[0, 1] + z * matrix[0, 2],
            x * matrix[1, 0] + y * matrix[1, 1] + z * matrix[1, 2],
            x * matrix[2, 0] + y * matrix[2, 1] + z * matrix[2, 2]);
    }

    public Vector3 Normalize()
    {
        float magnitude = MathF.Sqrt(x * x + y * y + z * z);

        return magnitude > 0 ? new Vector3(x / magnitude, y / magnitude, z / magnitude) : 
                               new Vector3(0, 0, 0);
    }
    
    public static float Dot(Vector3 v1, Vector3 v2)
    {
        return v1.x * v2.x + 
               v1.y * v2.y + 
               v1.z * v2.z;
    }

    public static Vector3 Cross(Vector3 v1, Vector3 v2)
    {
        return new Vector3( v1.y * v2.z - v1.z * v2.y, 
                            v1.z * v2.x - v1.x * v2.z, 
                            v1.x * v2.y - v1.y * v2.x );
    }
}

 
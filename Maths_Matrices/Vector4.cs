namespace Maths_Matrices.Tests;

public class Vector4
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
    public float w
    {
        get => _vector[3];
        set => _vector[3] = value;
    }


    public Vector4()
    {
        _vector = new float[4];
    }
    public Vector4(float _x, float _y, float _z, float _w)
    {
        _vector = new float[4];
        _vector[0] = _x;
        _vector[1] = _y;
        _vector[2] = _z;
        _vector[3] = _w;
    }
    
    public float this[int i]
    {
        get =>  _vector[i];
        set => _vector[i] = value;
    }
    
    public static Vector4 operator *(MatrixFloat m, Vector4 v) => Multiply(m, v);
    public static Vector4 operator *(Vector4 v, MatrixFloat m) => Multiply(m, v);
        
    public static Vector4 Multiply(MatrixFloat m, Vector4 v)
    {
        Vector4 result = new Vector4();
        
        for (int i = 0; i < m.NbLines; i++)
        {
            for (int j = 0; j < m.NbColumns; j++)
            {
                result[i] += m[i, j] * v[j];
            }
        }
        
        return result;
    }
}
namespace Maths_Matrices.Tests;

public struct Quaternion(float _x, float _y, float _z, float _w)
{

    public float x = _x, y = _y, z = _z, w = _w;

    public static Quaternion Identity => new Quaternion(0, 0, 0, 1);

    public MatrixFloat Matrix => new MatrixFloat(this);
    public Vector3 EulerAngles => ToEulerAngles(this);

    public static Quaternion AngleAxis(float angle, Vector3 axis)
    {
        float angleRadians = angle * MathF.PI / 180.0f;
        Vector3 axisNorm = axis.Normalize();
        return new Quaternion(
            axisNorm.x * MathF.Sin(angleRadians / 2f),
            axisNorm.y * MathF.Sin(angleRadians / 2f),
            axisNorm.z * MathF.Sin(angleRadians / 2f),
            MathF.Cos(angleRadians / 2f)
        );
    }

    public static Quaternion operator *(Quaternion q1, Quaternion q2)
    {
        return new Quaternion(
            q1.w * q2.x + q1.x * q2.w + q1.y * q2.z - q1.z * q2.y,
            q1.w * q2.y - q1.x * q2.z + q1.y * q2.w + q1.z * q2.x,
            q1.w * q2.z + q1.x * q2.y - q1.y * q2.x + q1.z * q2.w,
            q1.w * q2.w - q1.x * q2.x - q1.y * q2.y - q1.z * q2.z
        );
    }

    public static Vector3 operator *(Quaternion q, Vector3 v)
    {
        Vector3 u = new Vector3(q.x, q.y, q.z); 
        float s = q.w; 
        Vector3 result = 2.0f * Vector3.Dot(u, v) * u + 
                           (s * s - Vector3.Dot(u, u)) * v + 
                           2.0f * s * Vector3.Cross(u, v); 
        return result;
    }

    public static Quaternion Euler(float roll, float pitch, float yaw)
    {

        return (AngleAxis(pitch, new Vector3(0,1,0)) * 
                AngleAxis(roll, new Vector3(1,0,0)) *
                AngleAxis(yaw, new Vector3(0,0,1))
        );
    }
    
    Vector3 ToEulerAngles(Quaternion q) 
    {
        MatrixFloat m = q.Matrix;
        float x, y, z;

        x = MathF.Asin(-m[1, 2]);
        if (MathF.Abs(MathF.Cos(x)) > 1e-6)
        {
            y = MathF.Atan2(m[0, 2], m[2, 2]); 
            z = MathF.Atan2(m[1, 0], m[1, 1]); 
        } 
        else
        {
            y = MathF.Atan2(-m[2, 0], m[0, 0]); 
            z = 0; 
        } 
        
        x = x * 180.0f / MathF.PI; 
        y = y * 180.0f / MathF.PI; 
        z = z * 180.0f / MathF.PI; 
        
        return new Vector3(x, y, z);
    }
}
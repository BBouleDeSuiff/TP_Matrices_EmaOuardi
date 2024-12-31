namespace Maths_Matrices.Tests;

public class Transform
{

#region Local Position
    
    private Vector3 localPosition = new Vector3();

    public Vector3 LocalPosition
    {
        get => localPosition;
        set => localPosition = value;
    }

    public MatrixFloat LocalTranslationMatrix =>
        new MatrixFloat(new float[4, 4]
        {
            { 1, 0, 0, localPosition.x},
            {0, 1, 0, localPosition.y},
            {0, 0, 1, localPosition.z},
            {0, 0, 0, 1}
        });

    #endregion

#region Local Rotation

    private Vector3 localRotation = new Vector3();
    public MatrixFloat LocalRotationXMatrix => GetRotationMatrixX();
    public MatrixFloat LocalRotationYMatrix => GetRotationMatrixY();
    public MatrixFloat LocalRotationZMatrix => GetRotationMatrixZ();
    public MatrixFloat LocalRotationMatrix => LocalRotationYMatrix * LocalRotationXMatrix * LocalRotationZMatrix;

    public Vector3 LocalRotation
    {
        get => localRotation;
        set => localRotation = value;
    }
    
    private MatrixFloat GetRotationMatrixX()
    {
        float angleInRadians = localRotation.x * MathF.PI / 180.0f;
        float[,] rotationMatrixX = new float[4, 4]
        {
            { 1, 0, 0, 0 },
            { 0, MathF.Cos(angleInRadians), -MathF.Sin(angleInRadians), 0 },
            { 0, MathF.Sin(angleInRadians), MathF.Cos(angleInRadians), 0 },
            { 0, 0, 0, 1 }
        };

        return new MatrixFloat(rotationMatrixX);
    }

    private MatrixFloat GetRotationMatrixY()
    {
        float angleInRadians = localRotation.y * MathF.PI / 180.0f;
        float[,] rotationMatrixY = new float[4, 4]
        {
            { MathF.Cos(angleInRadians), 0, MathF.Sin(angleInRadians), 0 },
            { 0, 1, 0, 0 },
            { -MathF.Sin(angleInRadians), 0, MathF.Cos(angleInRadians), 0 },
            { 0, 0, 0, 1 }
        };

        return new MatrixFloat(rotationMatrixY);
    }

    private MatrixFloat GetRotationMatrixZ()
    {
        float angleInRadians = localRotation.z * MathF.PI / 180.0f;
        float[,] rotationMatrixZ = new float[4, 4]
        {
            { MathF.Cos(angleInRadians), -MathF.Sin(angleInRadians), 0, 0 },
            { MathF.Sin(angleInRadians), MathF.Cos(angleInRadians), 0, 0 },
            { 0, 0, 1, 0 },
            { 0, 0, 0, 1 }
        };

        return new MatrixFloat(rotationMatrixZ);
    }
#endregion

#region Local Scale

    public Vector3 LocalScale = new Vector3(1,1,1);
    public MatrixFloat LocalScaleMatrix =>
        new MatrixFloat(new float[4, 4]
        {
            { LocalScale.x, 0, 0, 0 },
            { 0, LocalScale.y, 0, 0 },
            { 0, 0, LocalScale.z, 0 },
            { 0, 0, 0, 1 }
        });

    #endregion

#region World

public Vector3 WorldPosition
{
    get
    {
        if (parent == null)
            return localPosition;
        else
        {
            return (localPosition.MultiplyByMatrix(parent.LocalRotationMatrix) * parent.LocalScale) + parent.WorldPosition;
        }
    }
    set
    {
        if (parent == null)
        {
            LocalPosition = value; 
            
        }
        else
        {
            Vector3 inverseScaledPosition = (value - parent.WorldPosition) / parent.LocalScale;
            MatrixFloat inverseRotationMatrix = parent.LocalRotationMatrix.InvertByDeterminant();
            LocalPosition = inverseScaledPosition.MultiplyByMatrix(inverseRotationMatrix);
        }
    }
}


private Transform parent = null;

public MatrixFloat LocalToWorldMatrix
{
    get
    {
        if (parent == null)
            return LocalTranslationMatrix * LocalRotationMatrix * LocalScaleMatrix;
        else
            return parent.LocalToWorldMatrix * (LocalTranslationMatrix * LocalRotationMatrix * LocalScaleMatrix);
    }
}

public MatrixFloat WorldToLocalMatrix => LocalToWorldMatrix.InvertByDeterminant();
public Quaternion LocalRotationQuaternion
{
    get => Quaternion.Euler(localRotation.x, localRotation.y, localRotation.z);
    set => localRotation = value.EulerAngles;
}


public void SetParent(Transform tParent)
{
    parent = tParent;
}


#endregion

}

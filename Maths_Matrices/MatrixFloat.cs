namespace Maths_Matrices.Tests;

public class MatrixFloat
{
    public int NbLines{ get => _nbLines; set => _nbLines = value; }
    public int NbColumns{ get => _nbColumns; set => _nbColumns = value; }
    private int _nbLines;
    private int _nbColumns;
    private float[,] _matrix;
    public MatrixFloat(float[,] matrix)
    {
        _matrix = matrix;
        _nbLines = _matrix.GetLength(0);
        _nbColumns = _matrix.GetLength(1);
    }
    public MatrixFloat(int lines, int rows)
    {
        _matrix = new float[lines,rows];
        _nbLines = lines;
        _nbColumns = rows;
    }
        
    public MatrixFloat(MatrixFloat m)
    {
        _matrix = new float[m.NbLines, m.NbColumns];
        Array.Copy( m.ToArray2D(),_matrix, _matrix.Length);
        _nbLines = m.NbLines;
        _nbColumns = m.NbColumns;
    }

    public MatrixFloat(Quaternion q)
    {
        float x2 = q.x * q.x; 
        float y2 = q.y * q.y; 
        float z2 = q.z * q.z; 
        float xy = q.x * q.y; 
        float xz = q.x * q.z; 
        float yz = q.y * q.z; 
        float wx = q.w * q.x; 
        float wy = q.w * q.y; 
        float wz = q.w * q.z; 
        
        _matrix = new float[,]
        {
            { 1 - 2 * (y2 + z2), 2 * (xy - wz), 2 * (xz + wy), 0 }, 
            { 2 * (xy + wz), 1 - 2 * (x2 + z2), 2 * (yz - wx), 0 }, 
            { 2 * (xz - wy), 2 * (yz + wx), 1 - 2 * (x2 + y2), 0 },
            { 0, 0, 0, 1 }
        };
        
        _nbLines = 4;
        _nbColumns = 4;
    }
    
    public float this[int i, int i1]
    {
        get => _matrix[i, i1];
        set => _matrix[i, i1] = value;
    }

    public float[,]? ToArray2D()
    {
        return _matrix;
    }
    
    #region Multiplication
        
    public static MatrixFloat operator *(MatrixFloat m, float s) => Multiply(m, s);
    public static MatrixFloat operator *(float s, MatrixFloat m) => Multiply(m, s);
    public static MatrixFloat operator *(MatrixFloat m1, MatrixFloat m2) => m1.Multiply(m2);
        
    private static MatrixFloat Multiply(MatrixFloat m, float s)
    {
        MatrixFloat result = new MatrixFloat(m);
        result.Multiply(s);
        return result;
    }
    private void Multiply(float s)
    {
        for (int l = 0; l < _nbLines; l++)
        {
            for (int r = 0; r < _nbColumns; r++)
            {
                _matrix[l,r] *= s;
            }
        }
    }
    private MatrixFloat Multiply(MatrixFloat m2)
    {
        if(_nbColumns != m2.NbLines)
            throw new MatrixMultiplyException();
        MatrixFloat result = new MatrixFloat(_nbLines, m2.NbColumns);
        for (int i = 0; i < _nbLines; i++)
        {
            for (int j = 0; j < m2.NbColumns; j++)
            {
                for (int k = 0; k < _nbColumns; k++)
                {
                    result[i,j] += _matrix[i,k] * m2[k,j];
                }
            }
        }
        return result;
    }
    #endregion 
    
#region Division
        
    public static MatrixFloat operator /(MatrixFloat m, float s) => Divide(m, s);
    public static MatrixFloat operator /(float s, MatrixFloat m) => Divide(s, m);
    public static MatrixFloat operator /(MatrixFloat m1, MatrixFloat m2) => m1.Multiply(m2);
        
    private static MatrixFloat Divide(MatrixFloat m, float s)
    {
        MatrixFloat result = new MatrixFloat(m);
        result.Divide(s);
        return result;
    }
    private static MatrixFloat Divide(float s, MatrixFloat m)
    {
        MatrixFloat result = new MatrixFloat(m);
        for (int l = 0; l < m.NbLines; l++)
        {
            for (int r = 0; r < m.NbColumns; r++)
            {
                if(m[l,r] == 0)
                    throw new MatrixDivideException();
                m[l,r] = s / m[l,r];
            }
        }
        return result;
    }
    private void Divide(float s)
    {
        if(s == 0)
            throw new MatrixDivideException();
        for (int l = 0; l < _nbLines; l++)
        {
            for (int r = 0; r < _nbColumns; r++)
            {
                _matrix[l,r] /= s;
            }
        }
    }
    private MatrixFloat Divide(MatrixFloat m2)
    {
        if(_nbColumns != m2.NbLines)
            throw new MatrixDivideException();
        MatrixFloat result = new MatrixFloat(_nbLines, m2.NbColumns);
        for (int i = 0; i < _nbLines; i++)
        {
            for (int j = 0; j < m2.NbColumns; j++)
            {
                for (int k = 0; k < _nbColumns; k++)
                {
                    result[i,j] += _matrix[i,k] / m2[k,j];
                }
            }
        }
        return result;
    }
#endregion
    
    public static MatrixFloat Identity(int s)
    {
        float[,] matrix = new float[s, s];
        for (int l = 0; l < s; l++)
        {
            for (int r = 0; r < s; r++)
            {
                if(l==r)
                    matrix[l,r] = 1;
            }
        }
        return new MatrixFloat(matrix);
    }
    
    public static MatrixFloat GenerateAugmentedMatrix(MatrixFloat m1, MatrixFloat m2)
    {
        MatrixFloat result = new MatrixFloat((int)MathF.Max(m1.NbLines, m2.NbLines), 
            m1.NbColumns + m2.NbColumns);
        
        for (int i = 0; i < result.NbLines; i++)
        {
            for (int j = 0; j < result.NbColumns; j++)
            {
                if(i >= m1.NbLines || j >= m1.NbColumns)
                    result[i,j] = m2[i, j-m1.NbColumns];
                else
                    result[i,j] = m1[i,j];
            }
        }  
        return result;
    }
    public (MatrixFloat m1, MatrixFloat m2) Split(int c)
    {
        MatrixFloat m1 = new MatrixFloat(_nbLines, c);
        MatrixFloat m2 = new MatrixFloat(_nbLines, _nbColumns - c);
        
        for (int i = 0; i < _nbLines; i++)
        {
            for (int j = 0; j < _nbColumns; j++)
            {
                if(j < c)
                    m1[i,j] =_matrix[i,j];
                else
                    m2[i, j - c] =_matrix[i,j];
            }
        }  
        return (m1, m2);
    }

    public MatrixFloat InvertByRowReduction() => InvertByRowReduction(this); 

    public static MatrixFloat InvertByRowReduction(MatrixFloat m)
    {
        MatrixFloat identity = MatrixFloat.Identity(m.NbColumns);
        MatrixFloat augmentedMatrix = MatrixFloat.GenerateAugmentedMatrix(m, identity);

        int j = 0;
        for (int i = 0; i < augmentedMatrix.NbLines; i++)
        {
            float maxKValue = 0;
            int maxK = 0;
            for (int k = i; k < augmentedMatrix.NbLines; k++)
            {
                if ((augmentedMatrix[k, j] > maxKValue || maxKValue == 0) && augmentedMatrix[k, j] != 0)
                {
                    maxKValue = augmentedMatrix[k, j];
                    maxK = k;
                }
            }
            if (maxKValue == 0)
                throw new MatrixInvertException();
            if (maxK != i)
            {
                MatrixElementaryOperations.SwapLines(augmentedMatrix, maxK, i);
                maxK = i;
            }
            MatrixElementaryOperations.MultiplyLine(augmentedMatrix, i, 1/augmentedMatrix[i,j]);
            
            for (int r = 0; r < augmentedMatrix.NbLines; r++)
            {
                if (r != maxK)
                {
                    MatrixElementaryOperations.AddLineToAnother(augmentedMatrix, i, r, -(augmentedMatrix[r,j]));
                }
            }
            j++;
        }
        var mr = augmentedMatrix.Split(m.NbColumns);
        var me = mr.m2;
        return augmentedMatrix.Split(m.NbColumns).m2;
    }

    public MatrixFloat SubMatrix(int p0, int p1)
    {
        MatrixFloat subMatrix = new MatrixFloat(_nbLines-1, _nbColumns-1);
        
        for (int i = 0; i < _nbLines; i++)
        {
            for (int j = 0; j < _nbColumns; j++)
            {
                if(i == p0 || j == p1)
                    continue;
                else
                {
                    int x = i < p0 ? i : i-1;
                    int y = j < p1 ? j : j-1;
                    subMatrix[x,y] = _matrix[i,j];
                }
            }
        }  
        return subMatrix;
    }
    
    public static MatrixFloat SubMatrix(MatrixFloat m, int p0, int p1) => m.SubMatrix(p0, p1);

    public static float Determinant(MatrixFloat m)
    {
        switch (m.NbColumns)
        {
            case > 2:
            {
                float det = 0;
                for (int i = 0; i < m.NbColumns; i++)
                {
                    float sign = i % 2 == 0 ? 1 : -1;
                    det += sign * m[0,i] * Determinant(m.SubMatrix(0, i));
                }
                return det;
            }
            case 2:
                return m[0, 0] * m[1, 1] -
                       m[0, 1] * m[1, 0];
            default:
                return m[0,0];
        }
    }
    
    public static MatrixFloat Transpose(MatrixFloat m1) => m1.Transpose();

    private MatrixFloat Transpose()
    {
        MatrixFloat result = new MatrixFloat(_nbColumns, _nbLines);
        for (int i = 0; i < _nbLines; i++)
        {
            for (int j = 0; j < _nbColumns; j++)
            {
                result[j, i] = _matrix[i, j];
            }
        }

        return result;
    }

    public MatrixFloat Adjugate()
    {
        MatrixFloat adjMatrix = new MatrixFloat(_nbLines, _nbColumns);
        for (int i = 0; i < _nbLines; i++)
        {
            for (int j = 0; j < _nbColumns; j++)
            {
                float det = Determinant(SubMatrix(this, i, j));
                adjMatrix[i, j] = det * (float)Math.Pow(-1, i + j);
            }
        }

        return adjMatrix.Transpose();
    }
    
    public static MatrixFloat Adjugate(MatrixFloat m)
    {
        return m.Adjugate();
    }

    public MatrixFloat InvertByDeterminant()
    {
        float det = Determinant(this);
        if(det == 0)
            throw new MatrixInvertException();
        MatrixFloat adj = this.Adjugate();
        return adj * (1f/det);
    }
    
    public static MatrixFloat InvertByDeterminant(MatrixFloat m)
    {
        return m.InvertByDeterminant();
    }
}

#region Exceptions

public class MatrixInvertException : Exception
{
    
}

#endregion
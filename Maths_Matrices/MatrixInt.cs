namespace Maths_Matrices.Tests;

public class MatrixInt
{
        public int NbLines{ get => _nbLines; set => _nbLines = value; }
        public int NbColumns{ get => _nbColumns; set => _nbColumns = value; }
        private int _nbLines;
        private int _nbColumns;
        private int[,] _matrix;
        public MatrixInt(int[,] matrix)
        {
            _matrix = matrix;
            _nbLines = _matrix.GetLength(0);
            _nbColumns = _matrix.GetLength(1);
        }
        public MatrixInt(int lines, int rows)
        {
            _matrix = new int[lines,rows];
            _nbLines = lines;
            _nbColumns = rows;
        }
        
        public MatrixInt(MatrixInt matrixInt)
        {
            _matrix = new int[matrixInt.NbLines,matrixInt.NbColumns];
            Array.Copy( matrixInt.ToArray2D(),_matrix, _matrix.Length);
            _nbLines = matrixInt.NbLines;
            _nbColumns = matrixInt.NbColumns;
        }

        public static MatrixInt operator -(MatrixInt m)
        {
            for (int l = 0; l < m._nbLines; l++)
            {
                for (int r = 0; r < m._nbColumns; r++)
                {
                    m[l,r] = -m[l,r];
                }
            }
            return m;
        }
        public int this[int i, int i1]
        {
            get => _matrix[i, i1];
            set => _matrix[i, i1] = value;
        }

        public int[,]? ToArray2D()
        {
            return _matrix;
        }

    #region Multiplication
        
        public static MatrixInt operator *(MatrixInt m, int s) => Multiply(m, s);
        public static MatrixInt operator *(int s, MatrixInt m) => Multiply(m, s);
        
        public static MatrixInt Multiply(MatrixInt m, int s)
        {
            MatrixInt result = new MatrixInt(m);
            result.Multiply(s);
            return result;
        }
        public void Multiply(int s)
        {
            for (int l = 0; l < _nbLines; l++)
            {
                for (int r = 0; r < _nbColumns; r++)
                {
                    _matrix[l,r] *= s;
                }
            }
        }
        public MatrixInt Multiply(MatrixInt m2)
        {
            if(_nbColumns != m2.NbLines)
                throw new MatrixMultiplyException();
            MatrixInt result = new MatrixInt(_nbLines, m2.NbColumns);
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

        public static MatrixInt Multiply(MatrixInt m1, MatrixInt m2) => m1.Multiply(m2);

        public static MatrixInt operator *(MatrixInt m1, MatrixInt m2) => m1.Multiply(m2);


        #endregion
    
    #region Indentity

        public static MatrixInt Identity(int s)
        {
            int[,] matrix = new int[s, s];
            for (int l = 0; l < s; l++)
            {
                for (int r = 0; r < s; r++)
                {
                    if(l==r)
                        matrix[l,r] = 1;
                }
            }
            return new MatrixInt(matrix);
        }
        
        public bool IsIdentity()
        {
            if(_nbLines != _nbColumns)
                return false;
            for (int l = 0; l < _nbLines; l++)
            {
                for (int r = 0; r < _nbColumns; r++)
                {
                    if(l==r && _matrix[l,r] != 1)
                        return false;
                    else if(l!=r && _matrix[l,r] != 0)
                        return false;
                }
            }
            return true;
        }

    #endregion
    
    #region Addition
        
        public static MatrixInt operator +(MatrixInt m1, MatrixInt m2) => Add(m1, m2);

        public static MatrixInt operator -(MatrixInt m1, MatrixInt m2) => Add(m1, -m2);
        public static MatrixInt Add(MatrixInt m1, MatrixInt m2)
        {
            MatrixInt result = new MatrixInt(m1);
            result.Add(m2);
            return result;
        }
        public void Add(MatrixInt m2)
        {
            if(_nbLines !=  m2.NbLines || _nbColumns != m2.NbColumns)
                throw new MatrixSumException();
            for (int l = 0; l < _nbLines; l++)
            {
                for (int r = 0; r < _nbColumns; r++)
                {
                    _matrix[l,r] += m2[l,r];
                }
            }
        }
    #endregion

    #region Transpose
        public static MatrixInt Transpose(MatrixInt m1) => m1.Transpose();
        public MatrixInt Transpose()
        {
            MatrixInt result = new MatrixInt(_nbColumns,_nbLines); 
            for (int i = 0; i < _nbLines; i++)
            {
                for (int j = 0; j < _nbColumns; j++)
                {
                    result[j, i] = _matrix[i,j];
                }
            }
            return result;
        }
    #endregion

    public static MatrixInt GenerateAugmentedMatrix(MatrixInt m1, MatrixInt m2)
    {
        MatrixInt result = new MatrixInt((int)MathF.Max(m1.NbLines, m2.NbLines), 
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
    public (MatrixInt m1, MatrixInt m2) Split(int c)
    {
        MatrixInt m1 = new MatrixInt(_nbLines, _nbColumns-1);
        MatrixInt m2 = new MatrixInt(_nbLines, 1);
        
        for (int i = 0; i < _nbLines; i++)
        {
            for (int j = 0; j < _nbColumns; j++)
            {
                if(j == c+1)
                    m2[i,0] =_matrix[i,j];
                else
                    m1[i, j>c ? j-1 : j] =_matrix[i,j];
            }
        }  
        return (m1, m2);
    }

}

#region Exceptions

public class MatrixSumException : Exception
{
    
}
public class MatrixMultiplyException : Exception
{
    
}

public class MatrixDivideException : Exception
{
    
}


#endregion

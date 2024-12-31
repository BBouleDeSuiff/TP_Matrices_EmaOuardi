namespace Maths_Matrices.Tests;

public static class MatrixElementaryOperations
{
    public static void SwapLines(MatrixInt m, int l1, int l2)
    {
        MatrixInt origin = new MatrixInt(m);
        
        for (int i = 0; i < origin.NbLines; i++)
        {
            for (int j = 0; j < origin.NbColumns; j++)
            {
                if(i == l1)
                    m[i,j]= origin[l2,j];
                else if(i == l2)
                    m[i,j]= origin[l1,j];
            }
        }    
    }
    
    public static void SwapLines(MatrixFloat m, int l1, int l2)
    {
        MatrixFloat origin = new MatrixFloat(m);
        
        for (int i = 0; i < origin.NbLines; i++)
        {
            for (int j = 0; j < origin.NbColumns; j++)
            {
                if(i == l1)
                    m[i,j]= origin[l2,j];
                else if(i == l2)
                    m[i,j]= origin[l1,j];
            }
        }    
    }
    
    public static void SwapColumns(MatrixInt m, int c1, int c2)
    {
        MatrixInt origin = new MatrixInt(m);
        
        for (int i = 0; i < origin.NbLines; i++)
        {
            for (int j = 0; j < origin.NbColumns; j++)
            {
                if(j == c1)
                    m[i,j]= origin[i,c2];
                else if(j == c2)
                    m[i,j]= origin[i,c1];
            }
        }    
    }

    public static void MultiplyLine(MatrixInt m, int l, int f)
    {
        if(f==0)
            throw new MatrixScalarZeroException();
        for (int i = 0; i < m.NbLines; i++)
        {
            for (int j = 0; j < m.NbColumns; j++)
            {
                if(i == l)
                    m[i,j]*= f;
            }
        }  
    }
    
    public static void MultiplyLine(MatrixFloat m, int l, float f)
    {
        if(f==0)
            throw new MatrixScalarZeroException();
        for (int i = 0; i < m.NbLines; i++)
        {
            for (int j = 0; j < m.NbColumns; j++)
            {
                if(i == l)
                    m[i,j]*= f;
            }
        }  
    }
    
    public static void MultiplyColumn(MatrixInt m, int c, int f)
    {
        if(f==0)
            throw new MatrixScalarZeroException();
        
        for (int i = 0; i < m.NbLines; i++)
        {
            for (int j = 0; j < m.NbColumns; j++)
            {
                if(j == c)
                    m[i,j]*= f;
            }
        }
    }

    public static void AddLineToAnother(MatrixInt m, int l2, int l1, int f)
    {
        for (int i = 0; i < m.NbLines; i++)
        {
            for (int j = 0; j < m.NbColumns; j++)
            {
                if(i == l1)
                    m[i,j] += m[l2,j] * f;
            }
        }  
    }
    public static void AddLineToAnother(MatrixFloat m, int l2, int l1, float f)
    {
        for (int i = 0; i < m.NbLines; i++)
        {
            for (int j = 0; j < m.NbColumns; j++)
            {
                if(i == l1)
                    m[i,j] += m[l2,j] * f;
            }
        }  
    }
    
    public static void AddColumnToAnother(MatrixInt m, int c2, int c1, int f)
    {
        for (int i = 0; i < m.NbLines; i++)
        {
            for (int j = 0; j < m.NbColumns; j++)
            {
                if(j == c1)
                    m[i,j] += m[i,c2] * f;
            }
        }  
    }
    
    
}

#region Exceptions

public class MatrixScalarZeroException : Exception
{
    
}

#endregion
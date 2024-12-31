namespace Maths_Matrices.Tests;

public class MatrixRowReductionAlgorithm
{
    public static (MatrixFloat m1, MatrixFloat m2) Apply(MatrixFloat m, MatrixFloat result)
    {
        MatrixFloat augmentedMatrix = MatrixFloat.GenerateAugmentedMatrix(m, result);

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
                continue;
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
        var mr =  augmentedMatrix.Split(m.NbColumns);
        return augmentedMatrix.Split(m.NbColumns);
    }

}

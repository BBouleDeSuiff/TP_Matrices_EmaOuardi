using NUnit.Framework;

namespace Maths_Matrices.Tests
{
    [TestFixture]
    public class Tests11_InvertMatricesUsingRowReduction
    {
        [Test, DefaultFloatingPointTolerance(0.01d)]
        public void TestInvertMatrixInstance()
        {
            MatrixFloat m = new MatrixFloat(new[,]
            {
                { 2f, 3f, 8f },
                { 6f, 0f, -3f },
                { -1f, 3f, 2f },
            });

            MatrixFloat mInverted = m.InvertByRowReduction();

            Assert.AreEqual(new[,]
            {
                { 0.066f, 0.133f, -0.066f },
                { -0.066f, 0.088f, 0.4f },
                { 0.133f, -0.066f, -0.133f }
            }, mInverted.ToArray2D());
        }

        [Test, DefaultFloatingPointTolerance(0.01d)]
        public void TestInvertMatrixStatic()
        {
            MatrixFloat m = new MatrixFloat(new[,]
            {
                { 1f, 2f },
                { 3f, 4f },
            });

            MatrixFloat mInverted = MatrixFloat.InvertByRowReduction(m);

            Assert.AreEqual(new[,]
            {
                { -2f, 1f },
                { 1.5f, -0.5f },
            }, mInverted.ToArray2D());
        }

        [Test, DefaultFloatingPointTolerance(0.01d)]
        public void TestInvertImpossibleMatrix()
        {
            MatrixFloat m = new MatrixFloat(new[,]
            {
                { 1f, 2f, 3f },
                { 4f, 5f, 6f },
                { 7f, 8f, 9f },
            });

            Assert.Throws<MatrixInvertException>(() =>
            {
                MatrixFloat mInverted = m.InvertByRowReduction();
            });
        }
    }
}
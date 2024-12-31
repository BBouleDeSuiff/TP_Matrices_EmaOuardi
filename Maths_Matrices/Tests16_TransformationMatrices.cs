using System;
using NUnit.Framework;

namespace Maths_Matrices.Tests
{
    [TestFixture]
    public class Tests16_TransformationMatrices
    {
        [Test, DefaultFloatingPointTolerance(0.01d)]
        public void TestTranslatePoint()
        {

            Vector4 v = new Vector4(1f, 0f, 0f, 1f);
            MatrixFloat m = new MatrixFloat(new[,]
            {
                { 1f, 0f, 0f, 5f },
                { 0f, 1f, 0f, 3f },
                { 0f, 0f, 1f, 1f },
                { 0f, 0f, 0f, 1f },
            });

            Vector4 vTransformed = m * v;
            Assert.AreEqual(vTransformed.x, 6f);
            Assert.AreEqual(vTransformed.y, 3f);
            Assert.AreEqual(vTransformed.z, 1f);

            Vector4 vTransformedInverted = m.InvertByRowReduction() * vTransformed;
            Assert.AreEqual(1f, vTransformedInverted.x);
            Assert.AreEqual(0f, vTransformedInverted.y);
            Assert.AreEqual(0f, vTransformedInverted.z);

            vTransformedInverted = m.InvertByDeterminant() * vTransformed;
            Assert.AreEqual(1f, vTransformedInverted.x);
            Assert.AreEqual(0f, vTransformedInverted.y);
            Assert.AreEqual(0f, vTransformedInverted.z);

        }

        [Test, DefaultFloatingPointTolerance(0.01d)]
        public void TestTranslateDirection()
        {

            Vector4 v = new Vector4(1f, 0f, 0f, 0f);
            MatrixFloat m = new MatrixFloat(new[,]
            {
                { 1f, 0f, 0f, 5f },
                { 0f, 1f, 0f, 3f },
                { 0f, 0f, 1f, 1f },
                { 0f, 0f, 0f, 1f },
            });
            Vector4 vTransformed = m * v;

            Assert.AreEqual(1f, vTransformed.x);
            Assert.AreEqual(0f, vTransformed.y);
            Assert.AreEqual(0f, vTransformed.z);

            Vector4 vTransformedInverted = m.InvertByRowReduction() * vTransformed;
            Assert.AreEqual(1f, vTransformedInverted.x);
            Assert.AreEqual(0f, vTransformedInverted.y);
            Assert.AreEqual(0f, vTransformedInverted.z);

            vTransformedInverted = m.InvertByDeterminant() * vTransformed;
            Assert.AreEqual(1f, vTransformedInverted.x);
            Assert.AreEqual(0f, vTransformedInverted.y);
            Assert.AreEqual(0f, vTransformedInverted.z);

        }

        [Test, DefaultFloatingPointTolerance(0.01d)]
        public void TestScalePoint()
        {

            Vector4 v = new Vector4(2f, 1f, 3f, 1f);
            MatrixFloat m = new MatrixFloat(new[,]
            {
                { 0.5f, 0f, 0f, 0f },
                { 0.0f, 2f, 0f, 0f },
                { 0.0f, 0f, 3f, 0f },
                { 0.0f, 0f, 0f, 1f },
            });

            Vector4 vTransformed = m * v;
            Assert.AreEqual(1f, vTransformed.x);
            Assert.AreEqual(2f, vTransformed.y);
            Assert.AreEqual(9f, vTransformed.z);

            Vector4 vTransformedInverted = m.InvertByRowReduction() * vTransformed;
            Assert.AreEqual(2f, vTransformedInverted.x);
            Assert.AreEqual(1f, vTransformedInverted.y);
            Assert.AreEqual(3f, vTransformedInverted.z);

            vTransformedInverted = m.InvertByDeterminant() * vTransformed;
            Assert.AreEqual(2f, vTransformedInverted.x);
            Assert.AreEqual(1f, vTransformedInverted.y);
            Assert.AreEqual(3f, vTransformedInverted.z);

        }

        [Test, DefaultFloatingPointTolerance(0.01d)]
        public void TestRotatePoint()
        {

            Vector4 v = new Vector4(1f, 4f, 7f, 1f);
            double a = Math.PI / 2d;
            float cosA = (float)Math.Cos(a);
            float sinA = (float)Math.Sin(a);
            MatrixFloat m = new MatrixFloat(new[,]
            {
                { cosA, -sinA, 0f, 0f },
                { sinA, cosA, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            });

            Vector4 vTransformed = m * v;
            Assert.AreEqual(-4f, vTransformed.x);
            Assert.AreEqual(1f, vTransformed.y);
            Assert.AreEqual(7f, vTransformed.z);

            Vector4 vTransformedInverted = m.InvertByRowReduction() * vTransformed;
            Assert.AreEqual(1f, vTransformedInverted.x);
            Assert.AreEqual(4f, vTransformedInverted.y);
            Assert.AreEqual(7f, vTransformedInverted.z);

            vTransformedInverted = m.InvertByDeterminant() * vTransformed;
            Assert.AreEqual(1f, vTransformedInverted.x);
            Assert.AreEqual(4f, vTransformedInverted.y);
            Assert.AreEqual(7f, vTransformedInverted.z);

        }
    }
}
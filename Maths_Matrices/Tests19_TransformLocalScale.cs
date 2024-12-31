using NUnit.Framework;

namespace Maths_Matrices.Tests
{
    [TestFixture]
    public class Tests19_TransformLocalScale
    {
        [Test, DefaultFloatingPointTolerance(0.01d)]
        public void TestDefaultValues()
        {
            Transform t = new Transform();

            //Default Scale
            Assert.AreEqual(1f, t.LocalScale.x);
            Assert.AreEqual(1f, t.LocalScale.y);
            Assert.AreEqual(1f, t.LocalScale.z);
            
            //Default Matrix
            Assert.AreEqual(new[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 1f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }, t.LocalScaleMatrix.ToArray2D());
        }

        [Test, DefaultFloatingPointTolerance(0.01d)]
        public void TestChangeScale()
        {
            Transform t = new Transform();

            //Scale X
            t.LocalScale = new Vector3(2f, 1f, 1f);
            Assert.AreEqual(new[,]
            {
                { 2f, 0f, 0f, 0f },
                { 0f, 1f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }, t.LocalScaleMatrix.ToArray2D());
            
            //Scale Y
            t.LocalScale = new Vector3(1f, 5f, 1f);
            Assert.AreEqual(new[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 5f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }, t.LocalScaleMatrix.ToArray2D());
            
            //Scale Z
            t.LocalScale = new Vector3(1f, 1f, 23f);
            Assert.AreEqual(new[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 1f, 0f, 0f },
                { 0f, 0f, 23f, 0f },
                { 0f, 0f, 0f, 1f },
            }, t.LocalScaleMatrix.ToArray2D());
        }
    }
}
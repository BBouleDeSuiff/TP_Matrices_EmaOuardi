using NUnit.Framework;

namespace Maths_Matrices.Tests
{
    [TestFixture]
    public class Tests27_QuaternionsMatrix
    {
        [Test, DefaultFloatingPointTolerance(0.1d)]
        public void TestQuaternionMatrixXAxis()
        {
            Quaternion q = Quaternion.AngleAxis(30f, new Vector3(1f, 0f, 0f));
            
            Assert.AreEqual(new[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 0.866f, -0.5f, 0f },
                { 0f, 0.5f, 0.866f, 0f },
                { 0f, 0f, 0f, 1f },
            }, q.Matrix.ToArray2D());
        }
        
        [Test, DefaultFloatingPointTolerance(0.1d)]
        public void TestQuaternionMatrixYAxis()
        {
            Quaternion q = Quaternion.AngleAxis(30f, new Vector3(0f, 1f, 0f));
            
            Assert.AreEqual(new[,]
            {
                { 0.866f, 0f, 0.5f, 0f },
                { 0f, 1f, 0f, 0f },
                { -0.5f, 0f, 0.866f, 0f },
                { 0f, 0f, 0f, 1f },
            }, q.Matrix.ToArray2D());
        }
        
        [Test, DefaultFloatingPointTolerance(0.1d)]
        public void TestQuaternionMatrixZAxis()
        {
            Quaternion q = Quaternion.AngleAxis(30f, new Vector3(0f, 0f, 1f));
            
            Assert.AreEqual(new[,]
            {
                { 0.866f, -0.5f, 0f, 0f },
                { 0.5f, 0.866f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }, q.Matrix.ToArray2D());
        }
        
        [Test, DefaultFloatingPointTolerance(0.1d)]
        public void TestQuaternionMatrixMultipleAxis()
        {
            Quaternion rotationXAxis = Quaternion.AngleAxis(30f, new Vector3(1f, 0f, 0f));
            Quaternion rotationYAxis = Quaternion.AngleAxis(90f, new Vector3(0f, 1f, 0f));

            Quaternion result = rotationXAxis * rotationYAxis;
            Assert.AreEqual(new[,]
            {
                { 0f, 0f, 1f, 0f },
                { 0.5f, 0.866f, 0f, 0f },
                { -0.866f, 0.5f, 0f, 0f },
                { 0f, 0f, 0f, 1f },
            }, result.Matrix.ToArray2D());

            Quaternion invertedResult = rotationYAxis * rotationXAxis;
            Assert.AreEqual(new[,]
            {
                { 0f, 0.5f, 0.866f, 0f },
                { 0f, 0.866f, -0.5f, 0f },
                { -1f, 0f, 0f, 0f },
                { 0f, 0f, 0f, 1f },
            }, invertedResult.Matrix.ToArray2D());
        }
        
        [Test, DefaultFloatingPointTolerance(0.1d)]
        public void TestQuaternionMatrixIdentity()
        {
            Quaternion q = Quaternion.Identity;
            
            Assert.AreEqual(new[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 1f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }, q.Matrix.ToArray2D());
        }

    }
}
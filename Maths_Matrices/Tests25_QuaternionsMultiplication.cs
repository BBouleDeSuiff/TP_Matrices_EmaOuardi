using NUnit.Framework;

namespace Maths_Matrices.Tests
{
    [TestFixture]
    public class Tests25_QuaternionsMultiplication
    {
        [Test, DefaultFloatingPointTolerance(0.01d)]
        public void TestQuaternionMultiplyXAxisAndYAxis()
        {
            Quaternion rotationXAxis = Quaternion.AngleAxis(90f, new Vector3(1f, 0f, 0f));
            Quaternion rotationYAxis = Quaternion.AngleAxis(90f, new Vector3(0f, 1f, 0f));

            Quaternion result = rotationXAxis * rotationYAxis;
            Assert.AreEqual(0.5f, result.x);
            Assert.AreEqual(0.5f, result.y);
            Assert.AreEqual(0.5f, result.z);
            Assert.AreEqual(0.5f, result.w);
            
            result = rotationYAxis * rotationXAxis;
            Assert.AreEqual(0.5f, result.x);
            Assert.AreEqual(0.5f, result.y);
            Assert.AreEqual(-0.5f, result.z);
            Assert.AreEqual(0.5f, result.w);
        }
        
        [Test, DefaultFloatingPointTolerance(0.01d)]
        public void TestQuaternionMultiplyXAxisAndZAxis()
        {
            Quaternion rotationXAxis = Quaternion.AngleAxis(90f, new Vector3(1f, 0f, 0f));
            Quaternion rotationZAxis = Quaternion.AngleAxis(90f, new Vector3(0f, 0f, 1f));

            Quaternion result = rotationXAxis * rotationZAxis;
            Assert.AreEqual(0.5f, result.x);
            Assert.AreEqual(-0.5f, result.y);
            Assert.AreEqual(0.5f, result.z);
            Assert.AreEqual(0.5f, result.w);
            
            result = rotationZAxis * rotationXAxis;
            Assert.AreEqual(0.5f, result.x);
            Assert.AreEqual(0.5f, result.y);
            Assert.AreEqual(0.5f, result.z);
            Assert.AreEqual(0.5f, result.w);
            
        }
        
        [Test, DefaultFloatingPointTolerance(0.01d)]
        public void TestQuaternionMultiplyYAxisAndZAxis()
        {
            Quaternion rotationYAxis = Quaternion.AngleAxis(90f, new Vector3(0f, 1f, 0f));
            Quaternion rotationZAxis = Quaternion.AngleAxis(90f, new Vector3(0f, 0f, 1f));

            Quaternion result = rotationYAxis * rotationZAxis;
            Assert.AreEqual(0.5f, result.x);
            Assert.AreEqual(0.5f, result.y);
            Assert.AreEqual(0.5f, result.z);
            Assert.AreEqual(0.5f, result.w);
            
            result = rotationZAxis * rotationYAxis;
            Assert.AreEqual(-0.5f, result.x);
            Assert.AreEqual(0.5f, result.y);
            Assert.AreEqual(0.5f, result.z);
            Assert.AreEqual(0.5f, result.w);
        }

        [Test, DefaultFloatingPointTolerance(0.01d)]
        public void TestQuaternionMultiplyIdentity()
        {
            Quaternion rotationYAxis = Quaternion.AngleAxis(90f, new Vector3(0f, 1f, 0f));
            Quaternion qIdentity = Quaternion.Identity;

            Quaternion result = rotationYAxis * qIdentity;
            Assert.AreEqual(0f, result.x);
            Assert.AreEqual(0.71f, result.y);
            Assert.AreEqual(0f, result.z);
            Assert.AreEqual(0.71f, result.w);

            result = qIdentity * rotationYAxis;
            Assert.AreEqual(0f, result.x);
            Assert.AreEqual(0.71f, result.y);
            Assert.AreEqual(0f, result.z);
            Assert.AreEqual(0.71f, result.w);
        }
    }
}
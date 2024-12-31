using NUnit.Framework;

namespace Maths_Matrices.Tests
{
    [TestFixture]
    public class Tests24_QuaternionsAngleAxis
    {
        [Test, DefaultFloatingPointTolerance(0.01d)]
        public void TestQuaternionAngleAxisX()
        {
            //90 degree around X axis
            float angle = 90f;
            Vector3 axis = new Vector3(1f, 0f, 0f);
            Quaternion q = Quaternion.AngleAxis(angle, axis);
            Assert.AreEqual(0.71f, q.x);
            Assert.AreEqual(0f, q.y);
            Assert.AreEqual(0f, q.z);
            Assert.AreEqual(0.71f, q.w);

        }

        [Test, DefaultFloatingPointTolerance(0.01d)]
        public void TestQuaternionAngleAxisY()
        {
            //90 degree around Y axis
            float angle = 90f;
            Vector3 axis = new Vector3(0f, 1f, 0f);
            Quaternion q = Quaternion.AngleAxis(angle, axis);
            Assert.AreEqual(0f, q.x);
            Assert.AreEqual(0.71f, q.y);
            Assert.AreEqual(0f, q.z);
            Assert.AreEqual(0.71f, q.w);

        }

        [Test, DefaultFloatingPointTolerance(0.01d)]
        public void TestQuaternionAngleAxisZ()
        {
            //90 degree around Z axis
            float angle = 90f;
            Vector3 axis = new Vector3(0f, 0f, 1f);
            Quaternion q = Quaternion.AngleAxis(angle, axis);
            Assert.AreEqual(0f, q.x);
            Assert.AreEqual(0f, q.y);
            Assert.AreEqual(0.71f, q.z);
            Assert.AreEqual(0.71f, q.w);
        }

        [Test, DefaultFloatingPointTolerance(0.01d)]
        public void TestQuaternionCustomAxis()
        {
            //60 degree around Vector(0,3,4)
            float angle = 60f;
            Vector3 axis = new Vector3(0f, 3f, 4f);
            Quaternion q = Quaternion.AngleAxis(angle, axis);
            Assert.AreEqual(0f, q.x);
            Assert.AreEqual(0.3f, q.y);
            Assert.AreEqual(0.4f, q.z);
            Assert.AreEqual(0.87f, q.w);

        }
    }
}
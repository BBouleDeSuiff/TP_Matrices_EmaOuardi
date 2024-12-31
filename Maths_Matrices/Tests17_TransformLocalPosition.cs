using NUnit.Framework;

namespace Maths_Matrices.Tests
{
    [TestFixture]
    public class Tests17_TransformLocalPosition
    {
        [Test, DefaultFloatingPointTolerance(0.01d)]
        public void TestDefaultValues()
        {
            
            Transform t = new Transform();
            
            //Default Position
            Assert.AreEqual(0f, t.LocalPosition.x);
            Assert.AreEqual(0f, t.LocalPosition.y);
            Assert.AreEqual(0f, t.LocalPosition.z);

            //Default Translation Matrix
            Assert.AreEqual(new[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 1f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }, t.LocalTranslationMatrix.ToArray2D());
            
        }
        
        [Test, DefaultFloatingPointTolerance(0.01d)]
        public void TestTransformChangePosition()
        {
            
            Transform t = new Transform();
            
            //Translation
            t.LocalPosition = new Vector3(5f, 2f, 1f);
            Assert.AreEqual(new[,]
            {
                { 1f, 0f, 0f, 5f },
                { 0f, 1f, 0f, 2f },
                { 0f, 0f, 1f, 1f },
                { 0f, 0f, 0f, 1f },
            }, t.LocalTranslationMatrix.ToArray2D());

        }
        
    }
}
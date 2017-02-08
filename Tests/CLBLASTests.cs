using CLMathLibraries.CLBLAS;
using NUnit.Framework;

namespace Tests
{
    public class CLBLASTests
    {
        [Test]
        public void Should_Setup_And_Teardown()
        {
            Assert.That(CLBLAS.Setup(), Is.EqualTo(CLBLASStatus.clblasSuccess));
            CLBLAS.Teardown();
        }
    }
}
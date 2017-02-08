using CLMathLibraries.CLSparse;
using NUnit.Framework;

namespace Tests
{
    public class CLSparseTests
    {
        [Test]
        public void Should_Setup_And_Teardown()
        {
            Assert.That(CLSparse.Setup(), Is.EqualTo(CLSparseStatus.Success));
            Assert.That(CLSparse.Teardown(), Is.EqualTo(CLSparseStatus.Success));
        }
    }
}
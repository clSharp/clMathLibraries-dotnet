using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CLMathLibraries.CLFFT;
using NUnit.Framework;

namespace Tests
{
    public class CLFFTTests
    {
        [Test]
        public void Should_Setup_And_Teardown()
        {
            var setupData = new CLFFTSetupData();
            Assert.That(CLFFT.Setup(setupData), Is.EqualTo(CLFFTStatus.CL_SUCCESS));
            Assert.That(CLFFT.Teardown(), Is.EqualTo(CLFFTStatus.CL_SUCCESS));
        }
    }
}

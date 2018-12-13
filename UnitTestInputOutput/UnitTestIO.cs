using System;
using InputOutput;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace UnitTestInputOutput
{
    [TestClass]
    public class UnitTestIO
    {
        [TestMethod]
        public void TestMethod1()
        {
            InputOutputAccess io = new InputOutputAccess();
            var ioSubstitute = Substitute.For<IInputOutput>();


        }
    }
}

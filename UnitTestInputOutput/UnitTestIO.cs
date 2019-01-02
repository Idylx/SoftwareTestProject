using System;
using System.Drawing;
using InputOutput;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace UnitTest
{
    [TestClass]
    public class UnitTestIO
    {

        public string defaultImage;

        public Bitmap b;
        public InputOutputAccess io;

        [TestInitialize]
        public void Initialize()
        {
            b = new Bitmap(250, 250);
            defaultImage = "C:\\Users\\Idyllix\\Desktop\\black.png";
            io = new InputOutputAccess();

        }


        [TestMethod]
        public void WriteImage_NormalExecution()
        {
            Assert.IsTrue(io.writeImage(b, defaultImage));
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void WriteImage_NullString_NullException()
        {
            io.writeImage(b, null);
        }


        [TestMethod]
        public void WriteImage_NullBitmap_NullException()
        {
            bool result = io.writeImage(null, defaultImage);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void WriteThenRead_NoChangeOfPicture()
        {
            io.writeImage(b, defaultImage);
            Bitmap b2 = io.readImage(defaultImage);
            TestPixels(b, b2);
        }


        [TestMethod]
        public void ReadImage_NormalExecution()
        {
            Bitmap newBitmap = io.readImage(defaultImage);
            Assert.IsNotNull(newBitmap);
        }
        [TestMethod]
        public void ReadImage_Gif()
        {
            
            Bitmap b2 = io.readImage("C:\\Users\\Idyllix\\Desktop\\tenor.gif");
            Assert.IsNotNull(b2);
        }

       
        [TestMethod]
        [ExpectedException(typeof(UnauthorizedAccessException))]
        public void WriteImage_NotAutorized()
        {
            var io = Substitute.For<IInputOutput>();

            io.When(x => x.writeImage(b, defaultImage)).Do(x => { throw new UnauthorizedAccessException("You need administrator rights"); });
            io.writeImage(b, defaultImage);

        }



        
        private static void TestPixels(Bitmap bitmap, Bitmap bitmapResult)
        {
            //loop that take every pixel
            for (int i = 0; i < bitmapResult.Width; i++)
            {
                //loop that take every pixel
                for (int j = 0; j < bitmapResult.Height; j++)
                {
                    Color colorFromFile = bitmapResult.GetPixel(i, j);
                    Color colorToTest = bitmap.GetPixel(i, j);

                    //Compares the pixels and throw a fail if they are differents
                    if (colorFromFile != colorToTest)
                    {
                        Assert.Fail();
                    }
                }
            }
        }
    }
}

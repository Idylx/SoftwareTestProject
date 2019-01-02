using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Drawing;
using NSubstitute;
using BusinessLayer;

namespace UnitTest
{
    /// <summary>
    /// Description résumée pour UnitTestFilter
    /// </summary>
    [TestClass]
    public class UnitTestFilter
    {

        private TestContext testContextInstance;
        public Bitmap b;

        [TestInitialize()]
         public void MyTestInitialize() {
            var projectFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;

            b = new Bitmap(250, 250);
            string pathbirb = Path.Combine(projectFolder, @"image\", "birb.png");
            string pathBirbBlackNWhite = Path.Combine(projectFolder, @"image\", "birbBlackNWhite");
            
        }

        /// <summary>
        ///Obtient ou définit le contexte de test qui fournit
        ///des informations sur la série de tests active, ainsi que ses fonctionnalités.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Attributs de tests supplémentaires
        //
        // Vous pouvez utiliser les attributs supplémentaires suivants lorsque vous écrivez vos tests :
        //
        // Utilisez ClassInitialize pour exécuter du code avant d'exécuter le premier test de la classe
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Utilisez ClassCleanup pour exécuter du code une fois que tous les tests d'une classe ont été exécutés
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Utilisez TestInitialize pour exécuter du code avant d'exécuter chaque test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Utilisez TestCleanup pour exécuter du code après que chaque test a été exécuté
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion



        //applyFilter
        [TestMethod]
        public void ApplyFilter_nullBitmap()
        {
            var filter = Substitute.For<IFilter>();
            Bitmap bitmap = null;

            filter.When(x => x.ApplyFilter("Black and White", bitmap)).Do(x => { throw new Exception("Null bitmap"); });
            filter.ApplyFilter("Black and White", bitmap);

            Assert.AreEqual(bitmap, null);
        }

        //Rainbow


        //BlackNWhite

        // null bitmap
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void BlackNWhiteFilter_nullBitmap()
        {

            //setup substitute 
            var filter = Substitute.For<IFilter>();
            // setup behavior
            filter.When(x => x.BlackWhite(null)).Do(x => { throw new NullReferenceException("Image is null"); });

            Bitmap bitmap = null;
            filter.BlackWhite(bitmap);
        }

        // 

       

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

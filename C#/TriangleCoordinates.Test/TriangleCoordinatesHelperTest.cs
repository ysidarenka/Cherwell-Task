using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TriangleCoordinates.Interfaces;
using System.Collections.Generic;
using TriangleCoordinates.Models;

namespace TriangleCoordinates.Test
{
    [TestClass]
    public class TriangleCoordinatesHelperTest
    {
        private ITriangleCoordinatesHelper triangleHelper;

        [TestInitialize()]
        public void Initialize()
        {
            //arrange
            var xAxis = new List<int> { 1, 2, 3, 4 };
            var yAxis = new List<string> { "F", "E" };

            triangleHelper = new TriangleCoordinatesHelper(xAxis, yAxis);
        }


        [TestMethod]
        public void Test_TriangleCoordinatesHelper_CalculatAllTrianglesCoordinates()
        {
            //arrange
            //call Initialize() method

            //act
            triangleHelper.CalculatAllTrianglesCoordinates();

            var triangleDictionary = triangleHelper.GetTriangleDictionary();

            //assert
            Assert.AreEqual(triangleDictionary.Count, 8);

            var F1Triangle = triangleHelper.FindTriangleCoordinatesByRowAndColumn("F", 1);
            // assert F1 and V1
            Assert.AreEqual(F1Triangle.V1.X, 0);
            Assert.AreEqual(F1Triangle.V1.Y, 0);
            // assert F1 and V2
            Assert.AreEqual(F1Triangle.V2.X, 0);
            Assert.AreEqual(F1Triangle.V2.Y, 10);
            // assert F1 and V3
            Assert.AreEqual(F1Triangle.V3.X, 10);
            Assert.AreEqual(F1Triangle.V3.Y, 0);

            var E2Triangle = triangleHelper.FindTriangleCoordinatesByRowAndColumn("E", 2);
            // assert E2 and V1
            Assert.AreEqual(E2Triangle.V1.X, 10);
            Assert.AreEqual(E2Triangle.V1.Y, 20);
            // assert E2 and V2
            Assert.AreEqual(E2Triangle.V2.X, 10);
            Assert.AreEqual(E2Triangle.V2.Y, 10);
            // assert E2 and V3
            Assert.AreEqual(E2Triangle.V3.X, 0);
            Assert.AreEqual(E2Triangle.V3.Y, 20);

        }

        [TestMethod]
        public void Test_TriangleCoordinatesHelper_FindTriangleCoordinatesByRowAndColumn_CheckNotExistingRowAndColumn()
        {
            //arrange
            //call Initialize() method

            //act
            triangleHelper.CalculatAllTrianglesCoordinates();

            //assert
            var C10Triangle = triangleHelper.FindTriangleCoordinatesByRowAndColumn("C", 10);
            Assert.IsNull(C10Triangle);

            var E3Triangle = triangleHelper.FindTriangleCoordinatesByRowAndColumn("E", 5);
            Assert.IsNull(E3Triangle);

            var F0Triangle = triangleHelper.FindTriangleCoordinatesByRowAndColumn("F", 0);
            Assert.IsNull(F0Triangle);

        }

        [TestMethod]
        public void Test_TriangleCoordinatesHelper_GetTriangleRowAndColumn()
        {
            //arrange
            //call Initialize() method
            //F1
            var triangleF1 = new Triangle()
            {
                V1 = new Point() { X = 0, Y = 0 },
                V2 = new Point() { X = 0, Y = 10 },
                V3 = new Point() { X = 10, Y = 0 }
            };

            //E4
            var triangleE4 = new Triangle()
            {
                V1 = new Point() { X = 20, Y = 20 },
                V2 = new Point() { X = 20, Y = 10 },
                V3 = new Point() { X = 10, Y =20 }
            };

            // Not Exists
            var triangleNotExists = new Triangle()
            {
                V1 = new Point() { X = 41, Y = 32 },
                V2 = new Point() { X = 41, Y = 43 },
                V3 = new Point() { X = 52, Y = 35 }
            };

            //act
            triangleHelper.CalculatAllTrianglesCoordinates();

            //assert
            var foundTriangleF1 = triangleHelper.GetTriangleRowAndColumn(triangleF1);
            Assert.AreEqual(foundTriangleF1, "F1");

            var foundTriangleE4 = triangleHelper.GetTriangleRowAndColumn(triangleE4);
            Assert.AreEqual(foundTriangleE4, "E4");

            var foundTriangleNotExists = triangleHelper.GetTriangleRowAndColumn(triangleNotExists);
            Assert.AreEqual(foundTriangleNotExists, String.Empty);

        }
    }
}

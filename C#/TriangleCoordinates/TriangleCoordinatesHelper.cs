using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriangleCoordinates.Interfaces;
using TriangleCoordinates.Models;

namespace TriangleCoordinates
{
    /// <summary>
    /// TriangleCoordinates Helper. 
    /// Calculate all coordinates for triangles. 
    /// Find triangle by coordinates.
    /// Find coordinates by row and collumn of triangle
    /// </summary>
    public class TriangleCoordinatesHelper: ITriangleCoordinatesHelper
    {
        #region Filed(s)
        private readonly List<int> xAxis;
        private readonly List<string> yAxis;
        private Dictionary<string, Triangle> trianglesDictionary = new Dictionary<string, Triangle>();
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Default constractor - if we don't have any different size of row and columns
        /// </summary>
        public TriangleCoordinatesHelper()
        {
            this.xAxis = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            this.yAxis = new List<string> { "F", "E", "D", "C", "B", "A", };
        }
        /// <summary>
        /// Constractor with specific parameters of rows and columns
        /// First value of xAxis and yAxis - it is 'origin'
        /// </summary>
        /// <param name="xAxis">
        /// List of values as the x axis
        /// </param>
        /// <param name="yAxis">
        /// List of values as the y axis
        /// </param>
        public TriangleCoordinatesHelper(List<int> xAxis, List<string> yAxis)
        {
            this.xAxis = xAxis;
            this.yAxis = yAxis;
        }
        #endregion

        #region Actions
        /// <summary>
        /// Get triangle dictionary
        /// </summary>
        /// <returns>
        /// Return triangle dictionary <see cref="Dictionary<>"/>
        /// </returns>
        public Dictionary<string, Triangle> GetTriangleDictionary()
        {
            return trianglesDictionary;
        }

        /// <summary>
        /// Calculate all triangle coordinates based on origin of axis at V1 of F1 triangle.
        /// </summary>
        public void CalculatAllTrianglesCoordinates()
        {
            for (int x = 0; x < xAxis.Count; x++)
            {
                for (int y = 0; y < yAxis.Count; y++)
                {
                    var currentTriangle = new Triangle();

                    //trying to find out it is flipped triangle or not
                    //if xPositionMultiplier is ODD - it is 'normal' triangle as F1
                    //if xPositionMultiplier is EVEN - it is 'flipped' triangle as F2
                    var xPositionMultiplier = x % 2;

                    //calculating the real column - we have 12 values but only 6 real columns
                    var xPositon = (int)x/2;

                    if (xPositionMultiplier == 0)
                    {
                        //calculating vertices for normal triangle as F1
                        currentTriangle.V1 = new Point() { X = xPositon * 10, Y = y * 10 };
                        currentTriangle.V2 = new Point() { X = (xPositon * 10), Y = (y * 10) + 10 };
                        currentTriangle.V3 = new Point() { X = (xPositon * 10) + 10, Y = (y * 10) };
                    }
                    else
                    {
                        //calculating vertices for normal flipped triangle as F2
                        currentTriangle.V1 = new Point() { X = xPositon * 10 + 10, Y = y * 10 + 10 };
                        currentTriangle.V2 = new Point() { X = (xPositon * 10) + 10, Y = (y * 10) };
                        currentTriangle.V3 = new Point() { X = (xPositon * 10), Y = (y * 10) + 10 };
                    }

                    //generate key value
                    var keyValue = GenerateKeyValue(yAxis[y], x + 1);

                    //add triangle with key value in Dictionary
                    trianglesDictionary.Add(keyValue, currentTriangle);

                }
            }
        }
        /// <summary>
        /// Get triangle name/label based on triangle coordinates
        /// </summary>
        /// <param name="triangle">
        /// Triangle <see cref="Triangle"/>- contains coordinates of three verticies 
        /// </param>
        /// <returns>
        /// Return <see cref="string"/> - name/label of triangle
        /// </returns>
        public string GetTriangleRowAndColumn(Triangle triangle)
        {
            //trying to find triangle in our generated Dictionary
            var result=trianglesDictionary.FirstOrDefault(v =>
            v.Value.V1.X == triangle.V1.X && v.Value.V1.Y == triangle.V1.Y &&
            v.Value.V2.X == triangle.V2.X && v.Value.V2.Y == triangle.V2.Y &&
            v.Value.V3.X == triangle.V3.X && v.Value.V3.Y == triangle.V3.Y);

            //check if we found it in Dictionary
            if (result.Key!=null)
            {
                //we found triangle and return key value as name/label of triangle
                return result.Key;
            }

            //if we don't find triangle we return empty string
            return String.Empty;

        }
        /// <summary>
        /// Find triangle coordinates based on ROW and COLUMN of triangle
        /// </summary>
        /// <param name="row">
        /// Row of the triangle
        /// </param>
        /// <param name="column">
        /// Column of the triangle
        /// </param>
        /// <returns>
        /// Return triangle <see cref="Triangle"/>
        /// </returns>
        public Triangle FindTriangleCoordinatesByRowAndColumn(string row, int column)
        {
            //generate key value
            var keyValue = GenerateKeyValue(row,column);

            //checking if we have this key value in our Dictionary
            if (trianglesDictionary.ContainsKey(keyValue))
            {
                //return triangle
                return trianglesDictionary[keyValue];
            }

            //we don't find triangle based on row and column - return null
            return null;
  
        }
        #endregion

        #region Helper Functions
        /// <summary>
        /// Generate key value for triangle dictinary
        /// </summary>
        /// <param name="row">
        /// Row of the triangle
        /// </param>
        /// <param name="column">
        /// Column of the triangle
        /// </param>
        /// <returns>
        /// Return generated key value as <see cref="string"/>
        /// </returns>
        private string GenerateKeyValue(string row, int column)
        {
            return row + column.ToString();
        }
        #endregion
    }
}

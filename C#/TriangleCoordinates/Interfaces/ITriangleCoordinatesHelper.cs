using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriangleCoordinates.Models;

namespace TriangleCoordinates.Interfaces
{
    public interface ITriangleCoordinatesHelper
    {
        Dictionary<string, Triangle> GetTriangleDictionary();
        void CalculatAllTrianglesCoordinates();
        string GetTriangleRowAndColumn(Triangle triangle);
        Triangle FindTriangleCoordinatesByRowAndColumn(string row, int column);

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TriangleCoordinates.Models
{
    /// <summary>
    /// A triangle is a polygon with three edges and three vertices.
    /// V1 - first vertex
    /// V2 - second vertex
    /// V3 - third vertex
    /// </summary>
    public class Triangle
    {
        public Point V1 { get; set; }
        public Point V2 { get; set; }
        public Point V3 { get; set; }

        public override string ToString()
        {
            return $"Coordinate {nameof(V1)} ({V1.ToString()}), Coordinate {nameof(V2)} ({V2.ToString()}), Coordinate {nameof(V3)} ({V3.ToString()})";
        }

    }
}

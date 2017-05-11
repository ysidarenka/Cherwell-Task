using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleCoordinates.Models
{
    /// <summary>
    /// Coordidates X and Y
    /// </summary>
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public override string ToString()
        {
            return $"{nameof(X)} : {X}, {nameof(Y)} : {Y}";
        }
    }
}

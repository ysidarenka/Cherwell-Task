using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriangleCoordinates.Models;

namespace TriangleCoordinates.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {

            var triangleHelper = new TriangleCoordinatesHelper();

            Console.WriteLine("Hello");
            triangleHelper.CalculatAllTrianglesCoordinates();
            Console.WriteLine("Based on task, we calculated the triangles coordinates for the given row (A-F) and column (1-12) ");
            
            ConsoleKeyInfo checkExit = new ConsoleKeyInfo();
            do
            {
                Console.WriteLine("");
                Console.WriteLine("Please select the next options:");
                Console.WriteLine("1. Find row and column based on vertex coordinates");
                Console.WriteLine("2. Find triangle vertices coordinates based on row and column (name/label of triangle). Ex: F 2 or E 6 or B 8");

                var selection = Console.ReadKey();

                Console.WriteLine("");

                if (selection.KeyChar == '1')
                {
                    Console.WriteLine("Please input (only interegs) and press eneter vertex coordinates for triangle with following format: V1x V1y V2x V2y V3x V3y");
                    Console.WriteLine("");
                    var coordinates = Console.ReadLine();
                    var vertices = new List<int>();

                    try {
                        vertices = coordinates.Split(' ').Select(v => Convert.ToInt32(v)).ToList();
                    }catch(Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                        continue;
                    }

                    if (vertices.Count < 6)
                    {
                        Console.WriteLine("You inputted not enough data");
                        continue;
                    }

                    var inputTriangle = new Triangle()
                    {
                        V1 = new Point { X = vertices[0], Y = vertices[1] },
                        V2 = new Point { X = vertices[2], Y = vertices[3] },
                        V3 = new Point { X = vertices[4], Y = vertices[5] }
                    };

                    Console.WriteLine($"Your triangle: {inputTriangle.ToString()}");

                    var triangleLabel = triangleHelper.GetTriangleRowAndColumn(inputTriangle);
                    if (String.IsNullOrEmpty(triangleLabel))
                    {
                        Console.WriteLine($"We could not find triangle based on your coordinates. Please try again.");
                    }
                    else
                    {
                        Console.WriteLine($"We found triangle. Triangle name/label is {triangleLabel}");
                    }
                    

                }
                else if (selection.KeyChar == '2')
                {

                    Console.WriteLine("Please input triangle name/label. Ex: F 2 or E 6 or B 8");
                    Console.WriteLine("");
                    var triangleInfo = Console.ReadLine();
                    try {
                        var tmpData = triangleInfo.Split(' ');
                        var row = tmpData[0].ToString();
                        var column = Convert.ToInt32(tmpData[1].ToString());

                        var triangle = triangleHelper.FindTriangleCoordinatesByRowAndColumn(row, column);

                        Console.WriteLine($"You inputted {row}{column}. We found triangle: {triangle.ToString()}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("Coud not recognize you selection, try again");
                    continue;
                }

                Console.WriteLine("For exit press 'ESC' button, or press any key to repeat");
                checkExit = Console.ReadKey();

            } while (checkExit.KeyChar != '\u001b');


        }
    }
}

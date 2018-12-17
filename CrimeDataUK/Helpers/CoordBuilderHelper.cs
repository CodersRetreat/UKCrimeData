using System;
using System.Collections.Generic;
using CrimeDataUK.Models;

namespace CrimeDataUK.Helpers
{
    public class CoordBuilderHelper
    {
        public static string BuildCoordList(List<PolygonPoint> points)
        {
            string PointString = "";
            foreach (var item in points)
            {
                PointString = PointString + item.PolyPoint();
            }
            return PointString;
        }
    }
}

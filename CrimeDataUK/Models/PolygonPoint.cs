using System;
namespace CrimeDataUK.Models
{
    public class PolygonPoint
    {
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string PolyPoint() { return Latitude + "," + Longitude; }
    }
}

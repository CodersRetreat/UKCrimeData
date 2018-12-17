using System;
namespace CrimeDataUK.Models
{
    public class Location
    {
        public string latitude { get; set; }
        public string longitude { get; set; }
        public Street street { get; set; }
    }
}
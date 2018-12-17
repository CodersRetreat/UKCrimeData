using System;
using System.Collections.Generic;
using CrimeDataUK.Helpers;
using CrimeDataUK.Models;

namespace CrimeDataUK.Constants
{
    public static class ApiUrls
    {
        public static string ForcesUrl = "https://data.police.uk/api/forces";
        public static string SingleForceUrl = "https://data.police.uk/api/forces/";
        public static string ForcesSeniorOfficers = "https://data.police.uk/api/forces/";
        public static string BuildCrimeSearchPoint(string lat, string lon, string date)
        {
            return "https://data.police.uk/api/crimes-street/all-crime?lat=" + lat + "&lng=" + lon + "&date=" + date;
        }
        public static string BuildCrimeSearchPolygon(List<PolygonPoint> points, string date)
        {
            return "https://data.police.uk/api/crimes-street/all-crime?poly=" + CoordBuilderHelper.BuildCoordList(points) + "&date=" + date;
        }
    }
}
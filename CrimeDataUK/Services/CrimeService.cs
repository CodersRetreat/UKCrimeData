using System;
using System.Collections.Generic;
using CrimeDataUK.Constants;
using CrimeDataUK.Helpers;
using CrimeDataUK.Models;
using Newtonsoft.Json;

namespace CrimeDataUK.Services
{
    public class CrimeService
    {
        public static Force[] GetAllForces()
        {
            return Force.FromJson(UrlHelpers.GetUrlString(ApiUrls.ForcesUrl));
        }

        public static ForceDetails GetSingleForces(string id)
        {
            string json = UrlHelpers.GetUrlString(ApiUrls.SingleForceUrl + id);
            return JsonConvert.DeserializeObject<ForceDetails>(json);
        }

        public static List<SeniorOfficer> GetAllForceOfficers(ForceDetails force)
        {
            string json = UrlHelpers.GetUrlString(force.ForceSeniorOfficerUrl());
            return JsonConvert.DeserializeObject<List<SeniorOfficer>>(json);
        }

        public static List<Crime> GetAllCrimesByPoint(string longitude,string latitude,string date)
        {
            string json = UrlHelpers.GetUrlString(ApiUrls.BuildCrimeSearchPoint(longitude,latitude,date));
            return JsonConvert.DeserializeObject<List<Crime>>(json);
        }

        public static List<Crime> GetAllCrimesByPolygon(List<PolygonPoint> points, string date)
        {
            string json = UrlHelpers.GetUrlString(ApiUrls.BuildCrimeSearchPolygon(points, date));
            return JsonConvert.DeserializeObject<List<Crime>>(json);
        }
    }
}

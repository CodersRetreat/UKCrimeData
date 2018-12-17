using System;
using CrimeDataUK.Services;
namespace CrimeDataUk_Console
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Starting Testing All Forces");
            var Forces = CrimeService.GetAllForces();
            Console.WriteLine(Forces.Length + " Collected");

            Console.WriteLine("Starting Testing Wiltshire Force");
            var Force = CrimeService.GetSingleForces("wiltshire");
            Console.WriteLine(Force.Name + " Collected");

            Console.WriteLine("Starting Testing Sample Location For Crime");
            var Crimes = CrimeService.GetAllCrimesByPoint("52.9534161", "-1.1492773","2018-10");
            Console.WriteLine(Crimes.Count + " Collected");
        }
    }
}

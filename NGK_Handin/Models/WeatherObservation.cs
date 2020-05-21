using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace NGK_Handin3.Models
{
    public class WeatherObservation
    {
        public int Id { get; set; }
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public string LocationName { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }        
        public double Temperature { get; set; }
        public int Humidity { get; set; }
        public double AtmosphericPressure { get; set; }
    }
}

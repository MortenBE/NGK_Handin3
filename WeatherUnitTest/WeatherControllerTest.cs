using NUnit.Framework;
using NGK_Handin3.Controllers;
using NGK_Handin3.Models;
using NGK_Handin3;
using Microsoft.Extensions.Options;
using System.Text.Json;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NGK_Handin3.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace WeatherUnitTest
{
    public class WeatherControllerTest
    {
        private WeatherObservationController _uut;
        private DbContextOptions<ApplicationDbContext> _options;
        private ApplicationDbContext _context;
        private IHubContext<UpdateHub> _hub;

        [SetUp]
        public void setup() 
        {

            _options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: "Test").Options;
            _context = new ApplicationDbContext(_options);
            _uut = new WeatherObservationController(_context, _hub);
        }

        [Test]
        public async Task get_three_weather_observations() 
        {
            WeatherObservation weatherObservation1 = new WeatherObservation
            {
                Id = 1,
                Day = 24,
                Month = 3,
                Year = 2020,
                LocationName = "Holsterbro",
                Lat = 22.77,
                Lon = 44.77,
                Temperature = 23,
                Humidity = 5,
                AtmosphericPressure = 56
            };

            WeatherObservation weatherObservation2 = new WeatherObservation
            {
                Id = 2,
                Day = 16,
                Month = 2,
                Year = 2020,
                LocationName = "Skanderborg",
                Lat = 80.30,
                Lon = 90.11,
                Temperature = 23,
                Humidity = 5,
                AtmosphericPressure = 56
            };

            WeatherObservation weatherObservation3 = new WeatherObservation
            {
                Id = 3,
                Day = 23,
                Month = 1,
                Year = 2020,
                LocationName = "Randers",
                Lat = 40.22,
                Lon = 88.33,
                Temperature = 16,
                Humidity = 5,
                AtmosphericPressure = 56
            };
            
            WeatherObservation weatherObservation4 = new WeatherObservation
            {
                Id = 4,
                Day = 14,
                Month = 2,
                Year = 2020,
                LocationName = "Randers",
                Lat = 22.55,
                Lon = 33.76,
                Temperature = 10,
                Humidity = 1,
                AtmosphericPressure = 20
            };
            _context.Add(weatherObservation1);
            _context.Add(weatherObservation2);
            _context.Add(weatherObservation3);
            _context.Add(weatherObservation4);
            _context.SaveChanges();

            var result = _uut.GetWeatherObservations()?.Result.Value;
            var resultList = result.ToList();
            Assert.AreEqual(weatherObservation4.Id, resultList[0].Id);
            Assert.AreEqual(weatherObservation3.Id, resultList[1].Id);
            Assert.AreEqual(weatherObservation2.Id, resultList[2].Id);
            Assert.AreEqual(3, resultList.Count);
        }
    }
}
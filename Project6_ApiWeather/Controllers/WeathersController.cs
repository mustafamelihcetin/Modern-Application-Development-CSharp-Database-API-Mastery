using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project6_ApiWeather.Context;
using Project6_ApiWeather.Entities;

namespace Project6_ApiWeather.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeathersController : ControllerBase
    {
        WeatherContext context = new WeatherContext();

        [HttpGet]
        public IActionResult WeatherCityList()
        {
            var values = context.Cities.ToList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateWeatherCitiy(City city)
        {
            context.Cities.Add(city);
            context.SaveChanges();
            return Ok("Şehir eklendi.");
        }
        [HttpDelete]
        public IActionResult DeleteWeatherCity(int id)
        {
            var value = context.Cities.Find(id);
            context.Cities.Remove(value);
            context.SaveChanges();
            return Ok("Şehir silindi.");
        }
        [HttpPut]
        public IActionResult UpdateWeatherCity(City city)
        {
            var value = context.Cities.Find(city.ID);
            value.Name = city.Name;
            value.Temperature = city.Temperature;
            value.Country = city.Country;
            value.Detail = city.Detail;
            context.SaveChanges();
            return Ok("Şehir güncellendi.");
        }
        [HttpGet("GetByIdWeatherCity")]
        public IActionResult GetByIdWeatherCity (int id)
        {
            var value = context.Cities.Find(id);
            return Ok(value);
        }
    }
}

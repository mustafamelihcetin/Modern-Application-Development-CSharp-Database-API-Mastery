using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project13_WeatherApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://open-weather13.p.rapidapi.com/city/istanbul/EN"),
                Headers =
    {
        { "x-rapidapi-key", "1edd51c834msh9ac8fb7335f0899p146fa2jsn3ac456265605" },
        { "x-rapidapi-host", "open-weather13.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var json = JObject.Parse(body);
                var windSpeed = json["wind"]["speed"].ToString();
                lblWindSpeed.Text = windSpeed;
                var humidity = json["main"]["humidity"].ToString();
                lblHumidity.Text = humidity;
                var value = json["main"]["feels_like"].ToString();
                lblFahreneit.Text = value;
                var temp = json["main"]["temp"].ToString();
                lblTemp.Text = ((decimal.Parse(temp) - 32) * 5 / 9).ToString("F2");

                var weather = json["weather"][0]["main"].ToString();

                if (weather == "Clouds")
                {
                    pictureBox1.Image = Image.FromFile("D:\\C#\\My20CSharpProjects\\Project13_WeatherApp\\Items\\icons8_sun_behind_small_cloud_256px.png");
                }
                else if (weather == "Sunny" || weather == "Clear")
                {
                    pictureBox1.Image = Image.FromFile("D:\\C#\\My20CSharpProjects\\Project13_WeatherApp\\Items\\icons8_sun_256px.png");
                }
                else if (weather == "Snowy")
                {
                    pictureBox1.Image = Image.FromFile("D:\\C#\\My20CSharpProjects\\Project13_WeatherApp\\Items\\icons8_snow_480px.png");
                }
                else if (weather == "Rainy")
                {
                    pictureBox1.Image = Image.FromFile("D:\\C#\\My20CSharpProjects\\Project13_WeatherApp\\Items\\icons8_rain_480px_1.png");
                }

            }
        }
    }
}

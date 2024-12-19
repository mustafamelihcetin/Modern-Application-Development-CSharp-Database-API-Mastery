using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Project15_GasPriceSimulation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            timer1.Start();
            timer1.Interval = 1000;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value += 5;
            if (progressBar1.Value == 100)
            {
                timer1.Stop();
            }
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://currency-conversion-and-exchange-rates.p.rapidapi.com/latest?from=EUR&to=TRY"),
                Headers =
    {
        { "x-rapidapi-key", "1edd51c834msh9ac8fb7335f0899p146fa2jsn3ac456265605" },
        { "x-rapidapi-host", "currency-conversion-and-exchange-rates.p.rapidapi.com" },
    },
            };
            decimal currency = 0;
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var json = JObject.Parse(body);
                var eurToTry = json["rates"]["TRY"].ToString();
                currency = decimal.Parse(eurToTry, CultureInfo.CurrentCulture);
                txtGasolinePrice.Text = eurToTry.ToString();
            }




            var client1 = new HttpClient();
            var request1 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://gas-price.p.rapidapi.com/europeanCountries"),
                Headers =
    {
        { "x-rapidapi-key", "1edd51c834msh9ac8fb7335f0899p146fa2jsn3ac456265605" },
        { "x-rapidapi-host", "gas-price.p.rapidapi.com" },
    },
            };
            using (var response = await client1.SendAsync(request1))
            {
                response.EnsureSuccessStatusCode();
                var body1 = await response.Content.ReadAsStringAsync();
                var json1 = JObject.Parse(body1);

                // JSON verisini uygun kültüre çevirmek için Replace
                var gasolineStr = json1["results"][42]["gasoline"].ToString().Replace(".", ",");
                var gasoline = decimal.Parse(gasolineStr, CultureInfo.CurrentCulture);

                // currency'yi de uygun şekilde çevirerek sonucu göster
                //txtGasolinePrice.Text = (gasoline * currency).ToString("F2", CultureInfo.CurrentCulture);
            }

        }
    }
}

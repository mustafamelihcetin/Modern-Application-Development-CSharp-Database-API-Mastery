using Newtonsoft.Json;
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

namespace Project8_RapidApiCurrency
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                var client = new HttpClient();

                // USD/TRY için API çağrısı
                var requestUsd = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://currency-conversion-and-exchange-rates.p.rapidapi.com/latest"),
                    Headers =
            {
                { "x-rapidapi-key", "1edd51c834msh9ac8fb7335f0899p146fa2jsn3ac456265605" },
                { "x-rapidapi-host", "currency-conversion-and-exchange-rates.p.rapidapi.com" },
            },
                };

                using (var responseUsd = await client.SendAsync(requestUsd))
                {
                    responseUsd.EnsureSuccessStatusCode();
                    var bodyUsd = await responseUsd.Content.ReadAsStringAsync();
                    var jsonUsd = JObject.Parse(bodyUsd);

                    if (jsonUsd["rates"] != null && jsonUsd["rates"]["TRY"] != null)
                    {
                        var usdToTry = jsonUsd["rates"]["TRY"].ToString();
                        lblDollarSelling.Text = usdToTry;
                    }
                    else
                    {
                        lblDollarSelling.Text = "USD/TRY verisi bulunamadı.";
                    }
                }

                // EUR/TRY için API çağrısı
                var requestEur = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://currency-conversion-and-exchange-rates.p.rapidapi.com/latest"),
                    Headers =
            {
                { "x-rapidapi-key", "1edd51c834msh9ac8fb7335f0899p194efaj25n3ac456205e5" },
                { "x-rapidapi-host", "currency-conversion-and-exchange-rates.p.rapidapi.com" },
            },
                };

                using (var responseEur = await client.SendAsync(requestEur))
                {
                    responseEur.EnsureSuccessStatusCode();
                    var bodyEur = await responseEur.Content.ReadAsStringAsync();
                    var jsonEur = JObject.Parse(bodyEur);

                    if (jsonEur["rates"] != null && jsonEur["rates"]["TRY"] != null)
                    {
                        var eurToTry = jsonEur["rates"]["TRY"].ToString();
                        lblEuroSelling.Text = eurToTry;
                    }
                    else
                    {
                        lblEuroSelling.Text = "EUR/TRY verisi bulunamadı.";
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                // HTTP hatalarını yakala
                MessageBox.Show($"HTTP hatası: {ex.Message}");
            }
            catch (JsonReaderException ex)
            {
                // JSON parse hatalarını yakala
                MessageBox.Show($"JSON okuma hatası: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Diğer tüm hatalar için genel yakalama
                MessageBox.Show($"Bir hata oluştu: {ex.Message}");
            }
        }


    }

}


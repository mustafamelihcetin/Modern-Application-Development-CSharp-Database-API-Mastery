#region Menu_Baslangici

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Text.Json.Nodes;

Console.WriteLine("Api Consume İşlemine Hoş Geldiniz");
Console.WriteLine();
x:
Console.WriteLine("###   Yapmak istediğiniz işlemi seçiniz   ###");
Console.WriteLine("### 1 - Şehir Listesini Getirme İşlemi");
Console.WriteLine("### 2 - Şehir ve sıcaklık Listesini Getirme İşlemi");
Console.WriteLine("### 3 - Yeni Şehir Ekleme İşlemi");
Console.WriteLine("### 4 - Şehir Silme İşlemi");
Console.WriteLine("### 5 - ID'ye Göre Şehir Getirme İşlemi");
Console.WriteLine();
#endregion

Console.Write("Tercihiniz: ");
int number;
number = Convert.ToInt32(Console.ReadLine());

switch (number)
{
    case 1:
        string url = "https://localhost:7000/api/Weathers";
        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage response = await client.GetAsync(url);
            string responseBody = await response.Content.ReadAsStringAsync();
            JArray jArray = JArray.Parse(responseBody);
            foreach (var item in jArray)
            {
                string cityName = item["name"].ToString();
                Console.WriteLine($"Şehir: {cityName}");
            }
        }
        break;
    case 2:
        string url2 = "https://localhost:7000/api/Weathers";
        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage response = await client.GetAsync(url2);
            string responseBody = await response.Content.ReadAsStringAsync();
            JArray jArray = JArray.Parse(responseBody);
            foreach (var item in jArray)
            {
                string name2 = item["name"].ToString();
                string temperature2 = item["temperature"].ToString();
                string country2 = item["country"].ToString();
                Console.WriteLine($"Şehir    : {name2}");
                Console.WriteLine($"Sıcaklık : {temperature2}");
                Console.WriteLine($"Ülke     : {country2}\n");
            }
        }
        break;
    case 3:
        Console.WriteLine("### Yeni Veri Girişi ###\n");
        string name3, country3, detail3;
        decimal temperature;

        Console.Write("Şehir Adı: ");
        name3 = Console.ReadLine();

        Console.Write("Ülke Adı: ");
        country3 = Console.ReadLine();

        Console.Write("Detay: ");
        detail3 = Console.ReadLine();

        Console.Write("Sıcaklık: ");
        temperature = decimal.Parse(Console.ReadLine());

        string url3 = "https://localhost:7000/api/Weathers";
        var newWeatherCity = new
        {
            Name = name3,
            Country = country3,
            Detail = detail3,
            Temperature = temperature

        };
        using (HttpClient client = new HttpClient())
        {
            string json = JsonConvert.SerializeObject(newWeatherCity);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(url3, content);
            response.EnsureSuccessStatusCode();
            
        }
        break;
    case 4:
        Console.WriteLine("Şehir güncelleme alanı");
        break;
    case 5:
        break;
    case 6:
        break;
    default:
        Console.WriteLine("Geçerli bir seçenek giriniz.");
        goto x;
}


Console.Read();

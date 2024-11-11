#region Menu_Baslangici

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Text.Json.Nodes;

public class Program
{
    private static readonly string baseUrl = "https://localhost:7000/api/Weathers";

    public static async Task Main()
    {
        Console.WriteLine("Api Consume İşlemine Hoş Geldiniz\n");

        while (true)
        {
            ShowMenu();
            Console.Write("Tercihiniz: ");
            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Geçerli bir seçenek giriniz.");
                continue;
            }

            await HandleMenuChoice(choice);
        }
    }

    private static void ShowMenu()
    {
        Console.WriteLine("###   Yapmak istediğiniz işlemi seçiniz   ###");
        Console.WriteLine("### 1 - Şehir Listesini Getirme İşlemi");
        Console.WriteLine("### 2 - Şehir ve Sıcaklık Listesini Getirme İşlemi");
        Console.WriteLine("### 3 - Yeni Şehir Ekleme İşlemi");
        Console.WriteLine("### 4 - Şehir Silme İşlemi");
        Console.WriteLine("### 5 - Veri Güncelleme İşlemi");
        Console.WriteLine("### 6 - ID'ye Göre Şehir Getirme İşlemi\n");
    }

    private static async Task HandleMenuChoice(int choice)
    {
        switch (choice)
        {
            case 1:
                await GetCityList();
                break;
            case 2:
                await GetCityAndTemperatureList();
                break;
            case 3:
                await AddNewCity();
                break;
            case 4:
                await DeleteCity();
                break;
            case 5:
                await UpdateCity();
                break;
            case 6:
                await GetCityById();
                break;
            default:
                Console.WriteLine("Geçerli bir seçenek giriniz.");
                break;
        }
    }

    private static async Task GetCityList()
    {
        var cities = await FetchDataFromApi();
        foreach (var city in cities)
        {
            Console.WriteLine($"Şehir: {city["name"]}");
        }
    }

    private static async Task GetCityAndTemperatureList()
    {
        var cities = await FetchDataFromApi();
        foreach (var city in cities)
        {
            Console.WriteLine($"Şehir: {city["name"]}, Sıcaklık: {city["temperature"]}, Ülke: {city["country"]}");
        }
    }

    private static async Task AddNewCity()
    {
        var newCity = GetCityDetailsFromUser();
        string json = JsonConvert.SerializeObject(newCity);

        await PostDataToApi(json);
        Console.WriteLine("Şehir başarıyla eklendi.");
    }

    private static async Task DeleteCity()
    {
        Console.Write("Silmek istediğiniz Şehir ID'sini giriniz: ");
        int id = int.Parse(Console.ReadLine());
        await DeleteDataFromApi(id);
        Console.WriteLine("Şehir başarıyla silindi.");
    }

    private static async Task UpdateCity()
    {
        var updatedCity = GetCityDetailsFromUser();
        updatedCity.ID = GetCityIdFromUser();
        string json = JsonConvert.SerializeObject(updatedCity);

        await PutDataToApi(json);
        Console.WriteLine("Şehir bilgileri başarıyla güncellendi.");
    }

    private static async Task GetCityById()
    {
        int id = GetCityIdFromUser();
        var city = await FetchDataFromApiById(id);

        Console.WriteLine($"Şehir: {city["Name"]}, Ülke: {city["Country"]}, Sıcaklık: {city["Temperature"]}, Detay: {city["Detail"]}");
    }

    private static int GetCityIdFromUser()
    {
        Console.Write("Şehir ID'sini giriniz: ");
        return int.Parse(Console.ReadLine());
    }

    private static async Task<JArray> FetchDataFromApi()
    {
        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage response = await client.GetAsync(baseUrl);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            return JArray.Parse(responseBody);
        }
    }

    private static async Task<JObject> FetchDataFromApiById(int id)
    {
        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage response = await client.GetAsync($"{baseUrl}/GetByIdWeatherCity?id={id}");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            return JObject.Parse(responseBody);
        }
    }

    private static async Task PostDataToApi(string json)
    {
        using (HttpClient client = new HttpClient())
        {
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(baseUrl, content);
            response.EnsureSuccessStatusCode();
        }
    }

    private static async Task PutDataToApi(string json)
    {
        using (HttpClient client = new HttpClient())
        {
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync(baseUrl, content);
            response.EnsureSuccessStatusCode();
        }
    }

    private static async Task DeleteDataFromApi(int id)
    {
        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage response = await client.DeleteAsync($"{baseUrl}?id={id}");
            response.EnsureSuccessStatusCode();
        }
    }

    private static dynamic GetCityDetailsFromUser()
    {
        Console.Write("Şehir Adı: ");
        string name = Console.ReadLine();

        Console.Write("Ülke Adı: ");
        string country = Console.ReadLine();

        Console.Write("Detay: ");
        string detail = Console.ReadLine();

        Console.Write("Sıcaklık: ");
        decimal temperature = decimal.Parse(Console.ReadLine());

        return new
        {
            Name = name,
            Country = country,
            Detail = detail,
            Temperature = temperature
        };
    }
}
#endregion

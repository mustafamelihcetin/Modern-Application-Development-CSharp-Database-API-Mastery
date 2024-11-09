#region Menu_Baslangici

using Newtonsoft.Json.Linq;
using System.Text.Json.Nodes;

Console.WriteLine("Api Consume İşlemine Hoş Geldiniz");
Console.WriteLine();
x:
Console.WriteLine("###   Yapmak istediğiniz işlemi seçiniz   ###");
Console.WriteLine("### 1 - Şehir Listesini Getirme İşlemi");
Console.WriteLine("### 2 - Yeni Şehir Ekleme İşlemi");
Console.WriteLine("### 3 - Şehir Silme İşlemi");
Console.WriteLine("### 4 - Şehir Güncelleme İşlemi");
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
        Console.WriteLine("Yeni şehir ekleme alanı");
        break;
    case 3:
        Console.WriteLine("Şehir silme alanı");
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

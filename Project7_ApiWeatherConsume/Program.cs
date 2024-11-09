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

Console.Write("Tercihiniz: ");
int number;
number = Convert.ToInt32(Console.ReadLine());

switch(number)
{
    case 1:
        Console.WriteLine("Şehir listesi: ");
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
    default:
        Console.WriteLine("Geçerli bir seçenek giriniz.");
        goto x;
}




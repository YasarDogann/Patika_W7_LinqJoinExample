# Patika+ Week7 Linq Join Uygulaması
Merhaba,
Bu proje C# ile Patika+ 7.hafta Linq - Join uygulaması için yapılmış bir uygulamadır.

## 📚 Proje Hakkında
Bu proje, aşağıdaki konuları öğrenmeye yardımcı olmak için tasarlanmıştır:
- Basit bir C# programı yazmak
- C# konsol uygulamasının yapısını anlamak
- List yapısını öğrenmek
- Döngüler'i kullanmak
- Linq yapısını kullanmak
- Class yapısı
- Sorgu Yapısını kullanmak


## İstenilen Görev
Bir kütüphane yönetim sistemi oluşturun. Bu sistemde iki adet tablo bulunmaktadır: Yazarlar ve Kitaplar. Aşağıda her iki tablonun yapısı verilmiştir:

 - Yazarlar Tablosu (Authors)

   - `AuthorId (int)` - Yazarın benzersiz kimliği

   - `Name (string)`  - Yazarın adı

 - Kitaplar Tablosu (Books)

   - `BookId (int)`   - Kitabın benzersiz kimliği

   - `Title (string)` - Kitabın başlığı

   - `AuthorId (int)` - Kitabın yazarının kimliği (Yazarlar tablosundaki AuthorId ile ilişkilidir)

Görev:

1. Tabloları Tanımlayın:

        Author ve Book adında iki sınıf oluşturun ve yukarıdaki tablo yapılarını bu sınıflara uygun şekilde tanımlayın.

    Verileri Ekleyin:

        Her iki tabloya da örnek veriler ekleyin. En az 3 yazar ve 4 kitap ekleyin.

    LINQ Sorgusu Yazın:

        Kitapları ve yazarları birleştiren bir LINQ sorgusu oluşturun. Bu sorgu, her kitabın başlığını ve yazarının adını içermelidir.

    Sonuçları Yazdırın:

        Oluşturduğunuz LINQ sorgusunun sonucunu ekrana yazdırın. Her kitabın başlığı ve yazarının adını içeren bilgileri göstermelisiniz.

Örnek Veriler:


## Kod: Series Class'ı
```csharp
public class Series
{
    // Özellikler - Properties
    public string SerieName { get; set; }
    public int DebutYear { get; set; }
    public string Type { get; set; }
    public int PremiereDate { get; set; }
    public string Directors { get; set; }
    public string Platform { get; set; }

    // Boş Yapıcı method
    public Series() { }

    // parametreli yapıcı method
    public Series(string serieName, int debutYear, string type, int premierDate, string directors, string platform)
    {
        SerieName = serieName;
        DebutYear = debutYear;
        Type = type;
        PremiereDate = premierDate;
        Directors = directors;
        Platform = platform;
    }

    // dizi bilgilerini string formata dönüştüren object sınıfından override edilen ToString methodu
    public override string ToString()
    {
        return $"Dizi Adı: {SerieName.PadRight(20)}  Yapım Yılı: {DebutYear}     Türü: {Type.PadRight(10)} " +
            $"Yayınlanma Tarihi: {PremiereDate}      Yönetmenler: {Directors.PadRight(10)} Platform: {Platform}  ";
    }

}
```

## Kod: ComedySeries Class'ı

```csharp
public class ComedySeries 
{
    // Özellikler - Properties
    public string SerieName { get; set; }
    public string Type { get; set; }
    public string Directors { get; set; }
    public ComedySeries(string name, string type, string directors)
    {
        SerieName = name;
        Type = type;
        Directors = directors;
    }

    public override string ToString()
    {
        return $"{SerieName.PadRight(20)} {Type.PadRight(10)} {Directors}";
    }
}
```

## Kod: Main Class

```csharp
static void Main(string[] args)
{
    // Series sınıfından dinamik bir liste oluşturuluyor
    List<Series> series = new List<Series>();
    int debutYear, premiereDate;

    bool isContinue = true;

    while (isContinue)
    {
        // Kullanıcıya dizi bilgilerini sorma ve input alma
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("----- DİZİ EKLEME YAPMA İŞLEMİ -----");
        Console.ResetColor();

        Console.ForegroundColor= ConsoleColor.Red;
        Console.Write("Dizinin Adı: ");
        Console.ResetColor();
        string name = Console.ReadLine();

        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("Yapım Yılı: ");
        Console.ResetColor();
        string yearInput = Console.ReadLine();
        while (!int.TryParse(yearInput, out debutYear))
        {
            Console.Write("Geçerli bir yıl girin: ");
            yearInput = Console.ReadLine();
        }

        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("Türü: ");
        Console.ResetColor();
        string type = Console.ReadLine();

        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("Yayınlanma Tarihi: ");
        Console.ResetColor();
        string premiereInput = Console.ReadLine();
        while (!int.TryParse(premiereInput, out premiereDate))
        {
            Console.Write("Geçerli bir yıl girin: ");
            premiereInput = Console.ReadLine();
        }

        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("Yönetmenler: ");
        Console.ResetColor();
        string directors = Console.ReadLine();

        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("Yayınlanan Platform: ");
        Console.ResetColor();
        string platform = Console.ReadLine();

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Devam Etmek İstiyor Musun: (Evet: E-e || Hayır: H-h)");
        Console.ResetColor();
        char choose = char.Parse(Console.ReadLine().ToLower());

        // Devam edip etmeyeceği soruluyor
        if (choose == 'e' || choose == 'E') isContinue = true; // evet derse yeni dizi eklemek için döngü başına döner
        else if (choose == 'h' || choose == 'H') isContinue = false; // hayır derse döngü biter

        // Yeni bir dizi oluşturulup listeye ekleniyor
        Series newSerie = new Series(name, debutYear, type, premiereDate, directors, platform);
        series.Add(newSerie);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Dizi Başarıyla Eklendi\r\n");
        Console.ResetColor();
    }


    // Komedi dizilerinden yeni bir liste olşturduk
    List<ComedySeries> comedySeriesList = series.Where(s => s.Type.Contains("Komedi"))
                                                .Select(s => new ComedySeries(s.SerieName, s.Type, s.Directors))
                                                .OrderBy(cs => cs.SerieName)
                                                .ThenBy(cs => cs.Directors)
                                                .ToList();
    // Komedi dizilerini ekrana yazdırıyoruz
    Console.ForegroundColor= ConsoleColor.Green;
    Console.WriteLine("\nKomedi Dizileri:");
    Console.ResetColor();
    foreach (var comedySeries in comedySeriesList)
    {
        Console.WriteLine(comedySeries);
    }

    // Eklenen Tüm diziler ekrana yazdırırlır
    Console.ForegroundColor= ConsoleColor.Green;
    Console.WriteLine("\r\nEklenen dizizler");
    Console.ResetColor();
    foreach (Series serie in series)
    {
        Console.WriteLine(serie);
    }
}
```

## Uygulama Çıktısı: 
![diziler](https://github.com/user-attachments/assets/69a4f8a9-01bd-4ee5-9b29-9a79abf61c10)






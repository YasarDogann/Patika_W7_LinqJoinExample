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

   `Author` ve `Book` adında iki sınıf oluşturun ve yukarıdaki tablo yapılarını bu sınıflara uygun şekilde tanımlayın.

2. Verileri Ekleyin:

   Her iki tabloya da örnek veriler ekleyin. En az 3 yazar ve 4 kitap ekleyin.

3. LINQ Sorgusu Yazın:

   Kitapları ve yazarları birleştiren bir LINQ sorgusu oluşturun. Bu sorgu, her kitabın başlığını ve yazarının adını içermelidir.

4. Sonuçları Yazdırın:

   Oluşturduğunuz LINQ sorgusunun sonucunu ekrana yazdırın. Her kitabın başlığı ve yazarının adını içeren bilgileri göstermelisiniz.

Örnek Veriler:
![cX1xAyv-linqAdvancedYazarKitap](https://github.com/user-attachments/assets/8149477f-ab9f-4d74-afa0-7a0fe80499af)

Notlar:

 - LINQ sorgusunda join işlemini kullanarak iki tabloyu birleştirin.

 - Sonuçları ekrana yazdırırken kitap başlığını ve yazarın adını göstermek için uygun bir format kullanın.





## Kod: Authors ve Books Class'ı
```csharp
public class Authors
{
    public int AuthorId { get; set; }
    public string Name { get; set; }
}

public class Books
{
    public int BookId { get; set; }
    public string Title { get; set; }
    public int AuthorId { get; set; }
}
```


## Kod: Main Class

```csharp
static void Main(string[] args)
{
    // Kitap Lİstesi
    List<Books> books = new List<Books>
    {
        new Books {BookId = 1, Title = "Kar", AuthorId = 1},
        new Books {BookId = 2, Title = "İstanbul", AuthorId = 1},
        new Books {BookId = 3, Title = "10 Minutes 38 Seconds in This Strange World", AuthorId = 2},
        new Books {BookId = 4, Title = "Beyoğlu Raspodisi", AuthorId = 3}
    };


    // Yazar Listesi
    List<Authors> authors = new List<Authors>
    {
        new Authors {AuthorId = 1, Name= "Orhan Pamuk" },
        new Authors {AuthorId = 2, Name= "Elif Şafak" },
        new Authors {AuthorId = 3, Name= "Ahmet Ümit" }
    };

    #region Yöntem1: Method  Sözdizimi

    var query = authors.Join(books,
                        authors => authors.AuthorId,
                        books => books.AuthorId,
                        (authors, books) => new
                        {
                            BookName = books.Title,
                            AuthorName = authors.Name
                        }
                        );
    #endregion


    #region Yöntem2: Sorgu Sözdizimi
    var query2 = from author in authors
                join book in books on author.AuthorId equals book.AuthorId
                select new
                {
                    BookName = book.Title,
                    AuthorName = author.Name,
                };

    #endregion

    foreach (var book in query2)
    {
        // "Kitap Adı:" kısmını renklendir
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("Kitap Adı: ");

        // Kitap adını farklı renkte yazdır
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write($"{book.BookName.PadRight(20)} ");

        // "Yazar Adı:" kısmını renklendir
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("Yazar Adı: ");

        // Yazar adını farklı renkte yazdır
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(book.AuthorName);

        // Renkleri varsayılana döndür
        Console.ResetColor();
    }
}
```

## Uygulama Çıktısı: 
![resim](https://github.com/user-attachments/assets/1b697d37-0ef6-4a1a-a60f-fe0d8e344fc2)






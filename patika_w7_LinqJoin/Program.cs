namespace patika_w7_LinqJoin
{
    internal class Program
    {
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
    }
}

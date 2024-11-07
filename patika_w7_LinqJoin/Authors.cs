using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patika_w7_LinqJoin
{
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
}

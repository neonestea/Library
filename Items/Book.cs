using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject
{
    class Book : Item
    {

        public Book(string author, string name, string publicationYear, string language, string country)
            : base(author, name, publicationYear, language, country)
        {
            this.id_ = allId;
            allId++;
        }

        public override void addToFund(Catalog cat)
        {
            this.enable();
            cat.books.Add(this);
            cat.items.Add(this);
        }
    }
}

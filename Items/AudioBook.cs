using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject
{
    class AudioBook : Item
    {
        protected string duration_ { get; set; }

        public AudioBook(string author, string name, string publicationYear, string language, string country, string time)
           : base(author, name, publicationYear, language, country)
        {
            this.duration_ = time;
            this.id_ = allId;
            allId++;
        }
        public override void addToFund(Catalog cat)
        {
            this.enable();
            cat.audiobooks.Add(this);
            cat.items.Add(this);

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject
{
    class Document : Item
    {
        protected string type_ { get; set; }
        public Document(string author, string name, string publicationYear, string language, string country, string type)
           : base(author, name, publicationYear, language, country)
        {
            this.type_ = type;
            this.id_ = allId;
            allId++;
        }
        public override void addToFund(Catalog cat)
        {
            this.enable();
            cat.documents.Add(this);
            cat.items.Add(this);
        }
    }
}

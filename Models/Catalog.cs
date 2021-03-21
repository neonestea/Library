using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject
{
    class Catalog
    {
        public List<Book> books = new List<Book>();
        public List<Document> documents = new List<Document>();
        public List<AudioBook> audiobooks = new List<AudioBook>();
        public List<Item> items = new List<Item>();
        public List<Computer> computers = new List<Computer>();

        public string showBooks()
        {
            string str = "Books:\n";
            foreach (Book it in books)
            {
                if (it.getFrozenFlag() != true)
                {
                    str += it.getId() + " : " + it.getName() + " " + it.checkRating() +  " Available" + '\n';
                }
                else
                {
                    str += it.getId() + " : " + it.getName() + " " + it.checkRating() + " Unavilable" + '\n';
                }
            }
            str += '\n';
            return str;
        }
        public string showAudioBooks()
        {
            string str = "AudioBooks:\n";
            foreach (AudioBook it in audiobooks)
            {
                if (it.getFrozenFlag() != true)
                {
                    str += it.getId() + " : " + it.getName() + " " + it.checkRating() + " Available" + '\n';
                }
                else
                {
                    str += it.getId() + " : " + it.getName() + " " + it.checkRating() + " Unavilable" + '\n';
                }
            }
            str += '\n';
            return str;
        }
        public string showDocuments()
        {
            string str = "Documents:\n";
            foreach (Document it in documents)
            {
                if (it.getFrozenFlag() != true)
                {
                    str += it.getId() + " : " + it.getName() + " " + it.checkRating() + " Available" + '\n';
                }
                else
                {
                    str += it.getId() + " : " + it.getName() + " " + it.checkRating() + " Unavilable" + '\n';
                }
            }
            str += '\n';
            return str;
        }
        public void addComputer(Computer comp)
        {
            this.computers.Add(comp);
        }
    }
}

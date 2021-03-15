using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject
{
    class FundAccounting
    {

        public void addItemsToFund(List<Book> items, Catalog cat)
        {
            foreach (Book it in items)
            {
                it.addToFund(cat);
                cat.books = cat.books.Distinct().ToList();

            }
        }
        public void addItemsToFund(List<AudioBook> items, Catalog cat)
        {
            foreach (AudioBook it in items)
            {
                it.addToFund(cat);
                cat.audiobooks = cat.audiobooks.Distinct().ToList();
            }
        }
        public void addItemsToFund(List<Document> items, Catalog cat)
        {
            foreach (Document it in items)
            {
                it.addToFund(cat);
                cat.documents = cat.documents.Distinct().ToList();
            }
        }
        public void deleteItemsFromFund(List<Item> items, Catalog cat)
        {
            foreach (Item it in items)
            {
                it.deleteFromFund(cat);
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject
{
    abstract class Item
    {
        protected static int allId = 0;

        protected string name_;
        protected string publicationYear_;
        protected bool frozenFlag_ = false;
        protected string language_;
        protected string country_;
        protected int id_;
        protected string author_;

        protected List<Client> reservedFor_ = new List<Client>();
        protected Client onLoanFor_ = null;
        protected List<int> rating_ = new List<int>();

        public Item(string author, string name, string publicationYear, string language, string country) //конструктор
        {
            this.name_ = name;
            this.author_ = author;
            this.publicationYear_ = publicationYear;
            this.language_ = language;
            this.country_ = country;
        }

        public void addRating(int val) // клиент ставит оценку
        {
            this.rating_.Add(val);
        }

        public double checkRating() //проверка оценки (общей)
        {
            if (this.rating_.Count == 0)
            {
                return 0;
            }
            else
            {
                int sum = 0;
                for (int i = 0; i < this.rating_.Count; i++)
                    sum += this.rating_[i];
                double res = sum / this.rating_.Count;
                return Math.Round(res, 1);
            }
            
        }

        public virtual void addToFund(Catalog cat)
        {
            
        }

        public void deleteFromFund(Catalog cat)
        {

            //удаление из каталога
        }

        public void Reserve(Client Client_) //клиент добавляется в список резерва
        {
            this.reservedFor_.Add(Client_);
        }
        public void freeze() //книга становится недоступной
        {
            this.frozenFlag_ = true;
        }

        public bool getFrozenFlag() //проверка на доступность
        {
            return this.frozenFlag_;
        }

        public Client getReservedFirstFor() //узнать, кто первый в списке ожидания
        {
            return this.reservedFor_[0];
        }

        public int getId()
        {
            return this.id_;
        }
        public string getName()
        {
            return this.name_;
        }

        public void enable()
        {
            this.frozenFlag_ = false;
        }

        public bool giveOut(Client Client_) //выдача книги
        {
            bool result = false;
            if (this.frozenFlag_ == false) //если книга доступна 
            {
                if (this.reservedFor_.Count == 0) //если людей в списке ожидания нет
                {
                    //выдать книгу
                    this.onLoanFor_ = Client_;
                    this.freeze();
                    result = true;
                }
                else if (this.getReservedFirstFor() == Client_) //если пришла очередь первого в резерве
                {
                    this.freeze();
                    this.onLoanFor_ = Client_;
                    this.reservedFor_.RemoveAt(0);
                    result = true;
                }
            }
            return result;
        }

        public void lost()
        {
            this.frozenFlag_ = false;
            //удалить из фонда
        }

        public void Return()
        {
            this.frozenFlag_ = false;
            this.onLoanFor_ = null;
        }
    }
}


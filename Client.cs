using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject
{
    class Client
    {
        private static int allId = 0;

        private string name_;
        private string phoneNumber_;
        private string surname_;
        private int id_ = 0;
        private string email_;
        private string password_;
        private int countOfDelays = 0;
        private List<Item> wishList = new List<Item>();
        public bool isActive = false;
        public Tuple<int, string> cmp = null;
        public List<Order> ordersOnLoan = new List<Order>();


        public Client(string name, string surname, string phoneNumber, string email, string password)
        {
            this.name_ = name;
            this.surname_ = surname;
            this.phoneNumber_ = phoneNumber;
            this.email_ = email;
            this.password_ = password;
            this.id_ = allId;
            allId++;
        }

        public void addDelay()
        {
            this.countOfDelays++;
        }

        public int getId()
        {
            return this.id_;
        }

        public string getInfo()
        {
            return this.email_ + " " + this.password_;
        }



        public void rate(int item_id, int val, Catalog cat) //определить item по id
        {
            for (int i = 0; i < cat.items.Count; i++)
            {
               if (cat.items[i].getId() == item_id)
               {
                  cat.items[i].addRating(val);
                  break;
               }
            }

            
        }

        public void askForWifi(Employee emp)
        {
            emp.addTask("Wifi", this);
        }

        public void askForConsultation(Employee emp)
        {
            emp.addTask("Consultaion", this);
        }

        public Order makeReturn(Employee emp)
        {
            emp.addTask("Return", this);
            return this.ordersOnLoan[0];
        }

        public void makeOrder(Employee emp)
        {
            emp.addTask("Order", this);
        }

        public void askForComputer(Employee emp)
        {
            emp.addTask("Computer", this);
        }

        public void confirmOrder(Employee emp)
        {
            emp.addTask("Confirm", this);
        }



        public void addToWishList(int id, Catalog cat)
        {
            for (int i = 0; i < cat.items.Count; i++)
            {
                if (cat.items[i].getId() == id)
                {
                    this.wishList.Add(cat.items[i]);
                    break;
                }
            }

        }

        public string checkCatalog(Catalog cat)
        {
            string res = "";
            res += cat.showBooks();
            res += cat.showAudioBooks();
            res += cat.showDocuments();
            return res;
        }
        public string checkWishList()
        {
            string res = "";
            for (int i = 0; i < this.wishList.Count; i++)
            {
                res += this.wishList[i].getId() + " : " + this.wishList[i].getName() + '\n';
            }
            return res;
        }

        public void getComputer(Computer comp, string password)
        {
            this.cmp = new Tuple<int, string>(comp.getId(), password);
            
        }
        
        
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject
{
    class Librarian : Employee
    {
        public Librarian(string name, string surname)
            : base(name, surname)
        {
            this.title_ = Title.librarian;
            this.id_ = allId;
            allId++;
        }
        public string giveWifi()
        {
            return "WiFi access given";
        }

        public Tuple<Computer,string> giveComputer(Catalog cat)
        {
            List<Computer> available = new List<Computer>();
            for (int i = 0; i < cat.computers.Count; i++)
            {
                if (cat.computers[i].checkAvailable())
                {
                    available.Add(cat.computers[i]);
                }
            }
            if (available.Count > 0)
            {
                Tuple<Computer, string> cmp = new Tuple<Computer, string>(available[0], available[0].getPassword());
                return cmp;
            }
            else
            {
                return null;
            }
        }
        public void createOrder(Client cl)
        {
            Order ord = new Order(cl);
            Order.activeOrders.Add(ord);
        }
        public string confirmOrder(Order ord)
        {
            
            string res = "Order details:\n";
            res += Order.activeOrders[0].orderInfo();
            ord.makeReady();
            return res;
        }

        public void giveOut(Order order, Client client)
        {
            client.ordersOnLoan.Add(order);
            Order.ready = null;
        }
        public void getReturned(Order ord, Client client, Catalog cat)
        {
            client.ordersOnLoan.RemoveAt(0);

            for (int i = 0; i < cat.items.Count; i++)
            {
                for (int j = 0; j < ord.items.Count; j++)
                {
                    if (cat.items[i].getId() == ord.items[j].getId())
                    {
                        cat.items[i].enable();
                    }
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject
{
    class Courier : Employee
    {
        public List<Order> orders = new List<Order>();
        public Courier(string name, string surname)
           : base(name, surname)
        {
            this.title_ = Title.courier;
            this.id_ = allId;
            allId++;
        }

        public void giveOrder(Client client)
        {
            for (int i = 0; i < orders.Count; i++)
            {
                if(orders[i].getClient() == client)
                {
                    client.ordersOnLoan.Add(orders[i]);
                    Order.ready = null;
                }
                    
            }
            
        }

        public void getOrder(Order order, Client client)
        {
            this.orders.Add(order);
        }
    }
}

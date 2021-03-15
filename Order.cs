using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryProject
{
    class Order
    {
        private static int allId = 0;
        public static List<Order> activeOrders = new List<Order>();
        public static Order ready = null;

        private int id;
        private Client client_;
        private bool delayedFlag = false;
        private DateTime date = DateTime.Today;
        private DateTime returnDate;
        public List<Item> items = new List<Item>();
        private bool delivery = false;
        private bool state = true;

        public Order(Client cl)
        {
            double period = 5;
            this.id = allId;
            allId++;
            this.client_ = cl;
            this.returnDate = date.AddDays(period);
        }

        ~Order()
        {

        }

        public bool getDelivery()
        {
            return this.delivery;
        }
        public void addItem(Item newItem, Catalog cat)
        {
            this.items.Add(newItem);
            for (int i = 0; i < cat.items.Count; i++)
            {
                if (cat.items[i].getId() == newItem.getId())
                {
                    cat.items[i].freeze();
                }
            }
        }

        public void deleteItem(Item newItem)
        {
            this.items.Remove(newItem);
        }

        public void setDelivery()
        {
            this.delivery = true;
        }
        public void prolong(DateTime returnDate, double days)
        {
            returnDate.AddDays(days);
        }

        public void suspend(bool state)
        {
            if (state == true)
                state = false; // нажимает для присотановления работы заказа
            else
                state = true; // возащается к заказу
        }

        public Client getClient()
        {
            return this.client_;
        }

        public string orderInfo()
        {
            
            return "Return date " + this.returnDate + "\nNumber of items " + this.items.Count;
        }

        public void makeReady()
        {
            Order.activeOrders.RemoveAt(0);
            Order.ready = this;
        }
    }
}

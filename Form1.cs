using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryProject
{
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "";
        }

        Consultant cons = new Consultant("Консультант", "Консультантов");
        Courier cour = new Courier("Курьер", "Курьеров");
        Librarian librar = new Librarian("Библиотекарь", "Библиотекарев");
        //List<Client> clients = new List<Client>();
        Client activeClient = null;
        FundAccounting fund = new FundAccounting();
        Catalog cat = new Catalog();
        Book it1 = new Book("Джек Лондон", "Сердца трех", "1920", "Русский", "Россия");
        AudioBook it2 = new AudioBook("Стивен Кинг", "Оно", "2018", "Русский", "Россия", "23:45:28");
        Document it3 = new Document("Турниязова Д.М.", "Мемуары", "2020", "Русский", "Россия", "Мемуары");

        IdentityProvider idProvider = new IdentityProvider();
        Computer comp1 = new Computer("abcd");
        
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                string data = textBox1.Text;

                Client client1 = idProvider.registerClient(data);
                //clients.Add(client1);
                label1.Text = Convert.ToString(client1.getId());
                activeClient = client1;
            }

            textBox1.Text = "";

        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (activeClient != null && cons.tasks[0].Item2 == activeClient && cons.availableFlag == true)
            {
                cons.startTask();
                string text = cons.giveConsultation(activeClient);
                cons.becomeFree();
                label18.Text = cons.showTasks();
                label16.Text = text;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (activeClient != null)
            {
                activeClient.askForWifi(librar);
                label17.Text = librar.showTasks();
            }
           
        }

        private void button6_Click(object sender, EventArgs e)
        {

            if (activeClient != null)
            {
                activeClient.makeOrder(librar);
                label17.Text = librar.showTasks();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (activeClient != null)
            {
                activeClient.makeReturn(librar);
                label17.Text = librar.showTasks();
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (activeClient != null)
            {
                activeClient.askForConsultation(cons);
                label18.Text = cons.showTasks();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            label1.Text = "Отсутствует";
            activeClient = null;
        }


        private void button24_Click(object sender, EventArgs e)
        {
            if (activeClient != null)
            {
                label1.Text = "Сначала выйдите";
            }
            else if (textBox1.Text != "")
            {
                string text = textBox1.Text;
                activeClient = idProvider.validateClient(text);
                label1.Text = Convert.ToString(activeClient.getId());

            }

            textBox1.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (librar.availableFlag == true ||  activeClient != null && librar.tasks.Count > 0)
            {
                if (librar.tasks[0].Item1 == "Wifi" && librar.tasks[0].Item2 == activeClient)
                {
                    librar.startTask();
                    label16.Text = librar.giveWifi();
                    librar.becomeFree();
                    label17.Text = librar.showTasks();
                }
                else if (librar.tasks[0].Item1 == "Computer" && librar.tasks[0].Item2 == activeClient)
                {
                    librar.startTask();
                    Tuple<Computer, string> cmp = librar.giveComputer(cat);
                    Computer comp = cmp.Item1;
                    string password = cmp.Item2;

                    activeClient.getComputer(comp, password);
                    librar.becomeFree();
                    label17.Text = librar.showTasks();
                }
                else if (librar.tasks[0].Item1 == "Order" && librar.tasks[0].Item2 == activeClient)
                {
                    librar.startTask();
                    librar.createOrder(activeClient);
                    librar.becomeFree();
                    label17.Text = librar.showTasks();
                }
                else if (librar.tasks[0].Item1 == "Confirm" && librar.tasks[0].Item2 == activeClient)
                {
                    librar.startTask();
                    label16.Text = librar.confirmOrder(Order.activeOrders[0]);
                    if (Order.ready.getDelivery())
                    {
                        cour.addTask("Delivery", activeClient);
                        
                        label19.Text = cour.showTasks();
                    }
                    else
                    {
                        //librar.becomeFree();
                        librar.addTask("GiveOut", activeClient);
                        
                        label17.Text = librar.showTasks();
                    }
                    librar.becomeFree();
                    label17.Text = librar.showTasks();
                }
                else if (librar.tasks[0].Item1 == "GiveOut" && librar.tasks[0].Item2 == activeClient)
                {
                    librar.startTask();
                    librar.giveOut(Order.ready, activeClient);
                    librar.becomeFree();
                    label17.Text = librar.showTasks();
                    label16.Text = "Order given";
                }
                else if (librar.tasks[0].Item1 == "Return" && librar.tasks[0].Item2 == activeClient)
                {
                    librar.startTask();
                    librar.getReturned(activeClient.ordersOnLoan[0], activeClient, cat);
                    librar.becomeFree();
                    label17.Text = librar.showTasks();
                    label16.Text = "Order returned";
                }
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            librar.startWorking();
            label13.Text = "Working";
        }

        private void button20_Click(object sender, EventArgs e)
        {
            cons.startWorking();
            label12.Text = "Working";
        }

        private void button18_Click(object sender, EventArgs e)
        {
            cour.startWorking();
            label11.Text = "Working";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            librar.stopWorking();
            label13.Text = "Not working";
        }

        private void button21_Click(object sender, EventArgs e)
        {
            cons.stopWorking();
            label12.Text = "Not working";
        }

        private void button19_Click(object sender, EventArgs e)
        {
            cour.stopWorking();
            label11.Text = "Not working";
        }

        private void button22_Click(object sender, EventArgs e)
        {
             List<Book> incomesBooks = new List<Book>();
             incomesBooks.Add(it1);
             List<AudioBook> incomesAudioBooks = new List<AudioBook>();
             incomesAudioBooks.Add(it2);
             List<Document> incomesDocs = new List<Document>();
             incomesDocs.Add(it3);
            fund.addItemsToFund(incomesAudioBooks, cat);
            fund.addItemsToFund(incomesBooks, cat);
            fund.addItemsToFund(incomesDocs, cat);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            
            if (activeClient != null)
            {
                label16.Text = activeClient.checkWishList();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (activeClient != null)
            {
                label16.Text = activeClient.checkCatalog(cat);
            }
                
        }

        private void button8_Click(object sender, EventArgs e)
        {
            
            if (activeClient != null && textBox2.Text != "")
            {
                int id = Convert.ToInt32(textBox2.Text);
                activeClient.addToWishList(id, cat);
                textBox2.Text = "";
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (activeClient != null && textBox2.Text != "" && textBox3.Text != "")
            {
                int id = Convert.ToInt32(textBox2.Text);
                int val = Convert.ToInt32(textBox3.Text);
                activeClient.rate(id, val, cat);
                textBox3.Text = "";
                textBox2.Text = "";
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            cat.addComputer(comp1);
            if (activeClient != null)
            {

                activeClient.askForComputer(librar);
                label17.Text = librar.showTasks();
            }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            if (activeClient != null && activeClient.cmp != null)
            {
                Computer comp = null;
                for (int i = 0; i < cat.computers.Count; i++)
                {
                    if (activeClient.cmp.Item1 == cat.computers[i].getId())
                    {
                        comp = cat.computers[i];
                        break;
                    }
                }

                if (comp != null && comp.getPassword() == activeClient.cmp.Item2)
                {
                    string res = comp.logIn(activeClient.cmp.Item2);
                    label16.Text = res;
                }
            }
        }

        private void button27_Click(object sender, EventArgs e)
        {
            if (activeClient != null)
            {
                Computer comp = null;
                for (int i = 0; i < cat.computers.Count; i++)
                {
                    if (activeClient.cmp.Item1 == cat.computers[i].getId())
                    {
                        comp = cat.computers[i];
                        break;
                    }
                }

                if (comp != null)
                {
                    comp.logOut();
                    label16.Text = "";
                    
                    activeClient.cmp = null;
                }
            }
        }

        private void button28_Click(object sender, EventArgs e)
        {
            if (activeClient != null && textBox2.Text != "" && Order.activeOrders[0].getClient() == activeClient)
            {
                Item it = null;
                for (int i = 0; i < cat.items.Count; i++)
                {
                    if (cat.items[i].getId() == Convert.ToInt32(textBox2.Text))
                    {
                        it = cat.items[i];
                    }
                }
                textBox2.Text = "";
                Order.activeOrders[0].addItem(it, cat);
                label16.Text += it.getId() + " " + it.getName() + '\n';
            }
        }

        private void button30_Click(object sender, EventArgs e)
        {
            if (activeClient != null && Order.activeOrders[0].getClient() == activeClient)
            {
                activeClient.confirmOrder(librar);
                label16.Text = "Confirmation";
                label17.Text = librar.showTasks();
            }
        }

        private void button29_Click(object sender, EventArgs e)
        {
            if (activeClient != null && Order.activeOrders[0].getClient() == activeClient)
            {
                Order.activeOrders[0].setDelivery();
            }
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (cour.tasks[0].Item1 == "Delivery" && cour.tasks[0].Item2 == activeClient)
            {
                cour.startTask();
                cour.getOrder(Order.ready, activeClient);
                cour.becomeFree();
                cour.addTask("GiveOut", activeClient);
                label19.Text = cour.showTasks();
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (activeClient != null)
            {
                cour.startTask();
                cour.giveOrder(activeClient);
                cour.becomeFree();
                label19.Text = cour.showTasks();
                label16.Text = "Order given";
            }
            
        }
    }
}

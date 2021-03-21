using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject
{
    class IdentityProvider
    {
        private List<Client> clients = new List<Client>();
        public IdentityProvider() { }
        public Client validateClient(string text)
        {
    
            for (int i = 0; i < this.clients.Count; i++)
            {
                if (this.clients[i].getInfo() == text)
                    return this.clients[i];
            }
            return null;
        }
        public Client registerClient(string data)
        {
            string[] text = data.Split(' ');
            Client client1 = new Client(text[0], text[1], text[2], text[3], text[4]);
            this.clients.Add(client1);
            return client1;
        }
    }
}

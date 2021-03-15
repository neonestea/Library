using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject
{
    class Consultant : Employee
    {
        public Consultant(string name, string surname)
           : base(name, surname)
        {
            this.title_ = Title.consultant;
            this.id_ = allId;
            allId++;
        }
        public string giveConsultation(Client client1)
        {
            this.availableFlag = false;
            Consultation cons = new Consultation(this, client1);
            
            this.availableFlag = true;
            return cons.giveConsultaion(); 
        }
    }
}

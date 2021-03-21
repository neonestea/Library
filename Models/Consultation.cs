using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject
{
    class Consultation
    {
        private Consultant consultant_;
        private Client client_;
        private bool happenFlag = false;

        public Consultation(Consultant cons, Client cl)
        {
            this.consultant_ = cons;
            this.client_ = cl;
        }

        public string giveConsultaion()
        {
            if (happenFlag == false)
            {
                happenFlag = true;
                return "Consultation completed";
            }
            else
            {
                happenFlag = false;
                return "Consultation didn`t complete";

            }
        }

    }
}

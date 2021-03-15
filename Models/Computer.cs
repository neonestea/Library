using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject
{
    class Computer
    {
        private static int allId = 0;

        private int id_ = 0;
        private string password_;
        public bool availableFlag = true;

        public Computer(string password)
        {
            this.password_ = password;
            this.id_ = allId;
            allId++;
        }
        public Computer()
        {

        }

        public bool checkAvailable()
        {
            return availableFlag;
        }

        public string getPassword()
        {
            return this.password_;
        }

        public int getId()
        { 
            return this.id_; 
        }
        public string logIn(string pswd)
        {
            if (this.password_ == pswd)
            {
                this.availableFlag = false;
                return "Working on computer";
            }
            else return "Wrong password";
        }

        public void logOut()
        {
            this.availableFlag = true;
        }
    }
}

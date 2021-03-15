using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject
{
    enum Title
    {
        librarian,
        consultant,
        courier
    }

    class Employee
    {
        protected static int allId = 0;

        protected string name_;
        protected string surname_;
        protected int id_;
        protected Title title_;
        public bool availableFlag = false;
        public List<Tuple<string, Client>> tasks = new List<Tuple<string, Client>>();

        public Employee(string name, string surname)
        {
            this.name_ = name;
            this.surname_ = surname;
            this.id_ = allId;
            allId++;
        }


        public void startWorking()
        {
            this.availableFlag = true;

        }
        public void startTask()
        {
            this.availableFlag = false;
            

        }

        public void becomeFree()
        {
            this.availableFlag = true;
            this.tasks.RemoveAt(0);

        }
        public void stopWorking()
        {
            this.availableFlag = false;

        }

        public void addTask(string task, Client client1)
        {
            Tuple<string, Client> tsk = new Tuple<string, Client>(task, client1);
            tasks.Add(tsk);
        }
        public string showTasks()
        {
            string result = "";
            for (int i = 0; i < tasks.Count; i++)
            {
                result += tasks[i].Item1;
                result += "\n";
            }
            return result;
        }

        

    }
}

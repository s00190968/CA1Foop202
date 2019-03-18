using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementApp
{    
    public class RealTask:Task
    {
        PRIORITY_TYPES pr;
        DateTime dt;
        string p;

        public PRIORITY_TYPES Priority { get { return pr; } set { pr = value; RaisePropertyChanged("Priority"); } }
        public DateTime DueDate { get { return dt; } set { dt = value; RaisePropertyChanged("DueDate"); } }
        public string PersonInCharge { get { return p; } set { p = value; RaisePropertyChanged("PersonInCharge"); } }

        public RealTask(string title, string description, CATEGORY category, PRIORITY_TYPES priority, DateTime dueDate, string personInCharge, string[] labels) : base(title, description, category, labels)
        {
            Priority = priority;
            DueDate = dueDate;
            PersonInCharge = personInCharge;
        }

        public override string ToString()
        {
            return base.ToString() + string.Format($"Due: {DueDate.ToShortDateString()}");
        }
    }
}

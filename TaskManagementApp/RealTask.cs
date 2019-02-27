using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementApp
{    
    public class RealTask:Task
    {
        public PRIORITY_TYPES Priority { get; }
        public DateTime DueDate { get; set; }
        public string PersonInCharge { get; set; }

        public RealTask(string title, string description, CATEGORY category, PRIORITY_TYPES priority, DateTime dueDate, string personInCharge) : base(title, description, category)
        {
            Priority = priority;
            DueDate = dueDate;
            PersonInCharge = personInCharge;
        }

        public override string ToString()
        {
            return base.ToString() + string.Format($"Due: {DueDate.ToShortDateString()}/nPriority: {Priority}/nPerson in charge: {PersonInCharge}");
        }
    }
}

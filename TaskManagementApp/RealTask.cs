using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementApp
{
    class RealTask:Task
    {
        public enum PRIORITY_TYPES { Low, Normal, Medium, Urgent, SuperUrgent, HyperUrgent }
        public PRIORITY_TYPES Priority { get; }
        DateTime DueDate { get; set; }

        public RealTask(string title, string description, CATEGORY category, PRIORITY_TYPES priority, DateTime dueDate) : base(title, description, category)
        {
            Priority = priority;
            DueDate = dueDate;
        }

        public override string ToString()
        {
            return base.ToString() + string.Format($"Due: {DueDate.ToShortDateString()}/nPriority: {Priority}");
        }
    }
}

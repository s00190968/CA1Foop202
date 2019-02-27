using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementApp
{    
    public abstract class Task
    {
        public CATEGORY taskCategory;
        //title, description, category
        public string Title { get; set; }
        public string Description { get; set; }

        public Task(string title, string description, CATEGORY category)
        {
            Title = title;
            Description = description;
            taskCategory = category;
        }

        public override string ToString()
        {
            return string.Format($"{Title}/n{taskCategory}/n{Description}/n");
        }
    }
}

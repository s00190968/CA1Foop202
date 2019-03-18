using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementApp
{    
    public abstract class Task : INotifyPropertyChanged
    {
        //title, description, category
        string title;
        string description;
       
        public CATEGORY taskCategory;
        public string Title { get { return title; } set { title = value; RaisePropertyChanged("Title"); } }
        public string Description { get { return description; } set { description = value; RaisePropertyChanged("Description"); } }
        public List<string> Labels;

        public event PropertyChangedEventHandler PropertyChanged;

        public Task(string title, string description, CATEGORY category, string[] labels)
        {
            Title = title;
            Description = description;
            taskCategory = category;
            Labels = new List<string>();

            addLabels(labels);
        }

        public void addLabels(string[] values)
        {
            foreach (string s in values)
            {
                Labels.Add(s);
            }
        }

        protected void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public override string ToString()
        {
            return string.Format($"{Title}, {taskCategory}, ");
        }
    }
}

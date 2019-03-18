using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TaskManagementApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public TaskManager TM;
        string[] categories = { "All", "Home", "Work", "School", "Leisure" };
        public static string[] imgSources ={ "images/home.png", "images/work.png", "images/school.png", "images/leisure.png" };
        public RealTask selectedTask;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            TM = new TaskManager();
            TM.loadDataFromJson();
            TasksLbx.ItemsSource = TM.allTasks;
            categoriesCbx.ItemsSource = categories;
            categoriesCbx.SelectedIndex = 0;
            prioritiesCbx.SelectedIndex = 0;
            DueDatePicker.SelectedDate = null;
        }

        private void CategoriesCbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            resetTasksListBoxItems();
            int index = categoriesCbx.SelectedIndex;

            if(index == 0)
            {
                TasksLbx.ItemsSource = TM.allTasks;
            }
            else
            {
                TasksLbx.ItemsSource = TM.FilterTasks(TM.getCategory(index - 1));
            }
        }

        private void SearchTxBx_TextChanged(object sender, TextChangedEventArgs e)
        {
            resetTasksListBoxItems();
            if (TM != null)
            {
                if (searchTxBx.Text != "")
                {
                    TasksLbx.ItemsSource = TM.SearchTasks(searchTxBx.Text);
                }
                else
                {
                    TasksLbx.ItemsSource = TM.allTasks;
                }
            }
        }

        private void SearchTxBx_GotFocus(object sender, RoutedEventArgs e)
        {
            searchTxBx.Text = "";
        }

        private void AddTaskBtn_Click(object sender, RoutedEventArgs e)
        {
            AddTaskWindow addTaskWindow = new AddTaskWindow();
            addTaskWindow.Owner = this;
            addTaskWindow.ShowDialog();
        }

        private void SaveTasksBtn_Click(object sender, RoutedEventArgs e)
        {
            TM.saveDataToJson();
        }

        private void LoadTasksBtn_Click(object sender, RoutedEventArgs e)
        {
            TM.loadDataFromJson();
            TasksLbx.ItemsSource = TM.allTasks;
        }

        private void TasksLbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RealTask temp = TasksLbx.SelectedItem as RealTask;
            if (temp != null)
            {
                taskCategoryImg.Source = new BitmapImage(new Uri("images/" + temp.taskCategory.ToString() + ".png", UriKind.Relative));
                TaskTitleTblk.Text = temp.Title;
                CategoryTlblk.Text = temp.taskCategory.ToString();
                PriorityTlblk.Text = temp.Priority.ToString();
                DescriptionTlblk.Text = temp.Description;
                foreach (string label in temp.Labels)
                {
                    LabelsTlblk.Text += label + ",";
                }
                DueDateTlblk.Text = temp.DueDate.ToShortDateString();
                PersonChargeTlblk.Text = temp.PersonInCharge;
            }
            else
            {
                TaskTitleTblk.Text = "";
                CategoryTlblk.Text = "";
                PriorityTlblk.Text = "";
                DescriptionTlblk.Text = "";
                LabelsTlblk.Text = "";
                DueDateTlblk.Text = "";
                PersonChargeTlblk.Text = "";
            }
        }

        private void EditTasksBtn_Click(object sender, RoutedEventArgs e)
        {
            selectedTask = TasksLbx.SelectedItem as RealTask;
            if (selectedTask != null)//only let user edit taks if selected task is not null
            {
                EditTask editTaskWindow = new EditTask();
                editTaskWindow.Owner = this;
                editTaskWindow.ShowDialog();
            }
        }

        private void CompleteTasksBtn_Click(object sender, RoutedEventArgs e)
        {
            RealTask temp = TasksLbx.SelectedItem as RealTask;
            TM.CompeleteTask(temp);
            TM.saveDataToJson();
        }

        private void DeleteTasksBtn_Click(object sender, RoutedEventArgs e)
        {
            RealTask temp = TasksLbx.SelectedItem as RealTask;
            TM.DeleteTask(temp);
            TM.saveDataToJson();
        }

        void resetTasksListBoxItems()
        {
            TasksLbx.ItemsSource = null;
        }

        private void PrioritiesCbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            resetTasksListBoxItems();
            int index = categoriesCbx.SelectedIndex;
            if(index == 0)
            {
                TasksLbx.ItemsSource = TM.allTasks;
            }
            else
            {
                TasksLbx.ItemsSource = TM.FilterTasks(TM.getPriority(index - 1));
            }
        }

        private void DueDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            resetTasksListBoxItems();
            if (DueDatePicker.SelectedDate != null)
            {
                TM.FilterTasks(DueDatePicker.SelectedDate.Value);
            }
        }
    }
}

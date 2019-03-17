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
        TaskManager TM;
        string[] categories = { "All", "Home", "Work", "School", "Leisure" };
        public static string[] imgSources ={ "images/home.png", "images/work.png", "images/school.png", "images/leisure.png" };
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            TM = new TaskManager();
            TM.AddTask("Example Task", "This is an example task", CATEGORY.Leisure, PRIORITY_TYPES.Low, DateTime.Now, "Marky Mark");
            TasksLbx.ItemsSource = TM.allTasks;
            categoriesCbx.ItemsSource = categories;
            categoriesCbx.SelectedIndex = 0;
        }

        private void CategoriesCbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = categoriesCbx.SelectedIndex;
            switch (index)
            {
                case 0:
                    TasksLbx.ItemsSource = TM.allTasks;
                    break;
                case 1:
                    TasksLbx.ItemsSource = TM.FilterTasks(CATEGORY.Home);
                    break;
                case 2:
                    TasksLbx.ItemsSource = TM.FilterTasks(CATEGORY.Work);
                    break;
                case 3:
                    TasksLbx.ItemsSource = TM.FilterTasks(CATEGORY.School);
                    break;
                case 4:
                    TasksLbx.ItemsSource = TM.FilterTasks(CATEGORY.Leisure);
                    break;
            }
        }

        private void SearchTxBx_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TM != null)
            {
                TasksLbx.ItemsSource = TM.FilterTasks(searchTxBx.Text);
            }
        }

        private void SearchTxBx_GotFocus(object sender, RoutedEventArgs e)
        {
            searchTxBx.Text = "";
        }

        private void AddTaskBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SaveTasksBtn_Click(object sender, RoutedEventArgs e)
        {
            TM.saveDataToJson();
        }

        private void LoadTasksBtn_Click(object sender, RoutedEventArgs e)
        {
            TM.loadDataFromJson();
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
            }
            else
            {
                TaskTitleTblk.Text = "";
                CategoryTlblk.Text = "";
                PriorityTlblk.Text = "";
                DescriptionTlblk.Text = "";
                LabelsTlblk.Text = "";
                DueDateTlblk.Text = "";
            }
        }
    }
}

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

namespace CourseScheduler.Custom_Controls
{
    /// <summary>
    /// Interaction logic for AddCourseControl.xaml
    /// </summary>
    public partial class AddCourseControl : UserControl
    {
        DataBaseHandler dataBaseHandler;
        public AddCourseControl(DataBaseHandler dbHandler)
        {
            dataBaseHandler = dbHandler;
            InitializeComponent();
        }

        private void CreateCourse_Click(object sender, RoutedEventArgs e)
        {
            int cap, cred;
            if (int.TryParse(Capacity.Text, out cap))
            {
                if (int.TryParse(Credits.Text, out cred))
                {
                    dataBaseHandler.InsertNewCourse(CourseName.Text, cred, (bool)NeedsLabRoom.IsChecked, (bool)NeedsLargeRoom.IsChecked, (bool)IsElective.IsChecked, (bool)HasPrerequisite.IsChecked, Major.Text, cap);
                    Window.GetWindow(this).Close();
                }
                else
                    MessageBox.Show("Error parsing Credits. Enter a new value and try again.", "Error", MessageBoxButton.OK);
            }
            else
                MessageBox.Show("Error parsing Capacity. Enter a new value and try again.", "Error", MessageBoxButton.OK);
        }
    }
}
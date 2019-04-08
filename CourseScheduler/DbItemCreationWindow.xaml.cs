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
using System.Windows.Shapes;

namespace CourseScheduler
{
    /// <summary>
    /// Interaction logic for DbItemCreationWindow.xaml
    /// </summary>
    public partial class DbItemCreationWindow : Window
    {
        public DbItemCreationWindow()
        {
            InitializeComponent();
        }

        public DbItemCreationWindow(string DbObject, DataBaseHandler dataBaseHandler)
        {
            InitializeComponent();
            switch (DbObject)
            {
                case "Combinations":
                    AddCombinationControl addCombinationControl = new AddCombinationControl(dataBaseHandler);
                    DbCreateGrid.Children.Add(addCombinationControl);
                    break;
                case "CourseCombinations":

                    break;
                case "CourseEnrollments":

                    break;
                case "Courses":

                    break;
                case "InstructorPreferences":

                    break;
                case "Instructors":

                    break;
                case "Join_Schedules_PossibleCourses":

                    break;
                case "PossibleCourses":

                    break;
                case "Rooms":

                    break;
                case "Schedules":

                    break;
                case "Students":

                    break;
                default:
                    MessageBox.Show("There was an error trying to select the item to add to the database.", "Error", MessageBoxButton.OK);
                    Close();
                    break;
            }
        }
    }
}

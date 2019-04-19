using CourseScheduler.Custom_Controls;
using System.Windows;

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
                    MessageBox.Show("Not implemented.", "Warning", MessageBoxButton.OK);
                    Close();
                    break;
                case "CourseEnrollments":
                    AddCourseEnrollmentControl addCourseEnrollmentControl = new AddCourseEnrollmentControl(dataBaseHandler);
                    DbCreateGrid.Children.Add(addCourseEnrollmentControl);
                    break;
                case "Courses":
                    AddCourseControl addCourseControl = new AddCourseControl(dataBaseHandler);
                    DbCreateGrid.Children.Add(addCourseControl);
                    break;
                case "InstructorPreferences":
                    MessageBox.Show("Not implemented.", "Warning", MessageBoxButton.OK);
                    Close();
                    break;
                case "Instructors":
                    MessageBox.Show("Not implemented.", "Warning", MessageBoxButton.OK);
                    Close();
                    break;
                case "Join_Schedules_PossibleCourses":
                    MessageBox.Show("Not implemented.", "Warning", MessageBoxButton.OK);
                    Close();
                    break;
                case "PossibleCourses":
                    MessageBox.Show("Not implemented.", "Warning", MessageBoxButton.OK);
                    Close();
                    break;
                case "Rooms":
                    MessageBox.Show("Not implemented.", "Warning", MessageBoxButton.OK);
                    Close();
                    break;
                case "Schedules":
                    MessageBox.Show("Not implemented.", "Warning", MessageBoxButton.OK);
                    Close();
                    break;
                case "Students":
                    AddStudentControl addStudentControl = new AddStudentControl(dataBaseHandler);
                    DbCreateGrid.Children.Add(addStudentControl);
                    break;
                default:
                    MessageBox.Show("There was an error trying to select the item to add to the database.", "Error", MessageBoxButton.OK);
                    Close();
                    break;
            }
        }
    }
}

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

namespace CourseScheduler
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CourseSchedulerDataSetTableAdapters.CombinationsTableAdapter CombinationsTableAdapter;
        CourseSchedulerDataSetTableAdapters.CourseCombinationsTableAdapter CourseCombinationsTableAdapter;
        CourseSchedulerDataSetTableAdapters.CourseEnrollmentsTableAdapter CourseEnrollmentsTableAdapter;
        CourseSchedulerDataSetTableAdapters.CoursesTableAdapter CoursesTableAdapter;
        CourseSchedulerDataSetTableAdapters.InstructorPreferencesTableAdapter InstructorPreferencesTableAdapter;
        CourseSchedulerDataSetTableAdapters.InstructorsTableAdapter InstructorsTableAdapter;
        CourseSchedulerDataSetTableAdapters.PossibleCoursesTableAdapter PossibleCoursesTableAdapter;
        CourseSchedulerDataSetTableAdapters.RoomsTableAdapter RoomsTableAdapter;
        CourseSchedulerDataSetTableAdapters.StudentsTableAdapter StudentsTableAdapter;
        CourseSchedulerDataSetTableAdapters.TableAdapterManager TableAdapterManager;
        CourseSchedulerDataSet DataSet;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            InitializeDataSet();
        }

        private void InitializeDataSet()
        {
            DataSet = (CourseSchedulerDataSet)FindResource("courseSchedulerDataSet");
            CombinationsTableAdapter = new CourseSchedulerDataSetTableAdapters.CombinationsTableAdapter();
            CombinationsTableAdapter.Fill(DataSet.Combinations);

            CourseCombinationsTableAdapter = new CourseSchedulerDataSetTableAdapters.CourseCombinationsTableAdapter();
            CourseCombinationsTableAdapter.Fill(DataSet.CourseCombinations);

            CourseEnrollmentsTableAdapter = new CourseSchedulerDataSetTableAdapters.CourseEnrollmentsTableAdapter();
            CourseEnrollmentsTableAdapter.Fill(DataSet.CourseEnrollments);

            CoursesTableAdapter = new CourseSchedulerDataSetTableAdapters.CoursesTableAdapter();
            CoursesTableAdapter.Fill(DataSet.Courses);

            InstructorPreferencesTableAdapter = new CourseSchedulerDataSetTableAdapters.InstructorPreferencesTableAdapter();
            InstructorPreferencesTableAdapter.Fill(DataSet.InstructorPreferences);

            InstructorsTableAdapter = new CourseSchedulerDataSetTableAdapters.InstructorsTableAdapter();
            InstructorsTableAdapter.Fill(DataSet.Instructors);

            PossibleCoursesTableAdapter = new CourseSchedulerDataSetTableAdapters.PossibleCoursesTableAdapter();
            PossibleCoursesTableAdapter.Fill(DataSet.PossibleCourses);

            RoomsTableAdapter = new CourseSchedulerDataSetTableAdapters.RoomsTableAdapter();
            RoomsTableAdapter.Fill(DataSet.Rooms);

            StudentsTableAdapter = new CourseSchedulerDataSetTableAdapters.StudentsTableAdapter();
            StudentsTableAdapter.Fill(DataSet.Students);

            TableAdapterManager = new CourseSchedulerDataSetTableAdapters.TableAdapterManager();
            TableAdapterManager.CourseCombinationsTableAdapter = CourseCombinationsTableAdapter;
            TableAdapterManager.CourseEnrollmentsTableAdapter = CourseEnrollmentsTableAdapter;
            TableAdapterManager.CoursesTableAdapter = CoursesTableAdapter;
            TableAdapterManager.InstructorPreferencesTableAdapter = InstructorPreferencesTableAdapter;
            TableAdapterManager.InstructorsTableAdapter = InstructorsTableAdapter;
            TableAdapterManager.PossibleCoursesTableAdapter = PossibleCoursesTableAdapter;
            TableAdapterManager.RoomsTableAdapter = RoomsTableAdapter;
            TableAdapterManager.StudentsTableAdapter = StudentsTableAdapter;
        }

        private void UpdateDatabase_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TableAdapterManager.UpdateAll(DataSet);
                MessageBox.Show("Database Updated", "Update", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

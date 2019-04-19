using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data;
using System.Data.SqlClient;

namespace CourseScheduler
{
    public class DataBaseHandler
    {
        public CourseSchedulerDBDataSet DataSet;
        public CourseSchedulerDBDataSetTableAdapters.TableAdapterManager TableAdapterManager;
        //static string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\CourseSchedulerDB.mdf;Integrated Security = True; Connect Timeout = 30";

        public CourseSchedulerDBDataSetTableAdapters.RoomsTableAdapter RoomsTableAdapter;
        public CourseSchedulerDBDataSetTableAdapters.CoursesTableAdapter CoursesTableAdapter;
        public CourseSchedulerDBDataSetTableAdapters.StudentsTableAdapter StudentsTableAdapter;
        public CourseSchedulerDBDataSetTableAdapters.SchedulesTableAdapter SchedulesTableAdapter;
        public CourseSchedulerDBDataSetTableAdapters.InstructorsTableAdapter InstructorsTableAdapter;
        public CourseSchedulerDBDataSetTableAdapters.CombinationsTableAdapter CombinationsTableAdapter;
        public CourseSchedulerDBDataSetTableAdapters.PossibleCoursesTableAdapter PossibleCoursesTableAdapter;
        public CourseSchedulerDBDataSetTableAdapters.CourseEnrollmentsTableAdapter CourseEnrollmentsTableAdapter;
        public CourseSchedulerDBDataSetTableAdapters.CourseCombinationsTableAdapter CourseCombinationsTableAdapter;
        public CourseSchedulerDBDataSetTableAdapters.InstructorPreferencesTableAdapter InstructorPreferencesTableAdapter;
        public CourseSchedulerDBDataSetTableAdapters.Join_Schedules_PossibleCoursesTableAdapter Join_Schedules_PossibleCoursesTableAdapter;
        public CourseSchedulerDBDataSetTableAdapters.NoRelation_Join_Schedules_PossibleCoursesTableAdapter NoRelation_Join_Schedules_PossibleCoursesTableAdapter;
        public CourseSchedulerDBDataSetTableAdapters.NoRelation_InstructorPreferencesTableAdapter NoRelation_InstructorPreferencesTableAdapter;
        public CourseSchedulerDBDataSetTableAdapters.NoRelation_CourseCombinationsTableAdapter NoRelation_CourseCombinationsTableAdapter;
        public CourseSchedulerDBDataSetTableAdapters.NoRelation_CourseEnrollmentsTableAdapter NoRelation_CourseEnrollmentsTableAdapter;
        public CourseSchedulerDBDataSetTableAdapters.NoRelation_PossibleCoursesTableAdapter NoRelation_PossibleCoursesTableAdapter;
        public CourseSchedulerDBDataSetTableAdapters.NoRelation_CombinationsTableAdapter NoRelation_CombinationsTableAdapter;
        public CourseSchedulerDBDataSetTableAdapters.NoRelation_InstructorsTableAdapter NoRelation_InstructorsTableAdapter;
        public CourseSchedulerDBDataSetTableAdapters.NoRelation_SchedulesTableAdapter NoRelation_SchedulesTableAdapter;
        public CourseSchedulerDBDataSetTableAdapters.NoRelation_StudentsTableAdapter NoRelation_StudentsTableAdapter;
        public CourseSchedulerDBDataSetTableAdapters.NoRelation_CoursesTableAdapter NoRelation_CoursesTableAdapter;
        public CourseSchedulerDBDataSetTableAdapters.NoRelation_RoomsTableAdapter NoRelation_RoomsTableAdapter;

        public DataBaseHandler()
        {
            //SqlConnection conn = new SqlConnection(connectionString);
            //conn.Open();
            DataSet = (CourseSchedulerDBDataSet)Application.Current.FindResource("courseSchedulerDBDataSet");

            NoRelation_RoomsTableAdapter = new CourseSchedulerDBDataSetTableAdapters.NoRelation_RoomsTableAdapter();
            NoRelation_CoursesTableAdapter = new CourseSchedulerDBDataSetTableAdapters.NoRelation_CoursesTableAdapter();
            NoRelation_StudentsTableAdapter = new CourseSchedulerDBDataSetTableAdapters.NoRelation_StudentsTableAdapter();
            NoRelation_SchedulesTableAdapter = new CourseSchedulerDBDataSetTableAdapters.NoRelation_SchedulesTableAdapter();
            NoRelation_InstructorsTableAdapter = new CourseSchedulerDBDataSetTableAdapters.NoRelation_InstructorsTableAdapter();
            NoRelation_CombinationsTableAdapter = new CourseSchedulerDBDataSetTableAdapters.NoRelation_CombinationsTableAdapter();
            NoRelation_PossibleCoursesTableAdapter = new CourseSchedulerDBDataSetTableAdapters.NoRelation_PossibleCoursesTableAdapter();
            NoRelation_CourseEnrollmentsTableAdapter = new CourseSchedulerDBDataSetTableAdapters.NoRelation_CourseEnrollmentsTableAdapter();
            NoRelation_CourseCombinationsTableAdapter = new CourseSchedulerDBDataSetTableAdapters.NoRelation_CourseCombinationsTableAdapter();
            NoRelation_InstructorPreferencesTableAdapter = new CourseSchedulerDBDataSetTableAdapters.NoRelation_InstructorPreferencesTableAdapter();
            NoRelation_Join_Schedules_PossibleCoursesTableAdapter = new CourseSchedulerDBDataSetTableAdapters.NoRelation_Join_Schedules_PossibleCoursesTableAdapter();
            Join_Schedules_PossibleCoursesTableAdapter = new CourseSchedulerDBDataSetTableAdapters.Join_Schedules_PossibleCoursesTableAdapter();
            InstructorPreferencesTableAdapter = new CourseSchedulerDBDataSetTableAdapters.InstructorPreferencesTableAdapter();
            CourseCombinationsTableAdapter = new CourseSchedulerDBDataSetTableAdapters.CourseCombinationsTableAdapter();
            CourseEnrollmentsTableAdapter = new CourseSchedulerDBDataSetTableAdapters.CourseEnrollmentsTableAdapter();
            PossibleCoursesTableAdapter = new CourseSchedulerDBDataSetTableAdapters.PossibleCoursesTableAdapter();
            CombinationsTableAdapter = new CourseSchedulerDBDataSetTableAdapters.CombinationsTableAdapter();
            InstructorsTableAdapter = new CourseSchedulerDBDataSetTableAdapters.InstructorsTableAdapter();
            SchedulesTableAdapter = new CourseSchedulerDBDataSetTableAdapters.SchedulesTableAdapter();
            StudentsTableAdapter = new CourseSchedulerDBDataSetTableAdapters.StudentsTableAdapter();
            CoursesTableAdapter = new CourseSchedulerDBDataSetTableAdapters.CoursesTableAdapter();
            RoomsTableAdapter = new CourseSchedulerDBDataSetTableAdapters.RoomsTableAdapter();

            TableAdapterManager = new CourseSchedulerDBDataSetTableAdapters.TableAdapterManager();

            TableAdapterManager.RoomsTableAdapter = RoomsTableAdapter;
            TableAdapterManager.CoursesTableAdapter = CoursesTableAdapter;
            TableAdapterManager.StudentsTableAdapter = StudentsTableAdapter;
            TableAdapterManager.SchedulesTableAdapter = SchedulesTableAdapter;
            TableAdapterManager.InstructorsTableAdapter = InstructorsTableAdapter;
            TableAdapterManager.PossibleCoursesTableAdapter = PossibleCoursesTableAdapter;
            TableAdapterManager.CourseEnrollmentsTableAdapter = CourseEnrollmentsTableAdapter;
            TableAdapterManager.CourseCombinationsTableAdapter = CourseCombinationsTableAdapter;
            TableAdapterManager.InstructorPreferencesTableAdapter = InstructorPreferencesTableAdapter;
            TableAdapterManager.Join_Schedules_PossibleCoursesTableAdapter = Join_Schedules_PossibleCoursesTableAdapter;
            TableAdapterManager.NoRelation_Join_Schedules_PossibleCoursesTableAdapter = NoRelation_Join_Schedules_PossibleCoursesTableAdapter;
            TableAdapterManager.NoRelation_InstructorPreferencesTableAdapter = NoRelation_InstructorPreferencesTableAdapter;
            TableAdapterManager.NoRelation_CourseCombinationsTableAdapter = NoRelation_CourseCombinationsTableAdapter;
            TableAdapterManager.NoRelation_CourseEnrollmentsTableAdapter = NoRelation_CourseEnrollmentsTableAdapter;
            TableAdapterManager.NoRelation_PossibleCoursesTableAdapter = NoRelation_PossibleCoursesTableAdapter;
            TableAdapterManager.NoRelation_InstructorsTableAdapter = NoRelation_InstructorsTableAdapter;
            TableAdapterManager.NoRelation_SchedulesTableAdapter = NoRelation_SchedulesTableAdapter;
            TableAdapterManager.NoRelation_StudentsTableAdapter = NoRelation_StudentsTableAdapter;
            TableAdapterManager.NoRelation_CoursesTableAdapter = NoRelation_CoursesTableAdapter;
            TableAdapterManager.NoRelation_RoomsTableAdapter = NoRelation_RoomsTableAdapter;

            FillAdaptersWithDataSet();
        }

        public void FillAdaptersWithDataSet()
        {
            // TODO: Check which table is getting updated then only fill that adapter
            CoursesTableAdapter.Fill(DataSet.Courses);
            StudentsTableAdapter.Fill(DataSet.Students);
            SchedulesTableAdapter.Fill(DataSet.Schedules);
            InstructorsTableAdapter.Fill(DataSet.Instructors);
            CombinationsTableAdapter.Fill(DataSet.Combinations);
            PossibleCoursesTableAdapter.Fill(DataSet.PossibleCourses);
            CourseEnrollmentsTableAdapter.Fill(DataSet.CourseEnrollments);
            CourseCombinationsTableAdapter.Fill(DataSet.CourseCombinations);
            InstructorPreferencesTableAdapter.Fill(DataSet.InstructorPreferences);
            Join_Schedules_PossibleCoursesTableAdapter.Fill(DataSet.Join_Schedules_PossibleCourses);
            NoRelation_Join_Schedules_PossibleCoursesTableAdapter.Fill(DataSet.NoRelation_Join_Schedules_PossibleCourses);
            NoRelation_InstructorPreferencesTableAdapter.Fill(DataSet.NoRelation_InstructorPreferences);
            NoRelation_CourseCombinationsTableAdapter.Fill(DataSet.NoRelation_CourseCombinations);
            NoRelation_CourseEnrollmentsTableAdapter.Fill(DataSet.NoRelation_CourseEnrollments);
            NoRelation_PossibleCoursesTableAdapter.Fill(DataSet.NoRelation_PossibleCourses);
            NoRelation_CombinationsTableAdapter.Fill(DataSet.NoRelation_Combinations);
            NoRelation_InstructorsTableAdapter.Fill(DataSet.NoRelation_Instructors);
            NoRelation_SchedulesTableAdapter.Fill(DataSet.NoRelation_Schedules);
            NoRelation_StudentsTableAdapter.Fill(DataSet.NoRelation_Students);
            NoRelation_CoursesTableAdapter.Fill(DataSet.NoRelation_Courses);
            NoRelation_RoomsTableAdapter.Fill(DataSet.NoRelation_Rooms);

            TableAdapterManagerUpdateAll();
        }

        public void TableAdapterManagerUpdateAll()
        {
            TableAdapterManager.UpdateAll(DataSet);
        }

        public void InsertNewRoom(string RoomID, bool IsLarge, bool IsLab)
        {
            DataSet.Rooms.AddRoomsRow(RoomID, IsLarge, IsLab);
            RoomsTableAdapter.Update(DataSet.Rooms);
        }
        public void InsertNewCourse(string Name, int Credits, bool NeedsLabRoom, bool NeedsLargeRoom, bool IsElective, bool HasPrerequisite, string Major, int Capacity)
        {
            DataSet.Courses.AddCoursesRow(Name, Credits, NeedsLabRoom, NeedsLargeRoom, IsElective, HasPrerequisite, Major, Capacity);
            CoursesTableAdapter.Update(DataSet.Courses);
        }
        public void InsertNewStudent(string Name, string Cohort, string GraduationStatus, string Major, int CreditsFinished)
        {
            DataSet.Students.AddStudentsRow(Name, Cohort, GraduationStatus, Major, CreditsFinished);
            StudentsTableAdapter.Update(DataSet.Students);
        }
        public void InsertNewInstructor(string Name)
        {
            DataSet.Instructors.AddInstructorsRow(Name);
            InstructorsTableAdapter.Update(DataSet.Instructors);
        }
        public void InsertNewCombination(string logicalOperator)
        {
            DataSet.Combinations.AddCombinationsRow(logicalOperator);
            CombinationsTableAdapter.Update(DataSet.Combinations);
        }
        public void InsertNewPossibleCourse(CourseSchedulerDBDataSet.CoursesRow Course, CourseSchedulerDBDataSet.InstructorsRow Instructor, TimeSpan TimeOffered, DateTime DateOffered, CourseSchedulerDBDataSet.RoomsRow Room)
        {
            DataSet.PossibleCourses.AddPossibleCoursesRow(Course, Instructor, TimeOffered, DateOffered, Room);
            PossibleCoursesTableAdapter.Update(DataSet.PossibleCourses);
        }
        public void InsertNewCourseEnrollment(CourseSchedulerDBDataSet.StudentsRow StudentRow, CourseSchedulerDBDataSet.CoursesRow CourseRow, string CreditType, string CompletionStatus, string Grade)
        {
            DataSet.CourseEnrollments.AddCourseEnrollmentsRow(StudentRow, CourseRow, CreditType, CompletionStatus, Grade);
            CourseEnrollmentsTableAdapter.Update(DataSet.CourseEnrollments);
        }
        public void InsertNewCourseCombination(CourseSchedulerDBDataSet.CourseCombinationsRow CourseCombination, CourseSchedulerDBDataSet.CoursesRow Course, int SubCombinationID)
        {
            DataSet.CourseCombinations.AddCourseCombinationsRow(CourseCombination, Course, SubCombinationID);
            CourseCombinationsTableAdapter.Update(DataSet.CourseCombinations);
        }
        public void InsertNewInstructorPreference(CourseSchedulerDBDataSet.InstructorsRow Instructor, CourseSchedulerDBDataSet.CoursesRow Course, TimeSpan TimeOffered, DateTime DateOffered)
        {
            DataSet.InstructorPreferences.AddInstructorPreferencesRow(Instructor, Course, TimeOffered, DateOffered);
            InstructorPreferencesTableAdapter.Update(DataSet.InstructorPreferences);
        }
        public void InsertNewJoin_Schedules_PossibleCourses(CourseSchedulerDBDataSet.SchedulesRow Schedule, CourseSchedulerDBDataSet.PossibleCoursesRow PossibleCourse)
        {
            DataSet.Join_Schedules_PossibleCourses.AddJoin_Schedules_PossibleCoursesRow(Schedule, PossibleCourse);
            Join_Schedules_PossibleCoursesTableAdapter.Update(DataSet.Join_Schedules_PossibleCourses);
        }
    }
}

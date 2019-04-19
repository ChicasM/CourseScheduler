using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassSchedulerUI
{
    public partial class MainForm : Form
    {

        private DataTable mainTbl;

        public MainForm()
        {
            InitializeComponent();
            GetDataTable();
        }

        public void GetDataTable()
        {
            mainTbl = new DataTable();

            DataColumn ID = new DataColumn(Name = "ID");
            DataColumn score = new DataColumn(Name = "Score");
            DataColumn creditHrs = new DataColumn(Name = "CreditHrs");
            DataColumn totalClasses = new DataColumn(Name = "#OfClasses");

            mainTbl.Columns.Add(ID);
            mainTbl.Columns.Add(score);
            mainTbl.Columns.Add(creditHrs);
            mainTbl.Columns.Add(totalClasses);
            
            grdSchedule.DataSource = mainTbl;

            

            DataRow row = mainTbl.NewRow();
            row["Score"] = 83;
            row["CreditHrs"] = 18;
            row["#OfClasses"] = 6;
            mainTbl.Rows.Add(row);

            grdSchedule.Columns["ID"].Visible = false;
        }

        public void SwapToDetailed()
        {
            grdSchedule.DataSource = null;

            mainTbl = new DataTable();

            DataColumn ID = new DataColumn(Name = "ID");
            DataColumn className = new DataColumn(Name = "Class");
            DataColumn creditHrs = new DataColumn(Name = "CreditHrs");
            DataColumn time = new DataColumn(Name = "Time");
            DataColumn date = new DataColumn(Name = "Date");

            mainTbl.Columns.Add(ID);
            mainTbl.Columns.Add(className);
            mainTbl.Columns.Add(creditHrs);
            mainTbl.Columns.Add(date);
            mainTbl.Columns.Add(time);

            grdSchedule.DataSource = mainTbl;

            DataRow row1 = mainTbl.NewRow();
            row1["Class"] = "SENG 302";
            row1["CreditHrs"] = 3;
            row1["Time"] = 15;
            row1["Date"] = DateTime.Today.ToShortDateString();
            mainTbl.Rows.Add(row1);

            DataRow row2 = mainTbl.NewRow();
            row2["Class"] = "SENG 400";
            row2["CreditHrs"] = 3;
            row2["Time"] = 14;
            row2["Date"] = DateTime.Today.ToShortDateString();
            mainTbl.Rows.Add(row2);

            DataRow row3 = mainTbl.NewRow();
            row3["Class"] = "SENG 301";
            row3["CreditHrs"] = 3;
            row3["Time"] = 7;
            row3["Date"] = DateTime.Today.ToShortDateString();
            mainTbl.Rows.Add(row3);

            DataRow row4 = mainTbl.NewRow();
            row4["Class"] = "CIS 310";
            row4["CreditHrs"] = 3;
            row4["Time"] = 10;
            row4["Date"] = DateTime.Today.ToShortDateString();
            mainTbl.Rows.Add(row4);

            DataRow row5 = mainTbl.NewRow();
            row5["Class"] = "CIS 420";
            row5["CreditHrs"] = 3;
            row5["Time"] = 17;
            row5["Date"] = DateTime.Today.ToShortDateString();
            mainTbl.Rows.Add(row5);

            DataRow row6 = mainTbl.NewRow();
            row6["Class"] = "SENG 9000";
            row6["CreditHrs"] = 3;
            row6["Time"] = 20;
            row6["Date"] = DateTime.Today.ToShortDateString();
            mainTbl.Rows.Add(row6);

            grdSchedule.Columns["ID"].Visible = false;
        }

        public void SwapToWeekly()
        {
            grdSchedule.DataSource = null;

            mainTbl = new DataTable();

            DataColumn ID = new DataColumn(Name = "ID");
            DataColumn Time = new DataColumn(Name = "Time");
            DataColumn monday = new DataColumn(Name = "Monday");
            DataColumn tuesday = new DataColumn(Name = "Tuesday");
            DataColumn wednesday = new DataColumn(Name = "Wednesday");
            DataColumn thurs = new DataColumn(Name = "Thursday");
            DataColumn friday = new DataColumn(Name = "Friday");

            mainTbl.Columns.Add(ID);
            mainTbl.Columns.Add(Time);
            mainTbl.Columns.Add(monday);
            mainTbl.Columns.Add(tuesday);
            mainTbl.Columns.Add(wednesday);
            mainTbl.Columns.Add(thurs);
            mainTbl.Columns.Add(friday);

            grdSchedule.DataSource = mainTbl;

            grdSchedule.Columns["ID"].Visible = false;

            for(int i = 7; i <= 21; i++)
            {
                DataRow row = mainTbl.NewRow();
                row["Time"] = i;

                mainTbl.Rows.Add(row);
            }
        }

        private void grdSchedule_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SwapToDetailed();
            grpControls.Visible = true;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            grpControls.Visible = false;
            GetDataTable();
        }

        private void btnOverview_Click(object sender, EventArgs e)
        {
            SwapToDetailed();
        }

        private void btnWeekly_Click(object sender, EventArgs e)
        {
            SwapToWeekly();
        }
    }
}

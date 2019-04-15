namespace ClassSchedulerUI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpControls = new System.Windows.Forms.GroupBox();
            this.btnOverview = new System.Windows.Forms.Button();
            this.btnWeekly = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.grpData = new System.Windows.Forms.GroupBox();
            this.grdSchedule = new System.Windows.Forms.DataGridView();
            this.grpControls.SuspendLayout();
            this.grpData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSchedule)).BeginInit();
            this.SuspendLayout();
            // 
            // grpControls
            // 
            this.grpControls.Controls.Add(this.btnOverview);
            this.grpControls.Controls.Add(this.btnWeekly);
            this.grpControls.Controls.Add(this.btnBack);
            this.grpControls.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpControls.Location = new System.Drawing.Point(0, 0);
            this.grpControls.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpControls.Name = "grpControls";
            this.grpControls.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpControls.Size = new System.Drawing.Size(1007, 113);
            this.grpControls.TabIndex = 0;
            this.grpControls.TabStop = false;
            this.grpControls.Text = "Controls";
            this.grpControls.Visible = false;
            // 
            // btnOverview
            // 
            this.btnOverview.Location = new System.Drawing.Point(12, 27);
            this.btnOverview.Name = "btnOverview";
            this.btnOverview.Size = new System.Drawing.Size(115, 53);
            this.btnOverview.TabIndex = 2;
            this.btnOverview.Text = "Show  Overview";
            this.btnOverview.UseVisualStyleBackColor = true;
            this.btnOverview.Click += new System.EventHandler(this.btnOverview_Click);
            // 
            // btnWeekly
            // 
            this.btnWeekly.Location = new System.Drawing.Point(147, 27);
            this.btnWeekly.Name = "btnWeekly";
            this.btnWeekly.Size = new System.Drawing.Size(115, 53);
            this.btnWeekly.TabIndex = 1;
            this.btnWeekly.Text = "Show Weekly";
            this.btnWeekly.UseVisualStyleBackColor = true;
            this.btnWeekly.Click += new System.EventHandler(this.btnWeekly_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(913, 64);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(82, 41);
            this.btnBack.TabIndex = 0;
            this.btnBack.Text = "<Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // grpData
            // 
            this.grpData.Controls.Add(this.grdSchedule);
            this.grpData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpData.Location = new System.Drawing.Point(0, 113);
            this.grpData.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpData.Name = "grpData";
            this.grpData.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpData.Size = new System.Drawing.Size(1007, 488);
            this.grpData.TabIndex = 1;
            this.grpData.TabStop = false;
            this.grpData.Text = "Schedule";
            // 
            // grdSchedule
            // 
            this.grdSchedule.AllowUserToAddRows = false;
            this.grdSchedule.AllowUserToDeleteRows = false;
            this.grdSchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdSchedule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdSchedule.Location = new System.Drawing.Point(4, 24);
            this.grdSchedule.Name = "grdSchedule";
            this.grdSchedule.ReadOnly = true;
            this.grdSchedule.Size = new System.Drawing.Size(999, 459);
            this.grdSchedule.TabIndex = 0;
            this.grdSchedule.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdSchedule_CellDoubleClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1007, 601);
            this.Controls.Add(this.grpData);
            this.Controls.Add(this.grpControls);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainForm";
            this.Text = "Class Schedule Viewer";
            this.grpControls.ResumeLayout(false);
            this.grpData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSchedule)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpControls;
        private System.Windows.Forms.GroupBox grpData;
        private System.Windows.Forms.DataGridView grdSchedule;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnOverview;
        private System.Windows.Forms.Button btnWeekly;
    }
}


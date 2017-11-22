namespace SecurityAssessmentTool
{
    partial class SecurityAssessmentTool
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
            this.Button_Validate = new System.Windows.Forms.Button();
            this.Button_Exit = new System.Windows.Forms.Button();
            this.Violation_list = new System.Windows.Forms.TextBox();
            this.Button_Download_report = new System.Windows.Forms.Button();
            this.Project_Path_text = new System.Windows.Forms.TextBox();
            this.Button_LoadProject = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Button_Validate
            // 
            this.Button_Validate.Enabled = false;
            this.Button_Validate.Location = new System.Drawing.Point(591, 43);
            this.Button_Validate.Name = "Button_Validate";
            this.Button_Validate.Size = new System.Drawing.Size(107, 23);
            this.Button_Validate.TabIndex = 0;
            this.Button_Validate.Text = "Run Validation";
            this.Button_Validate.UseVisualStyleBackColor = true;
            this.Button_Validate.Click += new System.EventHandler(this.Button_Validate_Click);
            // 
            // Button_Exit
            // 
            this.Button_Exit.Location = new System.Drawing.Point(591, 72);
            this.Button_Exit.Name = "Button_Exit";
            this.Button_Exit.Size = new System.Drawing.Size(107, 23);
            this.Button_Exit.TabIndex = 1;
            this.Button_Exit.Text = "Exit";
            this.Button_Exit.UseVisualStyleBackColor = true;
            this.Button_Exit.Click += new System.EventHandler(this.Button_Exit_Click);
            // 
            // Violation_list
            // 
            this.Violation_list.Location = new System.Drawing.Point(13, 43);
            this.Violation_list.MaxLength = 10000000;
            this.Violation_list.Multiline = true;
            this.Violation_list.Name = "Violation_list";
            this.Violation_list.ReadOnly = true;
            this.Violation_list.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Violation_list.Size = new System.Drawing.Size(572, 255);
            this.Violation_list.TabIndex = 2;
            // 
            // Button_Download_report
            // 
            this.Button_Download_report.Enabled = false;
            this.Button_Download_report.Location = new System.Drawing.Point(591, 275);
            this.Button_Download_report.Name = "Button_Download_report";
            this.Button_Download_report.Size = new System.Drawing.Size(107, 23);
            this.Button_Download_report.TabIndex = 3;
            this.Button_Download_report.Text = "Download";
            this.Button_Download_report.UseVisualStyleBackColor = true;
            this.Button_Download_report.Visible = false;
            // 
            // Project_Path_text
            // 
            this.Project_Path_text.Enabled = false;
            this.Project_Path_text.Location = new System.Drawing.Point(13, 12);
            this.Project_Path_text.Name = "Project_Path_text";
            this.Project_Path_text.Size = new System.Drawing.Size(572, 20);
            this.Project_Path_text.TabIndex = 4;
            // 
            // Button_LoadProject
            // 
            this.Button_LoadProject.Location = new System.Drawing.Point(591, 12);
            this.Button_LoadProject.Name = "Button_LoadProject";
            this.Button_LoadProject.Size = new System.Drawing.Size(106, 22);
            this.Button_LoadProject.TabIndex = 5;
            this.Button_LoadProject.Text = "Load Project";
            this.Button_LoadProject.UseVisualStyleBackColor = true;
            this.Button_LoadProject.Click += new System.EventHandler(this.Button_LoadProject_Click);
            // 
            // SecurityAssessmentTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(706, 310);
            this.Controls.Add(this.Button_LoadProject);
            this.Controls.Add(this.Project_Path_text);
            this.Controls.Add(this.Button_Download_report);
            this.Controls.Add(this.Violation_list);
            this.Controls.Add(this.Button_Exit);
            this.Controls.Add(this.Button_Validate);
            this.Name = "SecurityAssessmentTool";
            this.Text = "Security Assessment Tool";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Button_Validate;
        private System.Windows.Forms.Button Button_Exit;
        private System.Windows.Forms.TextBox Violation_list;
        private System.Windows.Forms.Button Button_Download_report;
        private System.Windows.Forms.TextBox Project_Path_text;
        private System.Windows.Forms.Button Button_LoadProject;
    }
}


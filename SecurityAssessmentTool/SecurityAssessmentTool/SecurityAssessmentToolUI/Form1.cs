using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using SecurityAssessmentTool.RiskAnalyzer;

namespace SecurityAssessmentTool
{
    public partial class SecurityAssessmentTool : Form
    {
        public SecurityAssessmentTool()
        {
            InitializeComponent();
        }


        private void Button_Validate_Click(object sender, EventArgs e)
        {
            FileSelector fsObj = new FileSelector();
            List<string> error_List = new List<string>();
            string ProjectPath;

            ProjectPath = Project_Path_text.Text;

            error_List = fsObj.ValidateAllFiles(ProjectPath);

        }

        private void Button_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Button_LoadProject_Click(object sender, EventArgs e)
        {
            string folderPath = "";
            FolderBrowserDialog directchoosedlg = new FolderBrowserDialog();
            if (directchoosedlg.ShowDialog() == DialogResult.OK)
            {
                folderPath = directchoosedlg.SelectedPath;
            }
            Project_Path_text.Text = folderPath;
            Button_Validate.Enabled = true;
        }
    }
}

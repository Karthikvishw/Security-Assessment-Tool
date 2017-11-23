using System;
using System.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SecurityAssessmentTool.DataExtractor
{
    class sqlVRMExtractor
    {
        public SqlConnection sqlVRMdb = new SqlConnection("");

            //("Server=myServerAddress;Database=VulnerabilityRuleMatrix;Uid=root;Pwd=pwd@123;");
        public void OpenVRM()
        {
            try
            {
                sqlVRMdb.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Connection Error! "+ex.Message);
            }
        }
        public void CloseVRM()
        {
            try
            {
                sqlVRMdb.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Termination Error! " + ex.Message);
            }
        }
    }
}

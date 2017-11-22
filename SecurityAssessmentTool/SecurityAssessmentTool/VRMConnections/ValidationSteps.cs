using SecurityAssessmentTool.DataExtractor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SecurityAssessmentTool.VRMConnections
{
    class ValidationSteps
    {
        sqlVRMExtractor sqlVRMvsObj = new sqlVRMExtractor();
        List<structValidationsteps> strucVS = new List<structValidationsteps>();

        internal List<structValidationsteps> getSteps(string rule)
        {
            try
            {
                sqlVRMvsObj.OpenVRM();
                string queryString = "select FVR.iRuleID, VS.iValidationID, VS.cValidationOrder, VS.cIteration, VS.cValidationIndicator, VS.cRegExp, VS.cScope, VS.cDelimiter" +
                    "VS.cListIndicator, VS.cListRegExp, VS.cListPrefix, VS.cListSufix"+
                    "from FR_VS_Rel FVR, ValidationStep VS " +
                    "where FVR.iRuleID=@tRule and FVR.iRuleID=VS.iRuleID and FVR.cRCD_Del <> @RCDDel and VS.cRCD_Del <> @RCDDel order by VS.cValidationOrder";
                
                SqlCommand command = new SqlCommand(queryString, sqlVRMvsObj.sqlVRMdb);
                command.Parameters.AddWithValue("@tRule", rule);
                command.Parameters.AddWithValue("@RCDDel", "Y");

                SqlDataReader reader = command.ExecuteReader();
                structValidationsteps VS = new structValidationsteps();

                while (reader.Read())
                {
                    VS.iRuleID = Convert.ToInt32(reader["iRuleID"]);
                    VS.iValidationID = Convert.ToInt32(reader["iValidationID"]);
                    VS.iValidationOrder = Convert.ToInt32(reader["iValidationOrder"]);
                    VS.cIteration = reader["cIteration"].ToString();
                    VS.cValidationIndicator = reader["cValidationIndicator"].ToString();
                    VS.cRegExp = reader["cRegExp"].ToString();
                    VS.cScope = reader["cScope"].ToString();
                    VS.cDelimiter = reader["cDelimiter"].ToString();
                    VS.cListIndicator = reader["cListIndicator"].ToString();
                    VS.cListRegExp = reader["cListRegExp"].ToString();
                    VS.cListPrefix = reader["cListPrefix"].ToString();
                    VS.cListSufix = reader["cListSufix"].ToString();
                    strucVS.Add(VS); 
                }
            }
            finally
            {
                sqlVRMvsObj.CloseVRM();
            }

            return strucVS;
        }
    }
}

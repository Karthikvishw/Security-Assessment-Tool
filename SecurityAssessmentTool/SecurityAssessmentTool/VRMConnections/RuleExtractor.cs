using SecurityAssessmentTool.DataExtractor;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SecurityAssessmentTool.VRMConnections
{ 
    class RuleExtractor
    {
        sqlVRMExtractor sqlVRMreObj = new sqlVRMExtractor();


        internal string getProgrammingFeature(string line, string language)
        {
            string ProgFeature="";
            Regex exp = new Regex("");

            try
            {
                sqlVRMreObj.OpenVRM();
                string queryString = "select iPFID,cRegExp from ProgrammingFeature where cPLanguage = @tPlang and rel.cRCD_Del <> @RCDDel";
                SqlCommand command = new SqlCommand(queryString, sqlVRMreObj.sqlVRMdb);
                command.Parameters.AddWithValue("@tPlang", language);
                command.Parameters.AddWithValue("@RCDDel", "Y");

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    exp = new Regex(reader["cRegExp"].ToString());
                    Match m = exp.Match(line);
                    if (m.Success)
                    {
                        ProgFeature = reader["iPFID"].ToString();
                        break;
                    }
                }
            }
            finally
            {
                sqlVRMreObj.CloseVRM();
            }
            
            return ProgFeature;
        }

        internal List<string> getAllRules(string PFid)
        {
            List<string> AllRules = new List<string>();
            AllRules.Add("");
            try
            {
                sqlVRMreObj.OpenVRM();
                string queryString = "select rel.iRuleID from PF_FR_Rel rel where rel.iPFID = @tPFid and rel.cRCD_Del <> @RCDDel";
                SqlCommand command = new SqlCommand(queryString, sqlVRMreObj.sqlVRMdb);
                command.Parameters.AddWithValue("@tPFid", PFid);
                command.Parameters.AddWithValue("@RCDDel", "Y");

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    AllRules.Add(reader["iRuleID"].ToString());
                }
            }
            finally
            {
                sqlVRMreObj.CloseVRM();
            }

            return AllRules;
        }

    }
}

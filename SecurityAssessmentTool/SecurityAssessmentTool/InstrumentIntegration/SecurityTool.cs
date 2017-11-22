using SecurityAssessmentTool.RiskAnalyzer;
using SecurityAssessmentTool.VRMConnections;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SecurityAssessmentTool.InstrumentIntegration
{
    public class SecurityTool
    {
        //Risk Analysis Tool Components
        CodeAnalyzer caObj = new CodeAnalyzer();

        //Vulnerability Rule Matrix
        RuleExtractor reObj = new RuleExtractor();
        ValidationSteps vsObj = new ValidationSteps();

        public List<string> CodeValidate(string RawCode,string Language)
        {
            List<string> Violations = new List<string>();
            List<string> Rules = new List<string>();

            string[] sLOC = RawCode.Split(';', '\n');

            foreach (string Line in sLOC)
            {
                MessageBox.Show(Line);
                Rules = caObj.getRules(Line,Language);
                string Violation;
                foreach (string Rule in Rules)
                {
                    Violation = caObj.checkViolation(Line,Rule);
                    if (!Violation.Equals(""))
                        Violations.Add(Violation);
                }
            }
            return Violations;
        }
       
    }
}

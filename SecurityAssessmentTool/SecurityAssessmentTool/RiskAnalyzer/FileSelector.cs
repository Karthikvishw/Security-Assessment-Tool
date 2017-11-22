using SecurityAssessmentTool.InstrumentIntegration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityAssessmentTool.RiskAnalyzer
{
    class FileSelector
    {
        string RawCode;
        string Ext;
        List<string> Violations = new List<string>();
        SecurityTool stObj = new SecurityTool();

        public List<string> ValidateAllFiles(string ProjectPath)
        {
            foreach (string file in Directory.EnumerateFiles(ProjectPath, "*"))
            {
                RawCode = File.ReadAllText(file);
                Ext = Path.GetExtension(file);
                Violations = stObj.CodeValidate(RawCode, Ext);
            }
            return Violations;
        }
    }
}

using SecurityAssessmentTool.VRMConnections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SecurityAssessmentTool.RiskAnalyzer
{
    class CodeAnalyzer
    {
        RuleExtractor reObj = new RuleExtractor();
        ValidationSteps vsObj = new ValidationSteps();

        internal List<string> getRules(string Line, string language)
        {
            List<string> Rules = new List<string>();
            string ProgFeature = reObj.getProgrammingFeature(Line,language);
            Rules = reObj.getAllRules(ProgFeature);
            return Rules;
        }

        internal string checkViolation(string Line,string Rule)
        {
            string Violation;
            List<structValidationsteps> steps = new List<structValidationsteps>();
            Violation = "";
            steps = vsObj.getSteps(Rule);
            List<string> Heap = new List<string>();
            List<string> Buffer = new List<string>();
            foreach (structValidationsteps step in steps)
            {
                switch(step.cIteration)
                {
                    case "L":
                        if (step.cListIndicator == "E")
                        {
                            switch(step.cScope)
                            {
                                case "Line":
                                    Buffer = extractAll(Line, step.cRegExp, step.cDelimiter);
                                    break;
                                case "Heap":
                                    
                                    break;
                                case "Class":
                                    
                                    break;
                                case "Package":
                                    
                                    break;
                                case "External":
                                    
                                    break;
                            }

                            if(step.cListIndicator == "S")
                            {
                                foreach(string s in Buffer)
                                    Heap.Add(step.cListSufix + '_' + s + '_' + step.cListSufix);
                            }
                            else if (step.cListIndicator == "R")
                            {
                                
                            }
                        }
                        else if (step.cListIndicator == "M")
                        {
                            
                        }
                            
                        break;

                    case "S":
                        break;
                }
            }
            return Violation;
        }

        private List<string> extractAll(string Line, string rex, string deli)
        {
            Regex r = new Regex(rex);
            List<string> buf = new List<string>();
            string temp;
            foreach (Match m in r.Matches(Line))
            {
                temp = m.Value;
                foreach(char c in deli)
                {
                    temp = removeall(temp,c);
                    buf.Add(temp);
                }
            }
            return buf;
        }

        private string removeall(string temp, char c)
        {
            temp = temp.Replace(c.ToString(), "");
            return temp;
        }
    }
}

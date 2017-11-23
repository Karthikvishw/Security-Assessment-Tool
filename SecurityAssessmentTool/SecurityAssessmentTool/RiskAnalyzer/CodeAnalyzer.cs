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
                Buffer.Clear();
                switch(step.cIteration)
                {
                    case "L":
                        if (step.cValidationIndicator == "E")
                        {
                            switch(step.cScope)
                            {
                                case "Line":
                                    Buffer = ExtractAll(Line, step.cRegExp, step.cDelimiter);
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
                        else if (step.cValidationIndicator == "M")
                        {
                            switch (step.cScope)
                            {
                                case "List":
                                    Buffer = ExtractAllList(Heap, step.cRegExp, step.cDelimiter);
                                    break;
                            }
                        }
                            
                        break;

                    case "S":
                        if (step.cValidationIndicator == "E")
                        {
                            switch (step.cScope)
                            {
                                case "Line":
                                    Buffer.Add(Extract(Line, step.cRegExp, step.cDelimiter));
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

                            if (step.cListIndicator == "S")
                            {
                                foreach (string s in Buffer)
                                    Heap.Add(step.cListSufix + '_' + s + '_' + step.cListSufix);
                            }
                            else if (step.cListIndicator == "R")
                            {

                            }
                        }
                        else if (step.cValidationIndicator == "M")
                        {
                            switch (step.cScope)
                            {
                                case "List":
                                    Buffer = ExtractAllList(Heap, step.cRegExp, step.cDelimiter);
                                    break;
                            }
                        }
                        break;
                }
            }
            return Violation;
        }

        private string Extract(string Line, string rex, string deli)
        {
            Regex r = new Regex(rex);
            string buf;
            Match m = r.Match(Line);
            if (m.Success)
            {
                buf = m.Value;
                if (deli.Contains("SATDelimiterID_"))
                {
                    buf = removeall(buf, deli);
                }
                else
                {
                    foreach (char c in deli)
                    {
                        buf = removeall(buf, c);
                    }
                }
                return buf;
            }
            return "";
        }

        private List<string> ExtractAll(string Line, string rex, string deli)
        {
            Regex r = new Regex(rex);
            List<string> buf = new List<string>();
            string temp;
            foreach (Match m in r.Matches(Line))
            {
                temp = m.Value;

                if (deli.Contains("SATDelimiterID_"))
                {
                    temp = removeall(temp, deli);
                    buf.Add(temp);
                }
                else
                {
                    foreach (char c in deli)
                    {
                        temp = removeall(temp, c);
                        buf.Add(temp);
                    }
                }
            }
            return buf;
        }

        private List<string> ExtractAllList(List<string> heap, string rex, string deli)
        {
            Regex r = new Regex(rex);
            List<string> buf = new List<string>();
            Match m;

            foreach (string temp in heap)
            {
                m = r.Match(temp);
                if (m.Success && string.Compare(temp, m.Value) == 0)
                {
                    if (deli.Contains("SATDelimiterID_"))
                    {
                        buf.Add(removeall(temp, deli));
                    }
                    else
                    {
                        foreach (char c in deli)
                        {
                            buf.Add(removeall(temp, c));
                        }
                    }
                }
            }
            return buf;
        }

        private string removeall(string temp, char c)
        {
            temp = temp.Replace(c.ToString(), "");
            return temp;
        }

        private string removeall(string temp, string deli)
        {
            List<string> buf = new List<string>();
            buf = reObj.getAllDelimiters(deli);

            foreach (string temp1 in buf)
            {
                temp = temp.Replace(temp1, "");
            }
            return temp;
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Poem_Generator.Entities
{
    public class RulesFactory
    {
        public static Dictionary<string, Rule> GetDictionaryOfRules(string fileName)
        {
            Dictionary<string, Rule> rules = new Dictionary<string, Rule>();
            string path = $"{System.IO.Directory.GetCurrentDirectory()}\\{fileName}";
            string[] rulesFileLines = FilesHandler.getLinesFromFile(path);
            
            foreach (string ruleLine in rulesFileLines)
            {
                string[] NameBreakdown = ruleLine.Split(':');
                string RuleName = NameBreakdown[0].Trim();
                string[] DefinitionBreakdown = NameBreakdown[1].Trim().Split(' ');
                List<string[]> RuleComponents = new List<string[]>();
                foreach (string definition in DefinitionBreakdown)
                {
                    string[] components = definition.Trim().Split('|');
                    RuleComponents.Add(components);
                }
                Rule rule = new Rule(RuleComponents);
                rules.Add(RuleName, rule);
            }
            return rules;
        }
    }
}

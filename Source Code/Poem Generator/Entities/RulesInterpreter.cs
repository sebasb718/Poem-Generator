using System;
using System.Collections.Generic;
using System.Text;

namespace Poem_Generator.Entities
{
    public class RulesInterpreter
    {
        private Dictionary<string, Rule> Rules = new Dictionary<string, Rule>();
        public RulesInterpreter(Dictionary<string, Rule> Rules)
        {
            this.Rules = Rules;
        }
        public string GetTextForRule(string RuleName)
        {
            List<Rule> RuleStack = new List<Rule>();
            Rule firstRule = Rules[RuleName];
            RuleStack.Add(firstRule.DeepCopy());
            string text = "";
            while (RuleStack.Count > 0)
            {
                Rule actualRule = RuleStack[RuleStack.Count - 1];
                string nextComponent = actualRule.GetNextRandomComponent();
                if (actualRule.TottallyApplied())
                {
                    RuleStack.Remove(actualRule);
                }
                if (nextComponent == "$END")
                {
                    continue;
                }
                else if (nextComponent == "$LINEBREAK")
                {
                    text += System.Environment.NewLine;
                }
                else if (nextComponent.Contains('<'))
                {
                    Rule nextRule = Rules[nextComponent.Trim('<').Trim('>')];
                    RuleStack.Add(nextRule.DeepCopy());
                }
                else
                {
                    text += nextComponent + " ";
                }
            }
            return text;
        }

    }
}

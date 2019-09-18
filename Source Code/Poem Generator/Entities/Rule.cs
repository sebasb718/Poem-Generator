using System;
using System.Collections.Generic;
using System.Text;

namespace Poem_Generator.Entities
{
    public class Rule
    {
        private List<string[]> RuleComponents;
        private Random RandomGenerator = new Random();
        private int ComponentIndex = 0;

        public Rule(List<string[]> RuleComponents)
        {
            this.RuleComponents = RuleComponents;
        }
        public string GetNextRandomComponent()
        {
            string[] ActualComponent = RuleComponents[ComponentIndex];
            int randomInt = RandomGenerator.Next(ActualComponent.Length);
            ComponentIndex++;
            return ActualComponent[randomInt].Trim();
        }
        public bool TottallyApplied()
        {
            if (ComponentIndex == RuleComponents.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void SetRuleComponents(List<string[]> RuleComponents)
        {
            this.RuleComponents = new List<string[]>(RuleComponents);
        }
        public Rule DeepCopy()
        {
            Rule other = (Rule)this.MemberwiseClone();
            other.SetRuleComponents(RuleComponents);
            return other;
        }
    }
}

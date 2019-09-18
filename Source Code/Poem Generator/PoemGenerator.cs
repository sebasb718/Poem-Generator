using Poem_Generator.Entities;
using System;
using System.Collections.Generic;

namespace Poem_Generator
{
    class PoemGenerator
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("------------------------- POEM ------------------------------");
                Console.WriteLine(PoemGenerator.CreatePoem());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine("Press any key to finish");
                Console.ReadKey();
            }
        }

        static string CreatePoem()
        {
            Dictionary<string, Rule> rules = RulesFactory.GetDictionaryOfRules("rules.txt");
            RulesInterpreter intepreter = new RulesInterpreter(rules);
            string poem = intepreter.GetTextForRule("POEM");
            return poem;
        }
    }
}

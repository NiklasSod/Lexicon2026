using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace LexiconTest1.Kattis
{
    internal class _4thought
    {
        static void Main(string[] args)
        {
            var solutions = PreComputeAll(); 
            // solutions[0] = CalculationResult { Value = 16, Expression = 4 + 4 + 4 + 4 }
            string testLength = Console.ReadLine();

            if (int.TryParse(testLength, out int testCases))
            {
                for (int i = 0; i < testCases; i++)
                {
                    string testCase = Console.ReadLine();
                    if (int.TryParse(testCase, out int number))
                    {
                        var match = solutions.FirstOrDefault(s => s.Value == number);
                        if (match != null)
                        {
                            Console.WriteLine($"{match.Expression} = {match.Value}");
                        }
                        else
                        {
                            Console.WriteLine($"no solution");
                        }
                    }

                }
            }
        }

        public record CalculationResult(int Value, string Expression);

        static List<CalculationResult> PreComputeAll()
        {
            string[] operations = { "+", "-", "*", "/" };
            var results = new List<CalculationResult>();
            DataTable dataTable = new DataTable();

            var combinations = from op1 in operations
                               from op2 in operations
                               from op3 in operations
                               select new { op1, op2, op3 };

            foreach (var c in combinations)
            {
                string expression = $"4 {c.op1} 4 {c.op2} 4 {c.op3} 4";
                var valRaw = dataTable.Compute(expression, "");
                int val = Convert.ToInt32(valRaw);
                if (val >= -60 && val <= 256 && !results.Any(r => r.Value == val))
                {
                    results.Add(new CalculationResult(val, expression));
                }
            }
            return results; //.OrderBy(r => r.Value).ToList();
        }
    }
}

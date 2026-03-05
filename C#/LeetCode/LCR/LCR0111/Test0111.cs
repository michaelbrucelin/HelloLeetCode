using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0111
{
    public class Test0111
    {
        public void Test()
        {
            Interface0111 solution = new Solution0111_err();
            IList<IList<string>> equations; double[] values; IList<IList<string>> queries;
            double[] result, answer;
            int id = 0;

            // 1. 
            equations = [["a", "b"], ["b", "c"]]; values = [2.0, 3.0]; queries = [["a", "c"], ["b", "a"], ["a", "e"], ["a", "a"], ["x", "x"]];
            answer = [6.00000, 0.50000, -1.00000, 1.00000, -1.00000];
            result = solution.CalcEquation(equations, values, queries);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            equations = [["a", "b"], ["b", "c"], ["bc", "cd"]]; values = [1.5, 2.5, 5.0]; queries = [["a", "c"], ["c", "b"], ["bc", "cd"], ["cd", "bc"]];
            answer = [3.75000, 0.40000, 5.00000, 0.20000];
            result = solution.CalcEquation(equations, values, queries);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 3. 
            equations = [["a", "b"]]; values = [0.5]; queries = [["a", "b"], ["b", "a"], ["a", "c"], ["x", "y"]];
            answer = [0.50000, 2.00000, -1.00000, -1.00000];
            result = solution.CalcEquation(equations, values, queries);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 4. 
            equations = [["a", "e"], ["b", "e"]]; values = [4.0, 3.0]; queries = [["a", "b"], ["e", "e"], ["x", "x"]];
            answer = [1.33333, 1.0, -1.0];
            result = solution.CalcEquation(equations, values, queries);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}

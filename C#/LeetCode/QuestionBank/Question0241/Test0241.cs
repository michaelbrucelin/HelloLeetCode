using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0241
{
    public class Test0241
    {
        public void Test()
        {
            Interface0241 solution = new Solution0241();
            string expression;
            IList<int> result, answer;
            int id = 0;

            // 1. 
            expression = "2-1-1";
            answer = [0, 2];
            result = solution.DiffWaysToCompute(expression);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer, true) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            expression = "2*3-4*5";
            answer = [-34, -14, -10, -10, 10];
            result = solution.DiffWaysToCompute(expression);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer, true) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}

using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2961
{
    public class Test2961
    {
        public void Test()
        {
            Interface2961 solution = new Solution2961();
            int[][] variables; int target;
            IList<int> result, answer;
            int id = 0;

            // 1. 
            variables = [[2, 3, 3, 10], [3, 3, 3, 1], [6, 1, 1, 4]]; target = 2;
            answer = [0, 2];
            result = solution.GetGoodIndices(variables, target);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            variables = [[39, 3, 1000, 1000]]; target = 17;
            answer = [];
            result = solution.GetGoodIndices(variables, target);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}

using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3488
{
    public class Test3488
    {
        public void Test()
        {
            Interface3488 solution = new Solution3488_2();
            int[] nums, queries;
            IList<int> result, answer;
            int id = 0;

            // 1. 
            nums = [1, 3, 1, 4, 1, 3, 2]; queries = [0, 3, 5];
            answer = [2, -1, 3];
            result = solution.SolveQueries(nums, queries);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            nums = [1, 2, 3, 4]; queries = [0, 1, 2, 3];
            answer = [-1, -1, -1, -1];
            result = solution.SolveQueries(nums, queries);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 3. 
            nums = [14, 14, 4, 2, 19, 19, 14, 19, 14]; queries = [2, 4, 8, 6, 3];
            answer = [-1, 1, 1, 2, -1];
            result = solution.SolveQueries(nums, queries);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}

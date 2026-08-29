using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2948
{
    public class Test2948
    {
        public void Test()
        {
            Interface2948 solution = new Solution2948();
            int[] nums; int limit;
            int[] result, answer;
            int id = 0;

            // 1. 
            nums = [1, 5, 3, 9, 8]; limit = 2;
            answer = [1, 3, 5, 8, 9];
            result = solution.LexicographicallySmallestArray(nums, limit);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            nums = [1, 7, 6, 18, 2, 1]; limit = 3;
            answer = [1, 6, 7, 18, 1, 2];
            result = solution.LexicographicallySmallestArray(nums, limit);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 3. 
            nums = [1, 7, 28, 19, 10]; limit = 3;
            answer = [1, 7, 28, 19, 10];
            result = solution.LexicographicallySmallestArray(nums, limit);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}

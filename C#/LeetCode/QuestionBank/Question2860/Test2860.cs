using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2860
{
    public class Test2860
    {
        public void Test()
        {
            Interface2860 solution = new Solution2860();
            IList<int> nums;
            int result, answer;
            int id = 0;

            // 1. 
            nums = [1, 1];
            answer = 2;
            result = solution.CountWays(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = [6, 0, 3, 3, 6, 7, 2, 7];
            answer = 3;
            result = solution.CountWays(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

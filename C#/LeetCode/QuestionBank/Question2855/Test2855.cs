using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2855
{
    public class Test2855
    {
        public void Test()
        {
            Interface2855 solution = new Solution2855();
            IList<int> nums;
            int result, answer;
            int id = 0;

            // 1. 
            nums = new int[] { 3, 4, 5, 1, 2 };
            answer = 2;
            result = solution.MinimumRightShifts(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = new int[] { 1, 3, 5 };
            answer = 0;
            result = solution.MinimumRightShifts(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums = new int[] { 2, 1, 4 };
            answer = -1;
            result = solution.MinimumRightShifts(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

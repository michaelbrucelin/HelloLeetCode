using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3514
{
    public class Test3514
    {
        public void Test()
        {
            Interface3514 solution = new Solution3514_2();
            int[] nums;
            int result, answer;
            int id = 0;

            // 1. 
            nums = [1, 3];
            answer = 2;
            result = solution.UniqueXorTriplets(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = [6, 7, 8, 9];
            answer = 4;
            result = solution.UniqueXorTriplets(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

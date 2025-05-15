using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3337
{
    public class Test3337
    {
        public void Test()
        {
            Interface3337 solution = new Solution3337();
            string s; int t; IList<int> nums;
            int result, answer;
            int id = 0;

            // 1. 
            s = "abcyy"; t = 2; nums = [1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2];
            answer = 7;
            result = solution.LengthAfterTransformations(s, t, nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            s = "azbk"; t = 1; nums = [2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2];
            answer = 8;
            result = solution.LengthAfterTransformations(s, t, nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1998
{
    public class Test1998
    {
        public void Test()
        {
            Interface1998 solution = new Solution1998();
            int[] nums;
            bool result, answer;
            int id = 0;

            // 1. 
            nums = [7, 21, 3];
            answer = true;
            result = solution.GcdSort(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = [5, 2, 6, 2];
            answer = false;
            result = solution.GcdSort(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums = [10, 5, 9, 3, 15];
            answer = true;
            result = solution.GcdSort(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1388
{
    public class Test1388
    {
        public void Test()
        {
            Interface1388 solution = new Solution1388();
            int[] slices;
            int result, answer;
            int id = 0;

            // 1. 
            slices = new int[] { 1, 2, 3, 4, 5, 6 };
            answer = 10;
            result = solution.MaxSizeSlices(slices);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            slices = new int[] { 8, 9, 8, 6, 1, 1 };
            answer = 16;
            result = solution.MaxSizeSlices(slices);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            slices = new int[] { 3, 9, 4, 5, 3, 8, 1, 10, 3, 7, 2, 9, 10, 2, 6, 2, 9, 8, 7, 10, 7, 5, 1, 6, 5, 8, 9, 10, 6, 5, 7, 7, 2, 5, 3, 10, 4, 3, 4 };
            answer = 110;
            result = solution.MaxSizeSlices(slices);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

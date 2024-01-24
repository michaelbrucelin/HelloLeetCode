using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2865
{
    public class Test2865
    {
        public void Test()
        {
            Interface2865 solution = new Solution2865();
            IList<int> maxHeights;
            long result, answer;
            int id = 0;

            // 1. 
            maxHeights = new int[] { 5, 3, 4, 1, 1 };
            answer = 13;
            result = solution.MaximumSumOfHeights(maxHeights);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            maxHeights = new int[] { 6, 5, 3, 9, 2, 7 };
            answer = 22;
            result = solution.MaximumSumOfHeights(maxHeights);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            maxHeights = new int[] { 3, 2, 5, 5, 2, 3 };
            answer = 18;
            result = solution.MaximumSumOfHeights(maxHeights);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. // 溢出
            maxHeights = new int[] { 1000000000, 1000000000, 1000000000 };
            answer = 3000000000;
            result = solution.MaximumSumOfHeights(maxHeights);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

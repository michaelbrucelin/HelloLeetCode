using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3218
{
    public class Test3218
    {
        public void Test()
        {
            Interface3218 solution = new Solution3218_3();
            int m, n; int[] horizontalCut, verticalCut;
            int result, answer;
            int id = 0;

            // 1. 
            m = 3; n = 2; horizontalCut = [1, 3]; verticalCut = [5];
            answer = 13;
            result = solution.MinimumCost(m, n, horizontalCut, verticalCut);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            m = 2; n = 2; horizontalCut = [7]; verticalCut = [4];
            answer = 15;
            result = solution.MinimumCost(m, n, horizontalCut, verticalCut);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            m = 9; n = 8; horizontalCut = [7, 7, 4, 3, 1, 2, 3, 5]; verticalCut = [2, 3, 1, 1, 2, 2, 1];
            answer = 134;
            result = solution.MinimumCost(m, n, horizontalCut, verticalCut);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            m = 1; n = 7; horizontalCut = []; verticalCut = [2, 1, 2, 1, 2, 1];
            answer = 9;
            result = solution.MinimumCost(m, n, horizontalCut, verticalCut);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            m = 6; n = 3; horizontalCut = [2, 3, 2, 3, 1]; verticalCut = [1, 2];
            answer = 28;
            result = solution.MinimumCost(m, n, horizontalCut, verticalCut);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 6. 
            m = 3; n = 6; horizontalCut = [1, 2]; verticalCut = [2, 3, 2, 3, 1];
            answer = 28;
            result = solution.MinimumCost(m, n, horizontalCut, verticalCut);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

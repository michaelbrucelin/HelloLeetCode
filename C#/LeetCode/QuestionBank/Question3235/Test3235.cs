using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3235
{
    public class Test3235
    {
        public void Test()
        {
            Interface3235 solution = new Solution3235();
            int xCorner, yCorner; int[][] circles;
            bool result, answer;
            int id = 0;

            // 1. 
            xCorner = 3; yCorner = 4; circles = [[2, 1, 1]];
            answer = true;
            result = solution.CanReachCorner(xCorner, yCorner, circles);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            xCorner = 3; yCorner = 3; circles = [[1, 1, 2]];
            answer = false;
            result = solution.CanReachCorner(xCorner, yCorner, circles);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            xCorner = 3; yCorner = 3; circles = [[2, 1, 1], [1, 2, 1]];
            answer = false;
            result = solution.CanReachCorner(xCorner, yCorner, circles);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            xCorner = 4; yCorner = 4; circles = [[5, 5, 1]];
            answer = true;
            result = solution.CanReachCorner(xCorner, yCorner, circles);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. ./asssets/img/TestCase3235_05.png
            xCorner = 3; yCorner = 3; circles = [[2, 1000, 997], [1000, 2, 997]];
            answer = true;
            result = solution.CanReachCorner(xCorner, yCorner, circles);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 6. ./asssets/img/TestCase3235_06.png
            xCorner = 15; yCorner = 15; circles = [[1, 99, 85], [99, 1, 85]];
            answer = true;
            result = solution.CanReachCorner(xCorner, yCorner, circles);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 7. 
            xCorner = 5; yCorner = 6; circles = [[2, 1, 1], [4, 2, 1], [4, 1, 1], [4, 2, 1], [2, 4, 2], [2, 2, 1], [4, 3, 1]];
            answer = false;
            result = solution.CanReachCorner(xCorner, yCorner, circles);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 8. ./asssets/img/TestCase3235_08.png
            xCorner = 9; yCorner = 10; circles = [[7, 1, 1], [3, 7, 2], [5, 9, 1], [3, 8, 1], [5, 6, 1], [8, 9, 1], [2, 5, 2]];
            answer = false;
            result = solution.CanReachCorner(xCorner, yCorner, circles);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 9. ./asssets/img/TestCase3235_09.png
            xCorner = 500000000; yCorner = 500000000; circles = [[499980000, 699999999, 200000000], [500020000, 300000001, 200000000]];
            answer = true;
            result = solution.CanReachCorner(xCorner, yCorner, circles);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

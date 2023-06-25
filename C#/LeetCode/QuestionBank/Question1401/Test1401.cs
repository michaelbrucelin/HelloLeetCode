using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1401
{
    public class Test1401
    {
        public void Test()
        {
            Interface1401 solution = new Solution1401();
            int radius, xCenter, yCenter, x1, y1, x2, y2;
            bool result, answer;
            int id = 0;

            // 1. 
            radius = 1; xCenter = 0; yCenter = 0; x1 = 1; y1 = -1; x2 = 3; y2 = 1;
            answer = true;
            result = solution.CheckOverlap(radius, xCenter, yCenter, x1, y1, x2, y2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            radius = 1; xCenter = 1; yCenter = 1; x1 = 1; y1 = -3; x2 = 2; y2 = -1;
            answer = false;
            result = solution.CheckOverlap(radius, xCenter, yCenter, x1, y1, x2, y2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            radius = 1; xCenter = 0; yCenter = 0; x1 = -1; y1 = 0; x2 = 0; y2 = 1;
            answer = true;
            result = solution.CheckOverlap(radius, xCenter, yCenter, x1, y1, x2, y2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0514
{
    public class Test0514
    {
        public void Test()
        {
            Interface0514 solution = new Solution0514_3_2();
            string ring, key;
            int result, answer;
            int id = 0;

            // 1. 
            ring = "godding"; key = "gd";
            answer = 4;
            result = solution.FindRotateSteps(ring, key);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            ring = "godding"; key = "godding";
            answer = 13;
            result = solution.FindRotateSteps(ring, key);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            ring = "caotmcaataijjxi"; key = "oatjiioicitatajtijciocjcaaxaaatmctxamacaamjjx";
            answer = 137;
            result = solution.FindRotateSteps(ring, key);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

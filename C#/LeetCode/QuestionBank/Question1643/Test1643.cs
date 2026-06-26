using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1643
{
    public class Test1643
    {
        public void Test()
        {
            Interface1643 solution = new Solution1643();
            int[] destination; int k;
            string result, answer;
            int id = 0;

            // 1. 
            destination = [2, 3]; k = 1;
            answer = "HHHVV";
            result = solution.KthSmallestPath(destination, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            destination = [2, 3]; k = 2;
            answer = "HHVHV";
            result = solution.KthSmallestPath(destination, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            destination = [2, 3]; k = 3;
            answer = "HHVVH";
            result = solution.KthSmallestPath(destination, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

using LeetCode.QuestionBank.Question1240;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0703
{
    public class Test0703
    {
        public void Test()
        {
            Interface0703 solution;
            int k; int[] nums;
            int[] input, answer;
            int id = 0, _id;

            // 1. 
            id++; _id = 0;
            k = 3; nums = new int[] { 4, 5, 8, 2 };
            input = new int[] { 3, 5, 10, 9, 4 };
            answer = new int[] { 4, 5, 5, 8, 8 };
            solution = new KthLargest_2(k, nums);
            for (int i = 0, result; i < input.Length; i++)
            {
                result = solution.Add(input[i]);
                Console.WriteLine($"{id}.{++_id,2}: {(result == answer[i]) + ",",-6} result: {result}, answer: {answer[i]}");
            }

            // 2. 
            id++; _id = 0;
            k = 1; nums = new int[] { };
            input = new int[] { -3, -2, -4, 0, 4 };
            answer = new int[] { -3, -2, -2, 0, 4 };
            solution = new KthLargest_2(k, nums);
            for (int i = 0, result; i < input.Length; i++)
            {
                result = solution.Add(input[i]);
                Console.WriteLine($"{id}.{++_id,2}: {(result == answer[i]) + ",",-6} result: {result}, answer: {answer[i]}");
            }
        }
    }
}

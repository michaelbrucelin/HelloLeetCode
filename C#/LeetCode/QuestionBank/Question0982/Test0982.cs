using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0982
{
    public class Test0982
    {
        public void Test()
        {
            Interface0982 solution = new Solution0982();
            int[] nums;
            int result, answer;
            int id = 0;
            Stopwatch sw = new Stopwatch();

            // 1. 
            nums = new int[] { 2, 1, 3 }; answer = 12;
            sw.Restart(); result = solution.CountTriplets(nums); sw.Stop();
            Console.WriteLine($"{++id,2}: In {sw.Elapsed}, {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = new int[] { 0, 0, 0 }; answer = 27;
            sw.Restart(); result = solution.CountTriplets(nums); sw.Stop();
            Console.WriteLine($"{++id,2}: In {sw.Elapsed}, {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums = Enumerable.Range(0, 1000).ToArray(); answer = 274245307;
            sw.Restart(); result = solution.CountTriplets(nums); sw.Stop();
            Console.WriteLine($"{++id,2}: In {sw.Elapsed}, {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

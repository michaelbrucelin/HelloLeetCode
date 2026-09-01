using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0109
{
    public class Test0109
    {
        public void Test()
        {
            Interface0109 solution = new Solution0109();
            string[] deadends; string target;
            int result, answer;
            int id = 0;

            // 1. 
            deadends = ["0201", "0101", "0102", "1212", "2002"]; target = "0202";
            answer = 6;
            result = solution.OpenLock(deadends, target);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            deadends = ["8888"]; target = "0009";
            answer = 1;
            result = solution.OpenLock(deadends, target);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            deadends = ["8887", "8889", "8878", "8898", "8788", "8988", "7888", "9888"]; target = "8888";
            answer = -1;
            result = solution.OpenLock(deadends, target);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            deadends = ["0000"]; target = "8888";
            answer = -1;
            result = solution.OpenLock(deadends, target);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

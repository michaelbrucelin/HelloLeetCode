using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0955
{
    public class Test0955
    {
        public void Test()
        {
            Interface0955 solution = new Solution0955();
            string[] strs;
            int result, answer;
            int id = 0;

            // 1. 
            strs = ["ca", "bb", "ac"];
            answer = 1;
            result = solution.MinDeletionSize(strs);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            strs = ["xc", "yb", "za"];
            answer = 0;
            result = solution.MinDeletionSize(strs);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            strs = ["zyx", "wvu", "tsr"];
            answer = 3;
            result = solution.MinDeletionSize(strs);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            strs = ["xga", "xfb", "yfa"];
            answer = 1;
            result = solution.MinDeletionSize(strs);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            strs = ["vdy", "vei", "zvc", "zld"];
            answer = 2;
            result = solution.MinDeletionSize(strs);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

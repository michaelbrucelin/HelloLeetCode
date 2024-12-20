using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3138
{
    public class Test3138
    {
        public void Test()
        {
            Interface3138 solution = new Solution3138();
            string s;
            int result, answer;
            int id = 0;

            // 1. 
            s = "abba";
            answer = 2;
            result = solution.MinAnagramLength(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            s = "cdef";
            answer = 4;
            result = solution.MinAnagramLength(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

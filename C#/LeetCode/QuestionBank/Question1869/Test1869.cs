using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1869
{
    public class Test1869
    {
        public void Test()
        {
            Interface1869 solution = new Solution1869();
            string s;
            bool result, answer;
            int id = 0;

            // 1. 
            s = "1101";
            answer = true;
            result = solution.CheckZeroOnes(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            s = "111000";
            answer = false;
            result = solution.CheckZeroOnes(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            s = "110100010";
            answer = false;
            result = solution.CheckZeroOnes(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

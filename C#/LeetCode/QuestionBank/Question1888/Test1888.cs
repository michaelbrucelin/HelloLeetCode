using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1888
{
    public class Test1888
    {
        public void Test()
        {
            Interface1888 solution = new Solution1888_err();
            string s;
            int result, answer;
            int id = 0;

            // 1. 
            s = "111000";
            answer = 2;
            result = solution.MinFlips(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            s = "010";
            answer = 0;
            result = solution.MinFlips(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            s = "1110";
            answer = 1;
            result = solution.MinFlips(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            s = "10001100101000000";
            answer = 5;
            result = solution.MinFlips(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            s = "111000010100100110101011100001000001011100101";
            answer = 18;
            result = solution.MinFlips(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

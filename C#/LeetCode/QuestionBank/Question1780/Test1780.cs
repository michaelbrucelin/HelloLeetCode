using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1780
{
    public class Test1780
    {
        public void Test()
        {
            Interface1780 solution = new Solution1780_2();
            int n;
            bool result, answer;
            int id = 0;

            // 1. 
            n = 12; answer = true;
            result = solution.CheckPowersOfThree(n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            n = 91; answer = true;
            result = solution.CheckPowersOfThree(n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            n = 21; answer = false;
            result = solution.CheckPowersOfThree(n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            n = 123456; answer = false;
            result = solution.CheckPowersOfThree(n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            n = 7654321; answer = false;
            result = solution.CheckPowersOfThree(n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 6. 
            n = 1; answer = true;
            result = solution.CheckPowersOfThree(n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

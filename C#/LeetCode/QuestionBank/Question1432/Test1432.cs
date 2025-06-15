using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1432
{
    public class Test1432
    {
        public void Test()
        {
            Interface1432 solution = new Solution1432();
            int num;
            int result, answer;
            int id = 0;

            // 1. 
            num = 555;
            answer = 888;
            result = solution.MaxDiff(num);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            num = 9;
            answer = 8;
            result = solution.MaxDiff(num);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            num = 123456;
            answer = 820000;
            result = solution.MaxDiff(num);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            num = 10000;
            answer = 80000;
            result = solution.MaxDiff(num);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            num = 9288;
            answer = 8700;
            result = solution.MaxDiff(num);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 6. 
            num = 111;
            answer = 888;
            result = solution.MaxDiff(num);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 7. 
            num = 1101057;
            answer = 8808050;
            result = solution.MaxDiff(num);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

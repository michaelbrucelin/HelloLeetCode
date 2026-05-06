using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2827
{
    public class Test2827
    {
        public void Test()
        {
            Interface2827 solution = new Solution2827_err();
            int low, high, k;
            int result, answer;
            int id = 0;

            // 1. 
            low = 10; high = 20; k = 3;
            answer = 2;
            result = solution.NumberOfBeautifulIntegers(low, high, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            low = 1; high = 10; k = 1;
            answer = 1;
            result = solution.NumberOfBeautifulIntegers(low, high, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            low = 5; high = 5; k = 2;
            answer = 0;
            result = solution.NumberOfBeautifulIntegers(low, high, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

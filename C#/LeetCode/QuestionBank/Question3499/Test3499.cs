using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3499
{
    public class Test3499
    {
        public void Test()
        {
            Interface3499 solution = new Solution3499();
            string s;
            int result, answer;
            int id = 0;

            // 1. 
            s = "01";
            answer = 1;
            result = solution.MaxActiveSectionsAfterTrade(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            s = "0100";
            answer = 4;
            result = solution.MaxActiveSectionsAfterTrade(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            s = "1000100";
            answer = 7;
            result = solution.MaxActiveSectionsAfterTrade(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            s = "01010";
            answer = 4;
            result = solution.MaxActiveSectionsAfterTrade(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            s = "01101001";
            answer = 7;
            result = solution.MaxActiveSectionsAfterTrade(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

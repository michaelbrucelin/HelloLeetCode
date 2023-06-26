using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0917
{
    public class Test0917
    {
        public void Test()
        {
            Interface0917 solution = new Solution0917_2();
            string s;
            string result, answer;
            int id = 0;

            // 1. 
            s = "ab-cd";
            answer = "dc-ba";
            result = solution.ReverseOnlyLetters(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            s = "a-bC-dEf-ghIj";
            answer = "j-Ih-gfE-dCba";
            result = solution.ReverseOnlyLetters(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            s = "Test1ng-Leet=code-Q!";
            answer = "Qedo1ct-eeLg=ntse-T!";
            result = solution.ReverseOnlyLetters(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

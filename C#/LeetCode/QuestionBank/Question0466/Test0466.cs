using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0466
{
    public class Test0466
    {
        public void Test()
        {
            Interface0466 solution = new Solution0466_2_3();
            string s1; int n1; string s2; int n2;
            int result, answer;
            int id = 0;

            // 1. 
            s1 = "acb"; n1 = 4; s2 = "ab"; n2 = 2;
            answer = 2;
            result = solution.GetMaxRepetitions(s1, n1, s2, n2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            s1 = "acb"; n1 = 1; s2 = "acb"; n2 = 1;
            answer = 1;
            result = solution.GetMaxRepetitions(s1, n1, s2, n2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            s1 = "aaa"; n1 = 3; s2 = "aa"; n2 = 1;
            answer = 4;
            result = solution.GetMaxRepetitions(s1, n1, s2, n2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            s1 = "baba"; n1 = 11; s2 = "baab"; n2 = 1;
            answer = 7;
            result = solution.GetMaxRepetitions(s1, n1, s2, n2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            s1 = "lovelive"; n1 = 1; s2 = "lovelive"; n2 = 10;
            answer = 0;
            result = solution.GetMaxRepetitions(s1, n1, s2, n2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 6. 
            s1 = "bacaba"; n1 = 3; s2 = "abacab"; n2 = 1;
            answer = 2;
            result = solution.GetMaxRepetitions(s1, n1, s2, n2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 7. 
            s1 = "a"; n1 = 1; s2 = "b"; n2 = 1;
            answer = 0;
            result = solution.GetMaxRepetitions(s1, n1, s2, n2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 8. 
            s1 = "aabb"; n1 = 14; s2 = "bbbbbab"; n2 = 1;
            answer = 4;
            result = solution.GetMaxRepetitions(s1, n1, s2, n2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 9. 
            s1 = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"; n1 = 1000000;
            s2 = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"; n2 = 1000000;
            answer = 1;
            result = solution.GetMaxRepetitions(s1, n1, s2, n2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

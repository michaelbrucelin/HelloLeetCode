using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0205
{
    public class Test0205
    {
        public void Test()
        {
            Interface0205 solution = new Solution0205_2();
            string s, t;
            bool result, answer;
            int id = 0;

            // 1. 
            s = "egg"; t = "add"; answer = true;
            result = solution.IsIsomorphic(s, t);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            s = "foo"; t = "bar"; answer = false;
            result = solution.IsIsomorphic(s, t);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            s = "paper"; t = "title"; answer = true;
            result = solution.IsIsomorphic(s, t);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            s = "papert"; t = "titleq"; answer = true;
            result = solution.IsIsomorphic(s, t);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            s = "badc"; t = "baba"; answer = false;
            result = solution.IsIsomorphic(s, t);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

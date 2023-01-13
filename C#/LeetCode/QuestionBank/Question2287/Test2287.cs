using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2287
{
    public class Test2287
    {
        public void Test()
        {
            Interface2287 solution = new Solution2287();
            string s, target;
            int result, answer;
            int id = 0;

            // 1. 
            s = "ilovecodingonleetcode"; target = "code"; answer = 2;
            result = solution.RearrangeCharacters(s, target);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            s = "abcba"; target = "abc"; answer = 1;
            result = solution.RearrangeCharacters(s, target);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            s = "abbaccaddaeea"; target = "aaaaa"; answer = 1;
            result = solution.RearrangeCharacters(s, target);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            s = "rav"; target = "vr"; answer = 1;
            result = solution.RearrangeCharacters(s, target);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            s = "rav"; target = "z"; answer = 0;
            result = solution.RearrangeCharacters(s, target);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

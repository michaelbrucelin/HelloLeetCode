using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3992
{
    public class Test3992
    {
        public void Test()
        {
            Interface3992 solution = new Solution3992();
            string s; char x, y;
            string result, answer;
            int id = 0;

            // 1. 
            s = "aabc"; x = 'a'; y = 'c';
            answer = "cbaa";
            result = solution.RearrangeString(s, x, y);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            s = "dcab"; x = 'd'; y = 'b';
            answer = "cabd";
            result = solution.RearrangeString(s, x, y);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            s = "axe"; x = 'o'; y = 'x';
            answer = "axe";
            result = solution.RearrangeString(s, x, y);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            s = "iaevrcrlrvmitfvknc"; x = 't'; y = 'v';
            answer = "vvvtrrrnmlkiifecca";
            result = solution.RearrangeString(s, x, y);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

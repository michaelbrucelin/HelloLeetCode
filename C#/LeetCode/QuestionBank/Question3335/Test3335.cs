using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3335
{
    public class Test3335
    {
        public void Test()
        {
            Interface3335 solution = new Solution3335();
            string s; int t;
            int result, answer;
            int id = 0;

            // 1. 
            s = "abcyy"; t = 2;
            answer = 7;
            result = solution.LengthAfterTransformations(s, t);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            s = "azbk"; t = 1;
            answer = 5;
            result = solution.LengthAfterTransformations(s, t);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            s = "jqktcurgdvlibczdsvnsg"; t = 7517;
            answer = 79033769;
            result = solution.LengthAfterTransformations(s, t);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

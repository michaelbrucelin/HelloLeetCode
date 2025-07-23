using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1717
{
    public class Test1717
    {
        public void Test()
        {
            Interface1717 solution = new Solution1717_3();
            string s; int x, y;
            int result, answer;
            int id = 0;

            // 1. 
            s = "cdbcbbaaabab"; x = 4; y = 5;
            answer = 19;
            result = solution.MaximumGain(s, x, y);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            s = "aabbaaxybbaabb"; x = 5; y = 4;
            answer = 20;
            result = solution.MaximumGain(s, x, y);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            s = $"{new string('a', 50000)}{new string('b', 50000)}"; x = 123; y = 3495;
            answer = 6150000;
            result = solution.MaximumGain(s, x, y);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

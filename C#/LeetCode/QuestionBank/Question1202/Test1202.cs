using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1202
{
    public class Test1202
    {
        public void Test()
        {
            Interface1202 solution = new Solution1202();
            string s; IList<IList<int>> pairs;
            string result, answer;
            int id = 0;

            // 1. 
            s = "dcab"; pairs = [[0, 3], [1, 2]];
            answer = "bacd";
            result = solution.SmallestStringWithSwaps(s, pairs);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            s = "dcab"; pairs = [[0, 3], [1, 2], [0, 2]];
            answer = "abcd";
            result = solution.SmallestStringWithSwaps(s, pairs);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            s = "cba"; pairs = [[0, 1], [1, 2]];
            answer = "abc";
            result = solution.SmallestStringWithSwaps(s, pairs);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

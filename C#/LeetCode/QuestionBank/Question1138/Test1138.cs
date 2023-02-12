using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1138
{
    public class Test1138
    {
        public void Test()
        {
            Interface1138 solution = new Solution1138();
            string target;
            string result, answer;
            int id = 0;

            // 1. 
            target = "leet"; answer = "DDR!UURRR!!DDD!";
            result = solution.AlphabetBoardPath(target);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            target = "code"; answer = "RR!DDRR!UUL!R!";
            result = solution.AlphabetBoardPath(target);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            target = "zdz"; answer = "DDDDD!UUUUURRR!LLLDDDDD!";
            result = solution.AlphabetBoardPath(target);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

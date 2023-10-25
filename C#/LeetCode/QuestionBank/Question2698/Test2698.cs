using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2698
{
    public class Test2698
    {
        public void Test()
        {
            Interface2698 solution = new Solution2698_dial();
            int n;
            int result, answer;
            int id = 0;

            // 1. 
            n = 10;
            answer = 182;
            result = solution.PunishmentNumber(n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            n = 37;
            answer = 1478;
            result = solution.PunishmentNumber(n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            n = 1000;
            answer = 10804657;
            result = solution.PunishmentNumber(n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

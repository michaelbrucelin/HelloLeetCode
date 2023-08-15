using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2591
{
    public class Test2591
    {
        public void Test()
        {
            Interface2591 solution = new Solution2591();
            int money, children;
            int result, answer;
            int id = 0;

            // 1. 
            money = 20; children = 3;
            answer = 1;
            result = solution.DistMoney(money, children);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            money = 16; children = 2;
            answer = 2;
            result = solution.DistMoney(money, children);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            money = 17; children = 2;
            answer = 1;
            result = solution.DistMoney(money, children);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

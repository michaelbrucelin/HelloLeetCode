using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0592
{
    public class Test0592
    {
        public void Test()
        {
            Interface0592 solution = new Solution0592();
            string expression;
            string result, answer;
            int id = 0;

            // 1.
            expression = "-1/2+1/2";
            answer = "0/1";
            result = solution.FractionAddition(expression);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            expression = "-1/2+1/2+1/3";
            answer = "1/3";
            result = solution.FractionAddition(expression);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            expression = "1/3-1/2";
            answer = "-1/6";
            result = solution.FractionAddition(expression);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            expression = "5/3+1/3";
            answer = "2/1";
            result = solution.FractionAddition(expression);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview1626
{
    public class Test1626
    {
        public void Test()
        {
            Interface1626 solution = new Solution1626();
            string s;
            int result, answer;
            int id = 0;

            // 1. 
            s = "3+2*2";
            answer = 7;
            result = solution.Calculate(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            s = " 3/2 ";
            answer = 1;
            result = solution.Calculate(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            s = " 3+5 / 2 ";
            answer = 5;
            result = solution.Calculate(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            s = "1+1-1";
            answer = 1;
            result = solution.Calculate(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

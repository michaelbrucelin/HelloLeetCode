using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2337
{
    public class Test2337
    {
        public void Test()
        {
            Interface2337 solution = new Solution2337_2();
            string start, target;
            bool result, answer;
            int id = 0;

            // 1. 
            start = "_L__R__R_"; target = "L______RR";
            answer = true;
            result = solution.CanChange(start, target);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            start = "R_L_"; target = "__LR";
            answer = false;
            result = solution.CanChange(start, target);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            start = "_R"; target = "R_";
            answer = false;
            result = solution.CanChange(start, target);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            start = "_L__R__R_L"; target = "L______RR_";
            answer = false;
            result = solution.CanChange(start, target);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

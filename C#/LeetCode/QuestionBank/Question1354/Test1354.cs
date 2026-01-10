using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1354
{
    public class Test1354
    {
        public void Test()
        {
            Interface1354 solution = new Solution1354_err();
            int[] target;
            bool result, answer;
            int id = 0;

            // 1. 
            target = [9, 3, 5];
            answer = true;
            result = solution.IsPossible(target);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            target = [1, 1, 1, 2];
            answer = false;
            result = solution.IsPossible(target);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            target = [8, 5];
            answer = true;
            result = solution.IsPossible(target);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            target = [1, 1000000000];
            answer = true;
            result = solution.IsPossible(target);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            target = [2, 900000002];
            answer = false;
            result = solution.IsPossible(target);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 6. 
            target = [2];
            answer = false;
            result = solution.IsPossible(target);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 7. 
            target = [1, 1, 1, 1, 11, 16];
            answer = true;
            result = solution.IsPossible(target);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

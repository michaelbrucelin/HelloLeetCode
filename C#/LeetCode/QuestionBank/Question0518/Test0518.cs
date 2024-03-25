using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0518
{
    public class Test0518
    {
        public void Test()
        {
            Interface0518 solution = new Solution0518_3();
            int amount; int[] coins;
            int result, answer;
            int id = 0;

            // 1. 
            amount = 5; coins = new int[] { 1, 2, 5 };
            answer = 4;
            result = solution.Change(amount, coins);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            amount = 3; coins = new int[] { 2 };
            answer = 0;
            result = solution.Change(amount, coins);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            amount = 10; coins = new int[] { 10 };
            answer = 1;
            result = solution.Change(amount, coins);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            amount = 500; coins = new int[] { 1, 2, 5 };
            answer = 12701;
            result = solution.Change(amount, coins);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            amount = 1000; coins = new int[] { 1, 2, 5 };
            answer = 50401;
            result = solution.Change(amount, coins);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 6. 
            amount = 2000; coins = new int[] { 1, 2, 5 };
            answer = 200801;
            result = solution.Change(amount, coins);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 7. 
            amount = 3000; coins = new int[] { 1, 2, 5 };
            answer = 451201;
            result = solution.Change(amount, coins);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 8. 
            amount = 4000; coins = new int[] { 1, 2, 5 };
            answer = 801601;
            result = solution.Change(amount, coins);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 9. 
            amount = 5000; coins = new int[] { 1, 2, 5 };
            answer = 1252001;
            result = solution.Change(amount, coins);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

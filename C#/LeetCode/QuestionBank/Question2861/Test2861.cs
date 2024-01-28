using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2861
{
    public class Test2861
    {
        public void Test()
        {
            Interface2861 solution = new Solution2861();
            int n, k, budget; IList<IList<int>> composition; IList<int> stock, cost;
            int result, answer;
            int id = 0;

            // 1. 
            n = 3; k = 2; budget = 15; composition = new int[][] { [1, 1, 1], [1, 1, 10] }; stock = new int[] { 0, 0, 0 }; cost = new int[] { 1, 2, 3 };
            answer = 2;
            result = solution.MaxNumberOfAlloys(n, k, budget, composition, stock, cost);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            n = 3; k = 2; budget = 15; composition = new int[][] { [1, 1, 1], [1, 1, 10] }; stock = new int[] { 0, 0, 100 }; cost = new int[] { 1, 2, 3 };
            answer = 5;
            result = solution.MaxNumberOfAlloys(n, k, budget, composition, stock, cost);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            n = 2; k = 3; budget = 10; composition = new int[][] { [2, 1], [1, 2], [1, 1] }; stock = new int[] { 1, 1 }; cost = new int[] { 5, 5 };
            answer = 2;
            result = solution.MaxNumberOfAlloys(n, k, budget, composition, stock, cost);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

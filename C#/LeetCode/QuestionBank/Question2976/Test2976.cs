using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2976
{
    public class Test2976
    {
        public void Test()
        {
            Interface2976 solution = new Solution2976();
            string source, target; char[] original, changed; int[] cost;
            long result, answer;
            int id = 0;

            // 1. 
            source = "abcd"; target = "acbe"; original = ['a', 'b', 'c', 'c', 'e', 'd']; changed = ['b', 'c', 'b', 'e', 'b', 'e']; cost = [2, 5, 5, 1, 2, 20];
            answer = 28;
            result = solution.MinimumCost(source, target, original, changed, cost);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            source = "aaaa"; target = "bbbb"; original = ['a', 'c']; changed = ['c', 'b']; cost = [1, 2];
            answer = 12;
            result = solution.MinimumCost(source, target, original, changed, cost);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            source = "abcd"; target = "abce"; original = ['a']; changed = ['e']; cost = [10000];
            answer = -1;
            result = solution.MinimumCost(source, target, original, changed, cost);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

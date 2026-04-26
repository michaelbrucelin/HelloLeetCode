using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1559
{
    public class Test1559
    {
        public void Test()
        {
            Interface1559 solution = new Solution1559_off();
            char[][] grid;
            bool result, answer;
            int id = 0;

            // 1. 
            grid = [['a', 'a', 'a', 'a'], ['a', 'b', 'b', 'a'], ['a', 'b', 'b', 'a'], ['a', 'a', 'a', 'a']];
            answer = true;
            result = solution.ContainsCycle(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            grid = [['c', 'c', 'c', 'a'], ['c', 'd', 'c', 'c'], ['c', 'c', 'e', 'c'], ['f', 'c', 'c', 'c']];
            answer = true;
            result = solution.ContainsCycle(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            grid = [['a', 'b', 'b'], ['b', 'z', 'b'], ['b', 'b', 'a']];
            answer = false;
            result = solution.ContainsCycle(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            grid = [['d', 'd', 'a'], ['d', 'd', 'c'], ['d', 'c', 'c'], ['d', 'd', 'c'], ['d', 'a', 'b']];
            answer = true;
            result = solution.ContainsCycle(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

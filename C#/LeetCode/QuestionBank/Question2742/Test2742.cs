using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2742
{
    public class Test2742
    {
        public void Test()
        {
            Interface2742 solution = new Solution2742();
            int[] cost, time;
            int result, answer;
            int id = 0;

            // 1. 
            cost = [1, 2, 3, 2]; time = [1, 2, 3, 2];
            answer = 3;
            result = solution.PaintWalls(cost, time);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            cost = [2, 3, 4, 2]; time = [1, 1, 1, 1];
            answer = 4;
            result = solution.PaintWalls(cost, time);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

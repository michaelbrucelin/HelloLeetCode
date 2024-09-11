using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2555
{
    public class Test2555
    {
        public void Test()
        {
            Interface2555 solution = new Solution2555_2();
            int[] prizePositions; int k;
            int result, answer;
            int id = 0;

            // 1. 
            prizePositions = [1, 1, 2, 2, 3, 3, 5]; k = 2;
            answer = 7;
            result = solution.MaximizeWin(prizePositions, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            prizePositions = [1, 2, 3, 4]; k = 0;
            answer = 2;
            result = solution.MaximizeWin(prizePositions, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0699
{
    public class Test0699
    {
        public void Test()
        {
            Interface0699 solution = new Solution0699_err();
            int[][] positions;
            IList<int> result, answer;
            int id = 0;

            // 1. 
            positions = [[1, 2], [2, 3], [6, 1]];
            answer = [2, 5, 5];
            result = solution.FallingSquares(positions);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            positions = [[100, 100], [200, 100]];
            answer = [100, 100];
            result = solution.FallingSquares(positions);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}

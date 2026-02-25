using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0973
{
    public class Test0973
    {
        public void Test()
        {
            Interface0973 solution = new Solution0973();
            int[][] points; int k;
            int[][] result, answer;
            int id = 0;

            // 1. 
            points = [[1, 3], [-2, 2]]; k = 1;
            answer = [[-2, 2]];
            result = solution.KClosest(points, k);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer, true) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            points = [[3, 3], [5, -1], [-2, 4]]; k = 2;
            answer = [[3, 3], [-2, 4]];
            result = solution.KClosest(points, k);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer, true) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 3. 
            points = [[-2, 10], [-4, -8], [10, 7], [-4, -7]]; k = 3;
            answer = [[-4, -7], [-4, -8], [-2, 10]];
            result = solution.KClosest(points, k);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer, true) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}

using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview0802
{
    public class Test0802
    {
        public void Test()
        {
            Interface0802 solution = new Solution0802();
            int[][] obstacleGrid;
            IList<IList<int>> result, answer;
            int id = 0;

            // 1. 
            obstacleGrid = [[0, 0, 0], [0, 1, 0], [0, 0, 0]];
            answer = [[0, 0], [0, 1], [0, 2], [1, 2], [2, 2]];
            result = solution.PathWithObstacles(obstacleGrid);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            obstacleGrid = [[0, 1], [1, 0]];
            answer = [];
            result = solution.PathWithObstacles(obstacleGrid);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}

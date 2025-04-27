using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview0802
{
    public class Solution0802 : Interface0802
    {
        /// <summary>
        /// 回溯
        /// 
        /// 貌似网站有问题，无法提交
        /// </summary>
        /// <param name="obstacleGrid"></param>
        /// <returns></returns>
        public IList<IList<int>> PathWithObstacles(int[][] obstacleGrid)
        {
            List<IList<int>> result = new List<IList<int>>();
            int rcnt = obstacleGrid.Length, ccnt = obstacleGrid[0].Length;
            if (obstacleGrid[0][0] == 1 || obstacleGrid[rcnt - 1][ccnt - 1] == 1) return result;
            backtrack(0, 0);

            return result;

            void backtrack(int r, int c)
            {
                result.Add([r, c]);
                obstacleGrid[r][c] = 1;
                if (c + 1 < ccnt && obstacleGrid[r][c + 1] != 1) backtrack(r, c + 1);
                if (result.Count == rcnt + ccnt - 1) return;
                if (r + 1 < rcnt && obstacleGrid[r + 1][c] != 1) backtrack(r + 1, c);
                if (result.Count == rcnt + ccnt - 1) return;
                result.RemoveAt(result.Count - 1);
            }
        }
    }
}

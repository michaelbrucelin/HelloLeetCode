using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3417
{
    public class Solution3417 : Interface3417
    {
        /// <summary>
        /// 遍历
        /// 偶数行，从左向右，从第0列开始
        /// 奇数行，从右向左，从ccnt - 1 - (ccnt & 1)列开始
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public IList<int> ZigzagTraversal(int[][] grid)
        {
            List<int> result = new List<int>();
            int rcnt = grid.Length, ccnt = grid[0].Length;
            int[] cid = [0, ccnt - 1 - (ccnt & 1)];
            int[] cin = [2, -2];
            for (int r = 0, id = 0; r < rcnt; r++, id = 1 - id)
            {
                for (int c = cid[id]; c >= 0 && c < ccnt; c += cin[id])
                {
                    result.Add(grid[r][c]);
                }
            }

            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3809
{
    public class Solution3809 : Interface3809
    {
        /// <summary>
        /// 遍历
        /// </summary>
        /// <param name="towers"></param>
        /// <param name="center"></param>
        /// <param name="radius"></param>
        /// <returns></returns>
        public int[] BestTower(int[][] towers, int[] center, int radius)
        {
            int[] result = [int.MaxValue, int.MaxValue]; int quatily = int.MinValue;
            foreach (int[] tower in towers) if (Math.Abs(center[0] - tower[0]) + Math.Abs(center[1] - tower[1]) <= radius)
                {
                    if (tower[2] > quatily)
                    {
                        result = [tower[0], tower[1]]; quatily = tower[2];
                    }
                    else if (tower[2] == quatily)
                    {
                        if (tower[0] < result[0] || (tower[0] == result[0] && tower[1] < result[1])) result = [tower[0], tower[1]];
                    }
                }

            return result[0] == int.MaxValue ? [-1, -1] : result;
        }
    }
}

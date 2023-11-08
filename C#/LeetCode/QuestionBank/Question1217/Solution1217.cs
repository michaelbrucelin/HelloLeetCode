using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1217
{
    public class Solution1217 : Interface1217
    {
        /// <summary>
        /// 脑筋急转弯
        /// 最终可以0成本将所有筹码移动到相邻的位置（奇数位置偶数位置各一组），取两组的较小值即可
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public int MinCostToMoveChips(int[] position)
        {
            int[] temp = new int[2];
            for (int i = 0; i < position.Length; i++) temp[(position[i] & 1)]++;

            return Math.Min(temp[0], temp[1]);
        }
    }
}

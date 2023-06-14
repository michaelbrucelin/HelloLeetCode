using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1375
{
    public class Solution1375_3 : Interface1375
    {
        /// <summary>
        /// 区间最大值
        /// 逻辑与Solution1375一样，当一个长度为n序列是1-n的排列时，其最大值就是n，所以不需要使用哈希表记录细节，只需要记录其最大值即可
        /// </summary>
        /// <param name="flips"></param>
        /// <returns></returns>
        public int NumTimesAllBlue(int[] flips)
        {
            int result = 0, max = -1;
            for (int i = 0; i < flips.Length; i++)
            {
                if ((max = Math.Max(max, flips[i])) == i + 1) result++;
            }

            return result;
        }
    }
}

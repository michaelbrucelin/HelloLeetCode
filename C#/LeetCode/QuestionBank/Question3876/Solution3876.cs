using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3876
{
    public class Solution3876 : Interface3876
    {
        /// <summary>
        /// 分类讨论
        /// 1. 目标全偶
        ///     如果nums1中全部是偶数，true
        ///     如果nums1中存在奇数，那么只有减去另外一个奇数才会变为偶数，那另外一个奇数怎么办，false
        /// 2. 目标全奇
        ///     如果nums1中全部是奇数，true
        ///     如果nums1中存在偶数，那么只有减去另外一个奇数才会变为奇数，且被减去的奇数要小于偶数
        /// </summary>
        /// <param name="nums1"></param>
        /// <returns></returns>
        public bool UniformArray(int[] nums1)
        {
            int len = nums1.Length;
            int[] mins = [int.MaxValue, int.MaxValue], cnts = [0, 0];
            for (int i = 0, num, idx; i < len; i++)
            {
                num = nums1[i];
                idx = num & 1;
                mins[idx] = Math.Min(mins[idx], num);
                cnts[idx]++;
            }

            if (cnts[0] == 0 || cnts[1] == 0) return true;
            return mins[0] - mins[1] >= 0;
        }
    }
}

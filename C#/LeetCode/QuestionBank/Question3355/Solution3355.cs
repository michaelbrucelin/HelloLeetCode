using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3355
{
    public class Solution3355 : Interface3355
    {
        /// <summary>
        /// 贪心 + 差分数组
        /// 对于每个query[i]，都意味着[l..r]之间的元素可以减去1，也可以不动
        /// 所以可以计算每个位置被多少个query[i]覆盖，覆盖的数量大于等于自身的值即可
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="queries"></param>
        /// <returns></returns>
        public bool IsZeroArray(int[] nums, int[][] queries)
        {
            int len = nums.Length;
            int[] diff = new int[len + 1];
            foreach (int[] query in queries)
            {
                diff[query[0]]++; diff[query[1] + 1]--;
            }
            for (int i = 1; i < len; i++) diff[i] += diff[i - 1];

            for (int i = 0; i < len; i++) if (diff[i] < nums[i]) return false;
            return true;
        }
    }
}

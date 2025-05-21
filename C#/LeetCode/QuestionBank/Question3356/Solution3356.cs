using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3356
{
    public class Solution3356 : Interface3356
    {
        /// <summary>
        /// 贪心 + 差分数组 + 二分查找
        /// 逻辑同Solution3355，添加二分法找最小的k
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="queries"></param>
        /// <returns></returns>
        public int MinZeroArray(int[] nums, int[][] queries)
        {
            if (nums.All(x => x == 0)) return 0;

            int result = -1, len = nums.Length, pl = 0, pr = queries.Length - 1, mid;
            int[] diff = new int[len + 1];
            while (pl <= pr)
            {
                mid = pl + ((pr - pl) >> 1);
                if (check(mid))
                {
                    result = mid; pr = mid - 1;
                }
                else
                {
                    pl = mid + 1;
                }
            }

            return result != -1 ? result + 1 : -1;

            bool check(int k)
            {
                Array.Fill(diff, 0);
                for (int i = 0; i <= k; i++)
                {
                    diff[queries[i][0]] += queries[i][2]; diff[queries[i][1] + 1] -= queries[i][2];
                }
                for (int i = 1; i < len; i++) diff[i] += diff[i - 1];

                for (int i = 0; i < len; i++) if (diff[i] < nums[i]) return false;
                return true;
            }
        }
    }
}

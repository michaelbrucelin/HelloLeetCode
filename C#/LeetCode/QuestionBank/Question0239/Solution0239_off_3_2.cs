using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0239
{
    public class Solution0239_off_3_2 : Interface0239
    {
        /// <summary>
        /// 与Solution0239_off_3逻辑一样，只是将数组的数组改为了3维数组，没有实际意义，写着玩的
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[] MaxSlidingWindow(int[] nums, int k)
        {
            if (k == 1) return nums;
            if (k == nums.Length) return [nums.Max()];

            int cnt = (int)Math.Ceiling(((float)nums.Length) / k);
            int[,,] maxs = new int[cnt, 2, k];  // maxs[,0,] prefix, maxs[,1,] suffix

            int id, len = nums.Length;
            for (int i = 0, j; i < cnt; i++)
            {
                maxs[i, 0, 0] = nums[id = k * i];
                for (j = 1; j < k && ++id < len; j++) maxs[i, 0, j] = Math.Max(maxs[i, 0, j - 1], nums[id]);

                if ((id = k * (i + 1) - 1) < len) { j = k - 1; } else { id = len - 1; j = (len % k) - 1; }
                maxs[i, 1, j] = nums[id];
                for (--j; j >= 0; j--) maxs[i, 1, j] = Math.Max(maxs[i, 1, j + 1], nums[--id]);
            }

            int[] result = new int[len - k + 1];
            for (int i = 0, j; i < result.Length; i++)  // result[i] -> Max(nums[i..(i+k-1)])
            {
                j = i + k - 1;
                result[i] = Math.Max(maxs[i / k, 1, i % k], maxs[j / k, 0, j % k]);
            }

            return result;
        }
    }
}

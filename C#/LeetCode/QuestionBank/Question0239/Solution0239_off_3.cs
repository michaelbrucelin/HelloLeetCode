using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0239
{
    public class Solution0239_off_3 : Interface0239
    {
        /// <summary>
        /// 官解的第三种解法，很新颖，很“机械”，很喜欢这种思路，写一下试试
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[] MaxSlidingWindow(int[] nums, int k)
        {
            if (k == 1) return nums;
            if (k == nums.Length) return [nums.Max()];

            int cnt = (int)Math.Ceiling(((float)nums.Length) / k);
            int[][] prefix = new int[cnt][], suffix = new int[cnt][];
            for (int i = 0; i < cnt; i++)
            {
                prefix[i] = new int[k]; suffix[i] = new int[k];
            }

            int id, len = nums.Length;
            for (int i = 0; i < cnt - 1; i++)
            {
                prefix[i][0] = nums[id = k * i];
                for (int j = 1; j < k; j++) prefix[i][j] = Math.Max(prefix[i][j - 1], nums[++id]);
                suffix[i][k - 1] = nums[id = k * (i + 1) - 1];
                for (int j = k - 2; j >= 0; j--) suffix[i][j] = Math.Max(suffix[i][j + 1], nums[--id]);
            }
            prefix[cnt - 1][0] = nums[id = k * (cnt - 1)];
            for (int j = 1; ++id < len; j++) prefix[cnt - 1][j] = Math.Max(prefix[cnt - 1][j - 1], nums[id]);
            suffix[cnt - 1][(len % k) != 0 ? (len % k) - 1 : k - 1] = nums[id = len - 1];
            for (int j = (len % k) != 0 ? (len % k) - 2 : k - 2; j >= 0; j--) suffix[cnt - 1][j] = Math.Max(suffix[cnt - 1][j + 1], nums[--id]);

            int[] result = new int[len - k + 1];
            for (int i = 0, j; i < result.Length; i++)  // result[i] -> Max(nums[i..(i+k-1)])
            {
                j = i + k - 1;
                result[i] = Math.Max(suffix[i / k][i % k], prefix[j / k][j % k]);
            }

            return result;
        }

        /// <summary>
        /// 与MaxSlidingWindow()逻辑一样，只是将最后一组预处理合并到了循环种去操作
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[] MaxSlidingWindow2(int[] nums, int k)
        {
            if (k == 1) return nums;
            if (k == nums.Length) return [nums.Max()];

            int cnt = (int)Math.Ceiling(((float)nums.Length) / k);
            int[][] prefix = new int[cnt][], suffix = new int[cnt][];
            for (int i = 0; i < cnt; i++)
            {
                prefix[i] = new int[k]; suffix[i] = new int[k];
            }

            int id, len = nums.Length;
            for (int i = 0, j; i < cnt; i++)
            {
                prefix[i][0] = nums[id = k * i];
                for (j = 1; j < k && ++id < len; j++) prefix[i][j] = Math.Max(prefix[i][j - 1], nums[id]);

                if ((id = k * (i + 1) - 1) < len) { j = k - 1; } else { id = len - 1; j = (len % k) - 1; }
                suffix[i][j] = nums[id];
                for (--j; j >= 0; j--) suffix[i][j] = Math.Max(suffix[i][j + 1], nums[--id]);
            }

            int[] result = new int[len - k + 1];
            for (int i = 0, j; i < result.Length; i++)  // result[i] -> Max(nums[i..(i+k-1)])
            {
                j = i + k - 1;
                result[i] = Math.Max(suffix[i / k][i % k], prefix[j / k][j % k]);
            }

            return result;
        }
    }
}

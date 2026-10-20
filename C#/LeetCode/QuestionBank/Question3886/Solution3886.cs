using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3886
{
    public class Solution3886 : Interface3886
    {
        /// <summary>
        /// 暴力查找
        /// 1. 按照k分组，任意一组的分界位置，左侧的最大值一定小于等于右侧的最小值
        ///     可以预处理除前缀最大值与后缀最小值数组解决
        /// 2. 每一组必须由1段或2段递增子数组组成
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int SortableIntegers(int[] nums)
        {
            int result = 0, limit = (int)Math.Sqrt(nums.Length), len = nums.Length;
            bool asc = true;
            for (int i = 1; i < len; i++) if (nums[i] < nums[i - 1]) { asc = false; break; }
            if (asc)
            {
                for (int i = 1, j; i <= limit; i++) if (len % i == 0)
                    {
                        if ((j = len / i) != i) result += i + j; else result += i;
                    }
                return result;
            }

            int[] maxs = new int[len], mins = new int[len];
            maxs[0] = nums[0];
            for (int i = 1; i < len; i++) maxs[i] = Math.Max(maxs[i - 1], nums[i]);
            mins[len - 1] = nums[len - 1];
            for (int i = len - 2; i >= 0; i--) mins[i] = Math.Min(mins[i + 1], nums[i]);
            for (int i = 1, j; i <= limit; i++) if (len % i == 0)
                {
                    if (check(i)) result += i;
                    if ((j = len / i) != i && check(j)) result += j;
                }

            return result;

            bool check(int k)
            {
                int x = 0;
                while ((x += k) < len) if (maxs[x - 1] > mins[x]) return false;
                for (int l = 0, r = k, t = 1; r <= len; l += k, r += k, t = 1)
                {
                    for (int i = l + 1; i < r; i++) if (nums[i] < nums[i - 1])
                        {
                            if (++t > 2) return false;
                        }
                    if (t == 2 && nums[r - 1] > nums[l]) return false;
                }
                return true;
            }
        }
    }
}

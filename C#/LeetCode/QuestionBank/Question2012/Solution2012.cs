using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2012
{
    public class Solution2012 : Interface2012
    {
        /// <summary>
        /// 类前缀和
        /// 预处理，类似于前缀和和后缀和的思想，预处理出前n项和后n项的最小值
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int SumOfBeauties(int[] nums)
        {
            int result = 0, len = nums.Length;
            int[] pres = new int[len], sufs = new int[len];
            pres[0] = nums[0];
            for (int i = 1; i < len; i++) pres[i] = Math.Max(pres[i - 1], nums[i]);
            sufs[^1] = nums[^1];
            for (int i = len - 2; i >= 0; i--) sufs[i] = Math.Min(sufs[i + 1], nums[i]);

            for (int i = 1; i <= len - 2; i++)
            {
                if (nums[i] > pres[i - 1] && nums[i] < sufs[i + 1]) result += 2;
                else if (nums[i] > nums[i - 1] && nums[i] < nums[i + 1]) result += 1;
            }

            return result;
        }

        /// <summary>
        /// 与SumOfBeauties()逻辑一样，“后缀和”不需要预处理，直接遍历即可，这样可以减少一次循环且节省一点内存
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int SumOfBeauties2(int[] nums)
        {
            int result = 0, suf = nums[^1], len = nums.Length;
            int[] pres = new int[len];
            pres[0] = nums[0];
            for (int i = 1; i < len; i++) pres[i] = Math.Max(pres[i - 1], nums[i]);

            for (int i = len - 2; i > 0; i--)
            {
                suf = Math.Min(suf, nums[i + 1]);
                if (nums[i] > pres[i - 1] && nums[i] < suf) result += 2;
                else if (nums[i] > nums[i - 1] && nums[i] < nums[i + 1]) result += 1;
            }

            return result;
        }
    }
}

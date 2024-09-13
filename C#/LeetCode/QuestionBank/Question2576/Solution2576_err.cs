using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2576
{
    public class Solution2576_err : Interface2576
    {
        /// <summary>
        /// 排序 + 贪心 + 双指针
        /// 这样贪心是错误的：2, 4, 5, 9 正序贪心是错的
        ///                   2, 3, 4, 8 倒序贪心是错的
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaxNumOfMarkedIndices(int[] nums)
        {
            Array.Sort(nums);
            int result = 0, p1 = 0, p2 = 1, len = nums.Length;
            bool[] mask = new bool[len];
            while (p1 < len && p2 < len)
            {
                while (p1 < len && mask[p1]) p1++;
                p2 = Math.Max(p2, p1 + 1);
                while (p2 < len)
                {
                    if (!mask[p2] && nums[p2] >= (nums[p1] << 1))
                    {
                        result += 2; mask[p1++] = mask[p2++] = true;
                        break;
                    }
                    else
                    {
                        p2++;
                    }
                }
            }

            return result;
        }
    }
}

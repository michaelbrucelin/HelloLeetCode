using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1909
{
    public class Solution1909 : Interface1909
    {
        /// <summary>
        /// 分析
        /// 只有一次移除元素的机会，如果出现两个相邻元素非严格递增，二者必删除其中一个
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public bool CanBeIncreasing(int[] nums)
        {
            bool flag = false;
            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i] >= nums[i + 1])
                {
                    if (flag) return false; else flag = true;
                    if (i == 0) continue;                          // 删除第一个元素
                    if (i == nums.Length - 2) return true;         // 删除最后一个元素
                    if (nums[i - 1] < nums[i + 1]) continue;       // 删除二者中前者
                    if (nums[i] < nums[i + 2]) { i++; continue; }  // 删除二者中后者
                    return false;
                }
            }

            return true;
        }
    }
}

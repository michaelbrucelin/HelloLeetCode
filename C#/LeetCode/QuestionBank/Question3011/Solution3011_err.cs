using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3011
{
    public class Solution3011_err : Interface3011
    {
        /// <summary>
        /// 排序
        /// 
        /// 题目理解错了，题目要求只能交换相邻元素，此揭发忽略了这一点
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public bool CanSortArray(int[] nums)
        {
            int[] _nums = nums.ToArray();
            Array.Sort(_nums);
            for (int i = 0; i < nums.Length; i++) if (!CanSort(nums[i], _nums[i])) return false;

            return true;

            bool CanSort(int num1, int num2)
            {
                while (num1 > 0 || num2 > 0)
                {
                    if (num1 == 0 || num2 == 0) return false;
                    num1 &= num1 - 1;
                    num2 &= num2 - 1;
                }
                return true;
            }
        }
    }
}

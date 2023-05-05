using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1991
{
    public class Solution1991 : Interface1991
    {
        /// <summary>
        /// 暴力解
        /// 题目的数量级可以暴力解的，写着玩玩，试试切片
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindMiddleIndex(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
                if (nums[0..i].Sum() == nums[(i + 1)..].Sum()) return i;
            return -1;
        }
    }
}

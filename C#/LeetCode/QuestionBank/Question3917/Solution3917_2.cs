using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3917
{
    public class Solution3917_2 : Interface3917
    {
        /// <summary>
        /// 倒序遍历
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] CountOppositeParity(int[] nums)
        {
            int len = nums.Length;
            int[] result = new int[len], cnts = new int[2];
            for (int i = len - 1, idx; i >= 0; i--)
            {
                idx = nums[i] & 1;
                result[i] = cnts[1 - idx];
                cnts[idx]++;
            }

            return result;
        }
    }
}

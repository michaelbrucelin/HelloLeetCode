using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3190
{
    public class Solution3190 : Interface3190
    {
        /// <summary>
        /// 遍历
        /// 一个数字要么可以被3整除，要么距离最近的能被3整除的相距为1
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MinimumOperations(int[] nums)
        {
            int result = 0;
            for (int i = 0; i < nums.Length; i++) if (nums[i] % 3 != 0) result++;

            return result;
        }
    }
}

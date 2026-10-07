using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0553
{
    public class Solution0553 : Interface0553
    {
        /// <summary>
        /// DP
        /// 从后向前遍历，记录每个后缀数组的极值及其对应的字符串表达式
        /// 本质上仍然是暴力求解
        /// 
        /// 没写完，不写了
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public string OptimalDivision(int[] nums)
        {
            int len = nums.Length;
            double[,] dpd = new double[len, 2];  // 1 极大值 2 极小值
            string[,] dps = new string[len, 2];
            dpd[len - 1, 0] = dpd[len - 1, 1] = nums[len - 1];
            dpd[len - 2, 0] = dpd[len - 2, 1] = 1D * nums[len - 2] / nums[len - 1];
            dps[len - 1, 0] = dps[len - 1, 1] = $"{nums[len - 1]}";
            dps[len - 2, 0] = dps[len - 2, 1] = $"{nums[len - 2]}/{nums[len - 1]}";
            for (int i = len - 3; i >= 0; i--)
            {

            }

            return dps[0, 0];
        }
    }
}

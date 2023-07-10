using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1893
{
    public class Solution1893 : Interface1893
    {
        /// <summary>
        /// 暴力枚举
        /// </summary>
        /// <param name="ranges"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public bool IsCovered(int[][] ranges, int left, int right)
        {
            bool flag;
            for (int num = left; num <= right; num++)
            {
                flag = false;
                for (int i = 0; i < ranges.Length; i++)
                {
                    if (ranges[i][0] <= num && num <= ranges[i][1]) { flag = true; break; }
                }
                if (!flag) return false;
            }

            return true;
        }
    }
}

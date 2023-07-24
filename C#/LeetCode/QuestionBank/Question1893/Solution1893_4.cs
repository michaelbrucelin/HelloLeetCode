using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1893
{
    public class Solution1893_4 : Interface1893
    {
        /// <summary>
        /// 差分数组
        /// </summary>
        /// <param name="ranges"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public bool IsCovered(int[][] ranges, int left, int right)
        {
            int len = right - left + 1;
            int[] diff = new int[len];
            for (int i = 0; i < ranges.Length; i++)
            {
                if (ranges[i][0] < left)
                {
                    if (ranges[i][1] >= left) diff[0]++;
                }
                else if (ranges[i][0] < right + 1)
                {
                    diff[ranges[i][0] - left]++;
                }
                if (ranges[i][1] >= left && ranges[i][1] < right) diff[ranges[i][1] - left + 1]--;
            }

            if (diff[0] == 0) return false;
            for (int i = 1; i < len; i++)
            {
                diff[i] += diff[i - 1];
                if (diff[i] <= 0) return false;
            }
            return true;
        }
    }
}

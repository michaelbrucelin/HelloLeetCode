using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0100
{
    public class Solution0100 : Interface0100
    {
        /// <summary>
        /// DP
        /// 每一层从后向前dp，这样空间就压缩成三角形的行高了（进阶要求）
        /// </summary>
        /// <param name="triangle"></param>
        /// <returns></returns>
        public int MinimumTotal(IList<IList<int>> triangle)
        {
            if (triangle.Count == 1) return triangle[0][0];

            int n = triangle.Count;
            int[] buffer = new int[n];
            buffer[0] = triangle[0][0];
            for (int i = 1; i < n; i++)
            {
                buffer[i] = buffer[i - 1] + triangle[i][i];
                for (int j = i - 1; j > 0; j--) buffer[j] = Math.Min(buffer[j - 1], buffer[j]) + triangle[i][j];
                buffer[0] += triangle[i][0];
            }

            int result = buffer[0];
            for (int i = 1; i < n; i++) result = Math.Min(result, buffer[i]);
            return result;
        }
    }
}

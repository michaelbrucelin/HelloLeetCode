using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0239
{
    public class Solution0239_3 : Interface0239
    {
        /// <summary>
        /// 稀疏表
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[] MaxSlidingWindow(int[] nums, int k)
        {
            if (k == 1) return nums;
            if (k == nums.Length) return [nums.Max()];

            int len = nums.Length;
            int[] result = new int[len - k + 1];
            List<int[]> st = [nums];
            int span = 1;
            while (span < ((k + 1) >> 1))
            {
                span <<= 1;
                st.Add(new int[len - span + 1]);
                for (int i = 0, j = span >> 1; i < st[^1].Length; i++, j++) st[^1][i] = Math.Max(st[^2][i], st[^2][j]);
            }

            len = result.Length;
            for (int i = 0; i < len; i++) result[i] = Math.Max(st[^1][i], st[^1][i + k - span]);

            return result;
        }
    }
}

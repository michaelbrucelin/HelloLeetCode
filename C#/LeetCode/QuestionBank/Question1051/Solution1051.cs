using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1051
{
    public class Solution1051 : Interface1051
    {
        /// <summary>
        /// 排序比较
        /// </summary>
        /// <param name="heights"></param>
        /// <returns></returns>
        public int HeightChecker(int[] heights)
        {
            int len = heights.Length;
            int[] copy = new int[len];
            Array.Copy(heights, copy, len);
            Array.Sort(copy);

            int result = 0;
            for (int i = 0; i < len; i++) if (heights[i] != copy[i]) result++;

            return result;
        }

        /// <summary>
        /// 计数排序
        /// </summary>
        /// <param name="heights"></param>
        /// <returns></returns>
        public int HeightChecker2(int[] heights)
        {
            int len = heights.Length;
            int[] cnt = new int[101];
            for (int i = 0; i < len; i++) cnt[heights[i]]++;
            int[] copy = new int[len];
            for (int i = 1, id = 0; i < 101; i++) for (int j = 0; j < cnt[i]; j++)
                {
                    copy[id++] = i;
                }

            int result = 0;
            for (int i = 0; i < len; i++) if (heights[i] != copy[i]) result++;

            return result;
        }
    }
}

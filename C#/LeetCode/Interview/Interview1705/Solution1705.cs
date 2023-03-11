using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview1705
{
    public class Solution1705 : Interface1705
    {
        /// <summary>
        /// 前缀和 + 暴力查找
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public string[] FindLongestSubarray(string[] array)
        {
            int len = array.Length;
            int[,] pre = new int[2, len + 1];  // 1维：数字；2维：字母
            for (int i = 0; i < len; i++)
            {
                if (char.IsDigit(array[i][0]))
                {
                    pre[0, i + 1] = pre[0, i] + 1; pre[1, i + 1] = pre[1, i];
                }
                else
                {
                    pre[0, i + 1] = pre[0, i]; pre[1, i + 1] = pre[1, i] + 1;
                }
            }

            int window = len - (len & 1);  // 子数组长度一定是偶数
            while (window > 0)
            {
                for (int i = 0; i <= len - window; i++)
                {
                    if (pre[0, i + window] - pre[0, i] == pre[1, i + window] - pre[1, i])
                        return array[i..(i + window)];
                }
                window -= 2;
            }

            return new string[0];
        }

        /// <summary>
        /// 与FindLongestSubarray()逻辑一样，但是前缀和只统计数字，不统计字母
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public string[] FindLongestSubarray2(string[] array)
        {
            int len = array.Length;
            int[] pre = new int[len + 1];
            for (int i = 0; i < len; i++)
                pre[i + 1] = pre[i] + (char.IsDigit(array[i][0]) ? 1 : 0);

            int window = len - (len & 1); int half = window >> 1;  // 子数组长度一定是偶数
            while (window > 0)
            {
                for (int i = 0; i <= len - window; i++)
                {
                    if (pre[i + window] - pre[i] == half)
                        return array[i..(i + window)];
                }
                window -= 2; half--;
            }

            return new string[0];
        }
    }
}

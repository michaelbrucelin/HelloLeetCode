using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview1705
{
    public class Solution1705_2 : Interface1705
    {
        /// <summary>
        /// 与Solution1705本质上一样
        /// 但是前缀和记录的既不是数字的数量，也不是字母的数量，而是数字数量与字母数量的差
        /// 所以如果两个位置的差相等，那么这两个位置之间的“切片”就是一个结果
        /// 如果只是以前缀和数组的形式做预处理，预处理结束后依然需要暴力查找，没有本质上的意义
        /// 这里预处理的数据以哈希表的形式记录，key就是差值，value是这个差值的第一个索引
        /// 这样从前向后遍历，只要再遇到相同的差值，就是一组合法的结果，最后找出最长的就可以了
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public string[] FindLongestSubarray(string[] array)
        {
            int left = 0, right = 0;
            Dictionary<int, int> buffer = new Dictionary<int, int>() { { 0, -1 } };
            int digit = 0, alpha = 0;
            for (int i = 0, key; i < array.Length; i++)
            {
                if (char.IsDigit(array[i][0])) digit++; else alpha++;
                key = digit - alpha;
                if (!buffer.ContainsKey(key)) buffer.Add(key, i);
                else
                {
                    // 如果子数组长度相等，索引小的一定先被记录
                    if (i - buffer[key] > right - left) (left, right) = (buffer[key], i);
                }
            }

            return right == 0 ? new string[0] : array[(left + 1)..(right + 1)];
        }
    }
}

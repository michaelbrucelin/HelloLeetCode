﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1224
{
    public class Solution1224_2 : Interface1224
    {
        /// <summary>
        /// 从前向后逐位分析，使用两个字典做辅助
        ///     1. Dictionary<值, 频率>
        ///     2. Dictionary<频率, 值的数量>，判断当前是否符合结果
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaxEqualFreq(int[] nums)
        {
            int result = 0;

            Dictionary<int, int> buffer1 = new Dictionary<int, int>();  // Dictionary<值, 频率>
            Dictionary<int, int> buffer2 = new Dictionary<int, int>();  // Dictionary<频率, 值的数量>
            for (int i = 0; i < nums.Length; i++)
            {
                if (buffer1.ContainsKey(nums[i]))
                {
                    int frequency = ++buffer1[nums[i]];

                    buffer2[frequency - 1]--;
                    if (buffer2[frequency - 1] == 0) buffer2.Remove(frequency - 1);

                    if (buffer2.ContainsKey(frequency)) buffer2[frequency]++;
                    else buffer2.Add(frequency, 1);
                }
                else
                {
                    buffer1.Add(nums[i], 1);

                    if (buffer2.ContainsKey(1)) buffer2[1]++;
                    else buffer2.Add(1, 1);
                }

                // 分析结果
                if (buffer2.Count == 1)
                {
                    if (buffer2.First().Key == 1 || buffer2.First().Value == 1)
                        result = i + 1;
                }
                else if (buffer2.Count == 2)
                {
                    int key1 = buffer2.OrderBy(kv => kv.Key).First().Key;
                    int key2 = buffer2.OrderBy(kv => kv.Key).Last().Key;
                    if (key1 == 1 && buffer2[key1] == 1)
                        result = i + 1;
                    else if (key2 - key1 == 1 && buffer2[key2] == 1)
                        result = i + 1;
                }
            }

            return result;
        }
    }
}

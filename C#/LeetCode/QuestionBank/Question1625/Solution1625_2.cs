using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1625
{
    public class Solution1625_2 : Interface1625
    {
        /// <summary>
        /// 暴力枚举
        /// 1. b为奇数，每一位都可以改变，b为偶数，奇数位可以改变
        /// 2. 无论a为几，最多有10种改变的可能
        /// </summary>
        /// <param name="s"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public string FindLexSmallestString(string s, int a, int b)
        {
            int[][] amap = [[], [0, 1, 2, 3, 4, 5, 6, 7, 8, 9], [0, 2, 4, 6, 8], [0, 3, 6, 9, 2, 5, 8, 1, 4, 7], [0, 4, 8, 2, 6], [0, 5],
                            [0, 6, 2, 8, 4], [0, 7, 4, 1, 8, 5, 2, 9, 6, 3], [0, 8, 6, 4, 2], [9, 8, 7, 6, 5, 4, 3, 2, 1, 0]];
            int len = s.Length;
            int[] result = new int[len], _result = new int[len];
            for (int i = 0; i < len; i++) result[i] = s[i] & 15;
            if ((b & 1) == 1)
            {
                foreach (int x in amap[a]) foreach (int y in amap[a])
                    {
                        for (int i = 0; i < len; i += 2) _result[i] = ((s[i] & 15) + x) % 10;
                        for (int i = 1; i < len; i += 2) _result[i] = ((s[i] & 15) + y) % 10;
                        FindSmaller();
                    }
            }
            else
            {
                foreach (int x in amap[a])
                {
                    for (int i = 0; i < len; i += 2) _result[i] = s[i] & 15;
                    for (int i = 1; i < len; i += 2) _result[i] = ((s[i] & 15) + x) % 10;
                    FindSmaller();
                }
            }

            return new string(result.Select(x => (char)(x | 48)).ToArray());

            void FindSmaller()
            {
                bool[] mask = new bool[len];
                for (int start = 0; !mask[start]; start = (start - b + len) % len)
                {
                    for (int i = 0, j = start; i < len; i++, j = (j + 1) % len)
                    {
                        if (_result[j] > result[i]) break;
                        if (_result[j] < result[i])
                        {
                            Array.Copy(_result, start, result, 0, len - start);
                            Array.Copy(_result, 0, result, len - start, start);
                            break;
                        }
                    }
                    mask[start] = true;
                }
            }
        }
    }
}

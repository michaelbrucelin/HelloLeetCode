using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1763
{
    public class Solution1763_2 : Interface1763
    {
        /// <summary>
        /// 前缀和 + 暴力查找
        /// int[LEN+1,2,26]记录每个位置各个字母的数量的和
        /// 然后长度由大到小，位置从左到右，找到的第一个解就是正确的解
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string LongestNiceSubstring(string s)
        {
            int len = s.Length;
            int[,,] freq = new int[len + 1, 2, 27];
            for (int i = 0, d2, d3; i < len; i++)
            {
                d2 = (s[i] >> 5) & 1; d3 = s[i] & 31;
                for (int j = 1; j < 27; j++)
                {
                    if (j != d3)
                    {
                        freq[i + 1, 0, j] = freq[i, 0, j];
                        freq[i + 1, 1, j] = freq[i, 1, j];
                    }
                    else
                    {
                        freq[i + 1, d2, j] = freq[i, d2, j] + 1;
                        freq[i + 1, 1 - d2, j] = freq[i, 1 - d2, j];
                    }
                }
            }

            int width = len + 1; bool flag;
            while (--width > 1)
            {
                for (int i = 0, cnt0, cnt1; i <= len - width; i++)
                {
                    flag = true;
                    for (int j = 1; j < 27; j++)
                    {
                        cnt0 = freq[i + width, 0, j] - freq[i, 0, j];
                        cnt1 = freq[i + width, 1, j] - freq[i, 1, j];
                        if ((cnt0 > 0 && cnt1 == 0) || (cnt0 == 0 && cnt1 > 0)) flag = false;
                    }
                    if (flag) return s.Substring(i, width);
                }
            }

            return string.Empty;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2311
{
    public class Solution2311 : Interface2311
    {
        /// <summary>
        /// 贪心
        /// 1. 前缀0全部保留，所以可以使用类似于前缀和的方式来记录每个位置的前缀0的数量
        /// 2. 确定了第一个1，意味着从这个1开始，最多可以保留k的二进制这么长
        /// 3. 所以从后向前枚举每个1，并假定这个1是第一个1即可
        /// </summary>
        /// <param name="s"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int LongestSubsequence(string s, int k)
        {
            int result = 0, cnt0 = 0, len = s.Length;
            string k2 = Convert.ToString(k, 2);
            for (int i = 0; i < len; i++) cnt0 += s[i] - '0';
            if (cnt0 == len) return len;

            int klen = k2.Length, mlen;
            for (int i = len - 1; i >= 0; i--)
            {
                if (s[i] == '0')
                {
                    cnt0--;
                }
                else
                {
                    mlen = 0;
                    for (int j = 0; j < klen && i + j < len; j++)
                    {
                        switch ((s[i + j], k2[j]))
                        {
                            case ('1', '1'): mlen++; break;
                            case ('0', '0'): mlen++; break;
                            case ('1', '0'): break;
                            case ('0', '1'): break;
                        }
                    }
                }
            }

            return result;
        }
    }
}

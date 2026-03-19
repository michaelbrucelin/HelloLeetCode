using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2405
{
    public class Solution2405 : Interface2405
    {
        /// <summary>
        /// 贪心
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int PartitionString(string s)
        {
            int result = 1, len = s.Length;
            bool[] set = new bool[26];
            for (int i = 0; i < len; i++)
            {
                if (set[s[i] - 'a'])
                {
                    result++; Array.Fill(set, false);
                }
                set[s[i] - 'a'] = true;
            }

            return result;
        }

        /// <summary>
        /// 逻辑同PartitionString()，将数组改为整型
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int PartitionString2(string s)
        {
            int result = 1, len = s.Length;
            int set = 0;
            for (int i = 0; i < len; i++)
            {
                if (((set >> (s[i] - 'a')) & 1) != 0)
                {
                    result++; set = 0;
                }
                set |= 1 << (s[i] - 'a');
            }

            return result;
        }
    }
}

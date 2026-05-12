using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3084
{
    public class Solution3084 : Interface3084
    {
        /// <summary>
        /// 遍历
        /// 维护左，枚举右，左边有n个c，再枚举到一个c，会新增n+1个子串
        /// </summary>
        /// <param name="s"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public long CountSubstrings(string s, char c)
        {
            long result = 0, cnt = 0;
            foreach (char x in s) if (x == c) result += ++cnt;

            return result;
        }

        /// <summary>
        /// 数学
        /// 底层逻辑与CountSubstrings()一样
        /// </summary>
        /// <param name="s"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public long CountSubstrings2(string s, char c)
        {
            long cnt = 0;
            foreach (char x in s) if (x == c) cnt++;

            return (cnt + 1) * cnt >> 1;
        }
    }
}

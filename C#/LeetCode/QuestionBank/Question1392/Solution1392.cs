using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1392
{
    public class Solution1392 : Interface1392
    {
        /// <summary>
        /// 暴力查找
        /// 逻辑没问题，TLE，参考测试用例04, 05, 06
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string LongestPrefix(string s)
        {
            int len = s.Length;
            StringBuilder buffer = new StringBuilder();
            for (int i = 0; i < len; i++) buffer.Append(s[i]);
            for (int l = len - 1; l > 0; l--)
            {
                if (buffer.ToString(0, l) == buffer.ToString(len - l, l)) return buffer.ToString(0, l);
            }

            return "";
        }

        /// <summary>
        /// 对比时使用哈希值而不是逐个字符进行比较
        /// 逻辑没问题，依然TLE，参考测试用例04, 05, 06
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string LongestPrefix2(string s)
        {
            int len = s.Length;
            StringBuilder buffer = new StringBuilder();
            for (int i = 0; i < len; i++) buffer.Append(s[i]);
            for (int l = len - 1; l > 0; l--)
            {
                if (buffer.ToString(0, l).GetHashCode() == buffer.ToString(len - l, l).GetHashCode()) return buffer.ToString(0, l);
            }

            return "";
        }
    }
}

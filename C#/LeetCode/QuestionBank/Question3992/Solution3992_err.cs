using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3992
{
    public class Solution3992_err : Interface3992
    {
        /// <summary>
        /// 模拟
        /// 思路完全是错误的，参考测试用例04
        /// </summary>
        /// <param name="s"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public string RearrangeString(string s, char x, char y)
        {
            char[] chars = s.ToCharArray();
            for (int i = 0, j = chars.Length - 1; i < j; i++, j--)
            {
                if (chars[i] == x || chars[j] == y) (chars[i], chars[j]) = (chars[j], chars[i]);
            }

            return new string(chars);
        }
    }
}

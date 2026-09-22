using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3992
{
    public class Solution3992_err2 : Interface3992
    {
        /// <summary>
        /// 模拟
        /// y移动到最前，x移动到最后
        /// 
        /// 编码逻辑错误，简单题老出错，看来是人老了。。。
        /// </summary>
        /// <param name="s"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public string RearrangeString(string s, char x, char y)
        {
            char[] chars = s.ToCharArray();
            for (int i = 0, j = chars.Length - 1, pl = 0, pr = chars.Length - 1; i < j; i++, j--)
            {
                if (chars[i] == x) { (chars[i], chars[pr]) = (chars[pr], chars[i]); pr--; }
                else if (chars[i] == y) { (chars[i], chars[pl]) = (chars[pl], chars[i]); pl++; }
                if (chars[j] == x) { (chars[j], chars[pr]) = (chars[pr], chars[j]); pr--; }
                else if (chars[j] == y) { (chars[j], chars[pl]) = (chars[pl], chars[j]); pl++; }
            }

            return new string(chars);
        }
    }
}

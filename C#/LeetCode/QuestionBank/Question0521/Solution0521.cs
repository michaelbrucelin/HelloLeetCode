using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0521
{
    public class Solution0521 : Interface0521
    {
        /// <summary>
        /// 脑筋急转弯
        /// 如果两个字符串相等，返回-1，否则返回更长的那个字符串的长度
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public int FindLUSlength(string a, string b)
        {
            return a != b ? Math.Max(a.Length, b.Length) : -1;
        }
    }
}

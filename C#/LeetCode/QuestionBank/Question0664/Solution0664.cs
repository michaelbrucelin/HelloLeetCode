using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0664
{
    public class Solution0664 : Interface0664
    {
        /// <summary>
        /// DFS + 记忆化搜索
        /// 首先简化s，将连续相同的字符缩减为1个，例如 aabcccdeef --> abcdef，然后
        /// 如果首尾字符相同，结果为 s 去掉首尾字符后字符串的结果 + 1
        /// 如果首尾字符不同，？
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int StrangePrinter(string s)
        {
            throw new NotImplementedException();
        }
    }
}

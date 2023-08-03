using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0722
{
    public class Solution0722_api : Interface0722
    {
        /// <summary>
        /// 结果是对的，自己也有点迷糊
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public IList<string> RemoveComments(string[] source)
        {
            return Regex.Replace(string.Join("\n", source), @"//.*|/\*(.|\n)*?\*/", "").Split("\n", StringSplitOptions.RemoveEmptyEntries);
        }
    }
}

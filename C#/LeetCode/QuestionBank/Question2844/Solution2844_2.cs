using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2844
{
    public class Solution2844_2 : Interface2844
    {
        /// <summary>
        /// 正则
        /// 逻辑与Solution2844相同，换成正则表达式的贪婪模式来实现
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public int MinimumOperations(string num)
        {
            int result = num.Length, len = num.Length;
            if (num.Contains('0')) result = len - 1;

            string pattern = @"(.*[05](.*)0)[^0]*";
            Match match = Regex.Match(num, pattern);
            if (match.Success) result = len - match.Groups[1].Length + match.Groups[2].Length;
            pattern = @"(.*[27](.*)5)[^5]*";
            match = Regex.Match(num, pattern);
            if (match.Success) result = Math.Min(result, len - match.Groups[1].Length + match.Groups[2].Length);

            return result;
        }
    }
}

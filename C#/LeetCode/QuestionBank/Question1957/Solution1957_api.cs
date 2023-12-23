using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1957
{
    public class Solution1957_api : Interface1957
    {
        /// <summary>
        /// 正则表达式
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string MakeFancyString(string s)
        {
            return Regex.Replace(s, @"(.)\1{2,}", @"$1$1");
        }
    }
}

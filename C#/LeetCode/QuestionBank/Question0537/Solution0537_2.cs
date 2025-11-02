using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0537
{
    public class Solution0537_2 : Interface0537
    {
        private static readonly Regex regex = new Regex(@"^(-?\d+)\+(-?\d+)i$", RegexOptions.Compiled);

        /// <summary>
        /// 正则表达式
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        public string ComplexNumberMultiply(string num1, string num2)
        {
            Match analyze1 = regex.Match(num1);
            Match analyze2 = regex.Match(num2);

            int x1 = int.Parse(analyze1.Groups[1].Value);
            int y1 = int.Parse(analyze1.Groups[2].Value);
            int x2 = int.Parse(analyze2.Groups[1].Value);
            int y2 = int.Parse(analyze2.Groups[2].Value);

            return $"{x1 * x2 - y1 * y2}+{x1 * y2 + x2 * y1}i";
        }
    }
}

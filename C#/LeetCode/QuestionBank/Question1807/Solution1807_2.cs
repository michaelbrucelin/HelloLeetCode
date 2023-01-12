using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1807
{
    public class Solution1807_2 : Interface1807
    {
        /// <summary>
        /// 暴力解
        /// 解法没错，但是提交会超时，参考测试用例8
        /// </summary>
        /// <param name="s"></param>
        /// <param name="knowledge"></param>
        /// <returns></returns>
        public string Evaluate(string s, IList<IList<string>> knowledge)
        {
            for (int i = 0; i < knowledge.Count; i++)
            {
                if (!s.Contains('(')) return s;
                s = s.Replace($"({knowledge[i][0]})", knowledge[i][1]);
            }
            if (!s.Contains('(')) return s;

            return Regex.Replace(s, @"\(.+?\)", "?");
        }
    }
}

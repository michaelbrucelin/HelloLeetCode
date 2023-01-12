using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1807
{
    public class Solution1807_3 : Interface1807
    {
        /// <summary>
        /// 使用API
        /// </summary>
        /// <param name="s"></param>
        /// <param name="knowledge"></param>
        /// <returns></returns>
        public string Evaluate(string s, IList<IList<string>> knowledge)
        {
            Dictionary<string, string> helper = new Dictionary<string, string>(knowledge.Select(item => new KeyValuePair<string, string>($"({item[0]})", item[1])));
            return s.Replace("(", "#(").Replace(")", ")#")
                        .Split('#', StringSplitOptions.RemoveEmptyEntries)
                        .Select(s => s.StartsWith('(') ? (helper.ContainsKey(s) ? helper[s] : "?") : s)
                        .Aggregate((s1, s2) => $"{s1}{s2}");
        }
    }
}

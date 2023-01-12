using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1807
{
    public class Solution1807 : Interface1807
    {
        /// <summary>
        /// 字典 + 双指针
        /// </summary>
        /// <param name="s"></param>
        /// <param name="knowledge"></param>
        /// <returns></returns>
        public string Evaluate(string s, IList<IList<string>> knowledge)
        {
            Dictionary<string, string> helper = new Dictionary<string, string>();
            for (int i = 0; i < knowledge.Count; i++) helper.Add(knowledge[i][0], knowledge[i][1]);

            StringBuilder result = new StringBuilder();
            int left = 0, right, len = s.Length;
            while (left < len)
            {
                if (s[left] != '(') result.Append(s[left++]);
                else
                {
                    right = ++left; while (s[right] != ')') right++;
                    string key = s.Substring(left, right - left);
                    if (helper.ContainsKey(key)) result.Append(helper[key]); else result.Append('?');
                    left = right + 1;
                }
            }

            return result.ToString();
        }
    }
}

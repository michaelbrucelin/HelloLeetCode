using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1807
{
    public class Solution1807_5 : Interface1807
    {
        /// <summary>
        /// Hash
        /// </summary>
        /// <param name="s"></param>
        /// <param name="knowledge"></param>
        /// <returns></returns>
        public string Evaluate(string s, IList<IList<string>> knowledge)
        {
            Dictionary<string, string> map = new Dictionary<string, string>();
            foreach (IList<string> item in knowledge) map.Add(item[0], item[1]);

            StringBuilder result = new StringBuilder();
            int pl = 0, pr, len = s.Length;
            while (pl < len)
            {
                while (pl < len && s[pl] != '(') result.Append(s[pl++]);
                if (pl == len) break;
                pr = ++pl;
                while (s[pr] != ')') pr++;  // 题目限定一定有 )
                if (map.TryGetValue(s[pl..pr], out string val)) result.Append(val); else result.Append('?');
                pl = pr + 1;
            }

            return result.ToString();
        }
    }
}

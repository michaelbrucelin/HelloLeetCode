using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3527
{
    public class Solution3527 : Interface3527
    {
        /// <summary>
        /// Hash
        /// </summary>
        /// <param name="responses"></param>
        /// <returns></returns>
        public string FindCommonResponse(IList<IList<string>> responses)
        {
            int cnt = responses.Count;
            HashSet<string>[] sets = new HashSet<string>[cnt];
            for (int i = 0; i < cnt; i++) sets[i] = [.. responses[i]];
            Dictionary<string, int> map = new Dictionary<string, int>();
            for (int i = 0; i < cnt; i++) foreach (string s in sets[i])
                {
                    if (map.TryGetValue(s, out int val)) map[s] = ++val; else map.Add(s, 1);
                }

            string result = "";
            int max = 0;
            foreach (string key in map.Keys) switch (map[key] - max)
                {
                    case > 0: result = key; max = map[key]; break;
                    case < 0: break;
                    default: if (string.CompareOrdinal(key, result) < 0) result = key; break;
                }

            return result;
        }
    }
}

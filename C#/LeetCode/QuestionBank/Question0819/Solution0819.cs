using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0819
{
    public class Solution0819 : Interface0819
    {
        /// <summary>
        /// 类C
        /// 使用类似于朴素C的方式去分割字符串
        /// </summary>
        /// <param name="paragraph"></param>
        /// <param name="banned"></param>
        /// <returns></returns>
        public string MostCommonWord(string paragraph, string[] banned)
        {
            HashSet<string> ban = new HashSet<string>(banned);
            HashSet<char> sym = new HashSet<char>() { ' ', '!', '?', '\'', ',', ';', '.' };
            Dictionary<string, int> map = new Dictionary<string, int>();
            StringBuilder sb = new StringBuilder();

            int left = 0, right, len = paragraph.Length; string _;
            while (left < len)
            {
                while (left < len && sym.Contains(paragraph[left])) left++;
                if (left == len) break;
                right = left;
                while (right < len && !sym.Contains(paragraph[right])) right++;
                sb.Clear();
                for (int i = left; i < right; i++)
                    sb.Append((char)(paragraph[i] | 32));
                if (!ban.Contains(_ = sb.ToString()))
                {
                    if (map.ContainsKey(_)) map[_]++; else map.Add(_, 1);
                }
                left = right + 1;
            }

            string result = ""; int freq = 0;
            foreach (var kv in map) if (kv.Value > freq)
                {
                    result = kv.Key; freq = kv.Value;
                }

            return result;
        }
    }
}

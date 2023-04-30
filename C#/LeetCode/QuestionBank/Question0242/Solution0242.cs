using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0242
{
    public class Solution0242 : Interface0242
    {
        /// <summary>
        /// 进阶的话，由于出现了unicode字符，所以需要将freq由int[]改为Dictionary<char, int>
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length) return false;

            int[] freq = new int[26];
            for (int i = 0; i < s.Length; i++)
            {
                freq[s[i] - 'a']++;
                freq[t[i] - 'a']--;
            }

            for (int i = 0; i < 26; i++) if (freq[i] != 0) return false;
            return true;
        }

        public bool IsAnagram2(string s, string t)
        {
            if (s.Length != t.Length) return false;

            int[] freq = new int[26];
            for (int i = 0; i < s.Length; i++) freq[s[i] - 'a']++;
            for (int i = 0; i < t.Length; i++)
            {
                freq[t[i] - 'a']--;
                if (freq[t[i] - 'a'] < 0) return false;
            }

            // for (int i = 0; i < 26; i++) if (freq[i] != 0) return false;  // 由于s与t长度相等，所以如果由>0，必然也会有<0
            return true;
        }

        /// <summary>
        /// 进阶的话，算法无需更改
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool IsAnagram3(string s, string t)
        {
            if (s.Length != t.Length) return false;

            return Enumerable.SequenceEqual(s.OrderBy(c => c), t.OrderBy(c => c));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0032
{
    public class Solution0032 : Interface0032
    {
        public bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length || s == t) return false;

            int[] freq = new int[26];
            for (int i = 0; i < s.Length; i++) freq[s[i] - 'a']++;
            for (int i = 0; i < t.Length; i++)
            {
                freq[t[i] - 'a']--;
                if (freq[t[i] - 'a'] < 0) return false;
            }

            // for (int i = 0; i < 26; i++) if (freq[i] != 0) return false;  // 由于s与t长度相等，所以如果有>0，必然也会有<0
            return true;
        }
    }
}

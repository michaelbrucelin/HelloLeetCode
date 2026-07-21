using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0567
{
    public class Solution0567 : Interface0567
    {
        /// <summary>
        /// 滑动窗口
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        public bool CheckInclusion(string s1, string s2)
        {
            if (s1.Length > s2.Length) return false;

            int[] freq = new int[26], _freq = new int[26];
            foreach (char c in s1) freq[c - 'a']++;
            int p1 = 0, p2 = -1, id, _id, cnt = 0, len = s2.Length;
            for (int i = 0; i < 26; i++) if (freq[i] == 0) cnt++;
            while (++p2 < len)
            {
                _freq[id = s2[p2] - 'a']++;
                switch (_freq[id] - freq[id])
                {
                    case > 0:
                        do { _freq[_id = s2[p1++] - 'a']--; if (_freq[_id] == freq[_id] - 1) cnt--; } while (_id != id);
                        break;
                    case < 0:
                        break;
                    default:
                        if (++cnt == 26) return true;
                        break;
                }
            }

            return false;
        }
    }
}

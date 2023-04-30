using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0859
{
    public class Solution0859 : Interface0859
    {
        /// <summary>
        /// 简单 + 易错
        /// 1. 两个字符串长度相同
        /// 2. 如果两个字符串不同
        ///     二者有且只有两个位置不同，且两个位置互为镜像
        /// 3. 如果两个字符串相同
        ///     需要至少有一个字符出现两次，保证互换后字符串不变
        /// </summary>
        /// <param name="s"></param>
        /// <param name="goal"></param>
        /// <returns></returns>
        public bool BuddyStrings(string s, string goal)
        {
            if (s.Length != goal.Length) return false;

            int[] pos = new int[2], freq = new int[26]; int pid = 0;
            for (int i = 0; i < s.Length; i++)
            {
                freq[s[i] - 'a']++;
                if (s[i] != goal[i])
                {
                    if (pid > 1) return false;  // 两个以上字符不同
                    pos[pid++] = i;
                }
            }
            if (pid == 1) return false;         // 只有一个字符不同
            if (pid == 0)                       // 字符串相同
            {
                for (int i = 0; i < 26; i++) if (freq[i] > 1) return true;
                return false;
            }

            return s[pos[0]] == goal[pos[1]] && s[pos[1]] == goal[pos[0]];
        }
    }
}

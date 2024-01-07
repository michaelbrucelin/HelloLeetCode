using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0383
{
    public class Solution0383 : Interface0383
    {
        public bool CanConstruct(string ransomNote, string magazine)
        {
            if (ransomNote.Length > magazine.Length) return false;

            int[] cnts = new int[26];
            for (int i = 0; i < ransomNote.Length; i++) cnts[ransomNote[i] - 'a']--;
            for (int i = 0; i < magazine.Length; i++) cnts[magazine[i] - 'a']++;

            for (int i = 0; i < 26; i++) if (cnts[i] < 0) return false;
            return true;
        }

        public bool CanConstruct2(string ransomNote, string magazine)
        {
            if (ransomNote.Length > magazine.Length) return false;

            int[] cnts = new int[26];
            for (int i = 0; i < magazine.Length; i++) cnts[magazine[i] - 'a']++;
            for (int i = 0; i < ransomNote.Length; i++)
            {
                if (--cnts[ransomNote[i] - 'a'] < 0) return false;
            }

            // for (int i = 0; i < 26; i++) if (cnts[i] < 0) return false;
            return true;
        }
    }
}

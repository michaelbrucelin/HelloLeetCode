using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview0101
{
    public class Solution0101 : Interface0101
    {
        /// <summary>
        /// 暴力
        /// </summary>
        /// <param name="astr"></param>
        /// <returns></returns>
        public bool IsUnique(string astr)
        {
            if (astr.Length > 26) return false;

            for (int i = 0; i < astr.Length; i++) for (int j = i + 1; j < astr.Length; j++)
                    if (astr[i] == astr[j]) return false;
            return true;
        }

        public bool IsUnique2(string astr)
        {
            if (astr.Length > 26) return false;

            bool[] hash = new bool[26];
            for (int i = 0; i < astr.Length; i++)
                if (hash[astr[i] - 'a']) return false; else hash[astr[i] - 'a'] = true;

            return true;
        }

        public bool IsUnique3(string astr)
        {
            if (astr.Length > 26) return false;

            int hash = 0;
            for (int i = 0; i < astr.Length; i++)
                if ((hash >> (astr[i] - 'a') & 1) == 1) return false; else hash |= (1 << (astr[i] - 'a'));

            return true;
        }

        public bool IsUnique4(string astr)
        {
            if (astr.Length > 26) return false;
            return astr.Distinct().Count() == astr.Length;
        }
    }
}

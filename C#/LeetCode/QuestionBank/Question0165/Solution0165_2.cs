using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0165
{
    public class Solution0165_2 : Interface0165
    {
        /// <summary>
        /// 双指针
        /// 逻辑同Solution0165，提前用API拆分
        /// </summary>
        /// <param name="version1"></param>
        /// <param name="version2"></param>
        /// <returns></returns>
        public int CompareVersion(string version1, string version2)
        {
            string[] strs1 = version1.Split('.');
            string[] strs2 = version2.Split('.');
            int p1 = 0, p2 = 0, v1, v2, len1 = strs1.Length, len2 = strs2.Length;
            while (p1 < len1 || p2 < len2)
            {
                v1 = p1 < len1 ? int.Parse(strs1[p1]) : 0;
                v2 = p2 < len2 ? int.Parse(strs2[p2]) : 0;
                switch (v1 - v2)
                {
                    case > 0: return 1;
                    case < 0: return -1;
                }
                p1++; p2++;
            }

            return 0;
        }
    }
}

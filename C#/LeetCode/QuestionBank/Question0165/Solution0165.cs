using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0165
{
    public class Solution0165 : Interface0165
    {
        /// <summary>
        /// 双指针
        /// </summary>
        /// <param name="version1"></param>
        /// <param name="version2"></param>
        /// <returns></returns>
        public int CompareVersion(string version1, string version2)
        {
            int p1 = -1, p2 = -1, v1, v2, len1 = version1.Length, len2 = version2.Length;
            while (p1 < len1 || p2 < len2)
            {
                v1 = 0;
                while (++p1 < len1 && version1[p1] != '.') v1 = v1 * 10 + (version1[p1] & 15);
                v2 = 0;
                while (++p2 < len2 && version2[p2] != '.') v2 = v2 * 10 + (version2[p2] & 15);
                switch (v1 - v2)
                {
                    case > 0: return 1;
                    case < 0: return -1;
                }
            }

            return 0;
        }
    }
}

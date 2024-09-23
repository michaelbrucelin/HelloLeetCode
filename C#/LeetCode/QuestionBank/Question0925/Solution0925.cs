using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0925
{
    public class Solution0925 : Interface0925
    {
        /// <summary>
        /// 双指针模拟
        /// </summary>
        /// <param name="name"></param>
        /// <param name="typed"></param>
        /// <returns></returns>
        public bool IsLongPressedName(string name, string typed)
        {
            if (name.Length > typed.Length) return false;
            if (name[0] != typed[0]) return false;

            int p1 = 1, p2 = 1, len1 = name.Length, len2 = typed.Length, extra = len2 - len1;
            while (p1 < len1 && p2 < len2 && extra >= 0)
            {
                if (name[p1] == typed[p2])
                {
                    p1++; p2++;
                }
                else
                {
                    if (typed[p2] != typed[p2 - 1]) return false;
                    p2++; extra--;
                }
            }
            if (extra < 0 || p1 < len1) return false;
            int _p2 = p2 - 1; while (p2 < len2) if (typed[p2++] != typed[_p2]) return false;

            return true;
        }
    }
}

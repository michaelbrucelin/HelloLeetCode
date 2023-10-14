using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0925
{
    public class Solution0925_2 : Interface0925
    {
        /// <summary>
        /// 逻辑同Solution0925，换了一种写法
        /// </summary>
        /// <param name="name"></param>
        /// <param name="typed"></param>
        /// <returns></returns>
        public bool IsLongPressedName(string name, string typed)
        {
            if (name.Length > typed.Length) return false;

            int p1 = 0, p2 = 0, cnt1, cnt2, len1 = name.Length, len2 = typed.Length, extra = len2 - len1;
            while (p1 < len1 && p2 < len2)
            {
                if (name[p1] != typed[p2]) return false;
                cnt1 = 1; while (p1 + 1 < len1 && name[p1 + 1] == name[p1]) { cnt1++; p1++; }
                cnt2 = 1; while (p2 + 1 < len2 && typed[p2 + 1] == typed[p2]) { cnt2++; p2++; }
                if (cnt1 > cnt2) return false;
                if ((extra - cnt2 + cnt1) < 0) return false;
                p1++; p2++;
            }
            if (p1 < len1 || p2 < len2) return false;

            return true;
        }
    }
}

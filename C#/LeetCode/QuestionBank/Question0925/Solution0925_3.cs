using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0925
{
    public class Solution0925_3 : Interface0925
    {
        /// <summary>
        /// 双指针 + 贪心
        /// </summary>
        /// <param name="name"></param>
        /// <param name="typed"></param>
        /// <returns></returns>
        public bool IsLongPressedName(string name, string typed)
        {
            if (name[0] != typed[0]) return false;

            int pn = -1, pt = 0, ln = name.Length, lt = typed.Length;
            while (++pn < ln && pt < lt)
            {
                if (typed[pt] == name[pn])
                {
                    pt++;
                }
                else
                {
                    while (pt < lt && typed[pt] == typed[pt - 1]) pt++;
                    if (pt == lt || typed[pt] != name[pn]) break;
                    pt++;
                }
            }
            if (pn < ln) return false;
            while (pt < lt) if (typed[pt] != typed[pt - 1]) return false; else pt++;

            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3823
{
    public class Solution3823 : Interface3823
    {
        /// <summary>
        /// 两轮遍历
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string ReverseByType(string s)
        {
            int len = s.Length;
            List<int> ids1 = [], ids2 = [];
            for (int i = 0; i < len; i++) if (char.IsLower(s[i])) ids1.Add(i); else ids2.Add(i);

            char[] chars = s.ToCharArray();
            int pl = -1, pr = ids1.Count; char temp;
            while (++pl < --pr) { temp = chars[ids1[pl]]; chars[ids1[pl]] = chars[ids1[pr]]; chars[ids1[pr]] = temp; }
            pl = -1; pr = ids2.Count;
            while (++pl < --pr) { temp = chars[ids2[pl]]; chars[ids2[pl]] = chars[ids2[pr]]; chars[ids2[pr]] = temp; }

            return new string(chars);
        }
    }
}

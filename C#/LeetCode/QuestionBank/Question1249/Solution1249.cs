using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1249
{
    public class Solution1249 : Interface1249
    {
        /// <summary>
        /// 栈
        /// 这里直接用List<int>代替栈
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string MinRemoveToMakeValid(string s)
        {
            int lid = 0, rid = 0, len = s.Length;
            List<int> lids = [], rids = [];
            for (int i = 0; i < len; i++) switch (s[i])
                {
                    case '(': if (lid == lids.Count) lids.Add(i); else lids[lid] = i; lid++; break;
                    case ')': if (lid > 0) lid--; else { if (rid == rids.Count) rids.Add(i); else rids[rid] = i; rid++; } break;
                    default: break;
                }

            StringBuilder result = new StringBuilder();
            int pl = 0, pr = 0;
            for (int i = 0; i < len; i++)
            {
                if (pl < lid && i == lids[pl]) { pl++; continue; }
                if (pr < rid && i == rids[pr]) { pr++; continue; }
                result.Append(s[i]);
            }

            return result.ToString();
        }
    }
}

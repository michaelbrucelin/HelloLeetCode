using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0301
{
    public class Solution0301 : Interface0301
    {
        /// <summary>
        /// 栈 + 回溯
        /// 这里直接用List<int>代替栈，逻辑上同Solution1249，如果一个位置应该删除，那么连续相同的位置删除任意一个都可以
        /// 
        /// 思路有问题，例如 "()())()())"
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public IList<string> RemoveInvalidParentheses(string s)
        {
            int lid = 0, rid = 0, len = s.Length;
            List<int> lids = [], rids = [];
            for (int i = 0; i < len; i++) switch (s[i])
                {
                    case '(': if (lid == lids.Count) lids.Add(i); else lids[lid] = i; lid++; break;
                    case ')': if (lid > 0) lid--; else { if (rid == rids.Count) rids.Add(i); else rids[rid] = i; rid++; } break;
                    default: break;
                }

            List<List<int>> dels = [];
            int pl = 0, pr = 0, id;
            while (pl < lid && pr < rid)
            {
                if (lids[pl] < rids[pr]) { id = lids[pl]; pl++; } else { id = rids[pr]; pr++; }
            }

            return null;
        }
    }
}

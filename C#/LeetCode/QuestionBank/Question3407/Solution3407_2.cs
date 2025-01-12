using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3407
{
    public class Solution3407_2 : Interface3407
    {
        /// <summary>
        /// 逻辑同Solution3407，使用.net api
        /// 使用api比直接暴力查找慢了很多，不确定是为什么
        /// </summary>
        /// <param name="s"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool HasMatch(string s, string p)
        {
            if (p == "*") return true;
            if (s.Length < p.Length - 1) return false;

            int ls = s.Length, lp = p.Length, id;
            if (p[0] == '*' || p[^1] == '*')
            {
                string _p = p[0] == '*' ? p[1..] : p[..^1];
                id = s.IndexOf(_p);
                return id != -1;
            }
            else
            {
                for (id = 0; id < lp; id++) if (p[id] == '*') break;
                string _p1 = p[..id], _p2 = p[(id + 1)..];
                int id1 = s.IndexOf(_p1);
                if (id1 == -1) return false;
                int id2 = s.LastIndexOf(_p2);
                if (id2 == -1) return false;

                return id1 + _p1.Length <= id2;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3407
{
    public class Solution3407 : Interface3407
    {
        /// <summary>
        /// 暴力查找，类C的朴素解法
        /// 如果*在p的两端，那么直接查找p去掉*后是不是s的子字符串即可
        /// 如果*在p的中间，那么从前向后找p中*前面的部分，从后向前找p中*后面的部分，两部分没有重叠即可
        /// 
        /// 想加速可以使用KMP来替代暴力查找
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
                id = substr_head(s, _p);
                return id != -1;
            }
            else
            {
                for (id = 0; id < lp; id++) if (p[id] == '*') break;
                string _p1 = p[..id], _p2 = p[(id + 1)..];
                int id1 = substr_head(s, _p1);
                if (id1 == -1) return false;
                int id2 = substr_tail(s, _p2);
                if (id2 == -1) return false;

                return id1 + _p1.Length <= id2;
            }

            int substr_head(string s, string p)
            {
                int lp = p.Length;
                for (int i = 0, j; i <= ls - lp; i++)
                {
                    for (j = 0; j < lp; j++) if (s[i + j] != p[j]) break;
                    if (j == lp) return i;
                }

                return -1;
            }

            int substr_tail(string s, string p)
            {
                int lp = p.Length;
                for (int i = ls - 1, j; i >= lp - 1; i--)
                {
                    for (j = 0; j < lp; j++) if (s[i - j] != p[lp - 1 - j]) break;
                    if (j == lp) return i - lp + 1;
                }

                return -1;
            }
        }
    }
}

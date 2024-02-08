using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2839
{
    public class Solution2839 : Interface2839
    {
        /// <summary>
        /// 分类讨论
        /// 只有4种可能，不交换、交换0,2、交换1,3、同时交换0,2与1,3
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        public bool CanBeEqual(string s1, string s2)
        {
            return s1 == s2
                   || (s1[2] == s2[0] && s1[1] == s2[1] && s1[0] == s2[2] && s1[3] == s2[3])
                   || (s1[0] == s2[0] && s1[3] == s2[1] && s1[2] == s2[2] && s1[1] == s2[3])
                   || (s1[2] == s2[0] && s1[3] == s2[1] && s1[0] == s2[2] && s1[1] == s2[3]);
        }

        public bool CanBeEqual2(string s1, string s2)
        {
            if (s1[0] == s2[0])
            {
                if (s1[2] != s2[2]) return false;
            }
            else
            {
                if (s1[0] != s2[2] || s1[2] != s2[0]) return false;
            }

            if (s1[1] == s2[1])
            {
                if (s1[3] != s2[3]) return false;
            }
            else
            {
                if (s1[1] != s2[3] || s1[3] != s2[1]) return false;
            }

            return true;
        }
    }
}

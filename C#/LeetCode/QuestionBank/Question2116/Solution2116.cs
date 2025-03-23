using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2116
{
    public class Solution2116 : Interface2116
    {
        /// <summary>
        /// 两次遍历
        /// 1. 忽略未锁定的位置，因为未锁定的位置可以随意更换
        /// 2. 从左向右遍历，锁定的 ) 不能超过总数量的一半，否则无法匹配
        /// 3. 从右向左遍历，锁定的 ( 不能超过总数量的一半，否则无法匹配
        /// 证明，符合2 3就一定可以匹配
        /// 1. 所有未锁定的位置当作是空白
        /// 2. 从左向右遍历，每个未锁定的位置，只要 ( 的数量没有达到总长度的一半，就放 ( ，否则放 ) ，这样就可以了
        /// </summary>
        /// <param name="s"></param>
        /// <param name="locked"></param>
        /// <returns></returns>
        public bool CanBeValid(string s, string locked)
        {
            int len = s.Length;
            if ((len & 1) != 0) return false;

            int cnt = 0;
            for (int i = 0; i < len; i++) if (locked[i] == '1' && s[i] == ')')
                {
                    if (++cnt > ((i + 1) >> 1)) return false;
                }

            cnt = 0;
            for (int i = len - 1; i >= 0; i--) if (locked[i] == '1' && s[i] == '(')
                {
                    if (++cnt > ((len - i) >> 1)) return false;
                }

            return true;
        }
    }
}

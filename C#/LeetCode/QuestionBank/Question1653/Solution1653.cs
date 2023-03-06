using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1653
{
    public class Solution1653 : Interface1653
    {
        /// <summary>
        /// 栈
        /// 具体分析见Solution1653.md
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int MinimumDeletions(string s)
        {
            Stack<(int bcnt, int acnt)> stack = new Stack<(int, int)>();
            int acnt = 0, bcnt = 0; for (int i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] == 'b') bcnt++;
                else  // if (s[i] == 'a')
                {
                    if (bcnt > 0)
                    {
                        stack.Push((bcnt, acnt)); bcnt = 0;
                    }
                    acnt++;
                }
            }
            if (bcnt > 0) stack.Push((bcnt, acnt));

            int result = s.Length, temp = 0;
            while (stack.Count > 0)
            {
                var item = stack.Pop();
                result = Math.Min(result, temp + item.acnt);  // 保留这组b
                temp += item.bcnt;                            // 删除这组b
            }
            result = Math.Min(result, temp);

            return result;
        }
    }
}

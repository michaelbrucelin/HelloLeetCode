using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1614
{
    public class Solution1614 : Interface1614
    {
        /// <summary>
        /// 遍历
        /// ()(()())  ()(()(()(())))
        /// 10121210  12121232343210
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int MaxDepth(string s)
        {
            int result = 0, flag = 0, depth = 0;
            for (int i = 0; i < s.Length; i++)
            {
                switch (s[i])
                {
                    case '(':
                        flag++; depth = Math.Max(depth, flag);
                        break;
                    case ')':
                        flag--; if (flag == 0)
                        {
                            result = Math.Max(result, depth); depth = 0;
                        }
                        break;
                    default:
                        break;
                }
            }

            return result;
        }

        public int MaxDepth2(string s)
        {
            int result = 0, depth = 0;
            for (int i = 0; i < s.Length; i++)
            {
                switch (s[i])
                {
                    case '(':
                        depth++; result = Math.Max(result, depth);
                        break;
                    case ')':
                        depth--;
                        break;
                    default:
                        break;
                }
            }

            return result;
        }
    }
}

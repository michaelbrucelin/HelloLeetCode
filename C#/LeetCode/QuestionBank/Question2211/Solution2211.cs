using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2211
{
    public class Solution2211 : Interface2211
    {
        /// <summary>
        /// 状态机
        /// 遍历，初始状态为：L:1，然后逐个字符分析
        ///     L + L -> L, L + S -> S, L + R -> R
        ///     S + L -> S, S + S -> S, S + R -> R
        ///     R + L -> S, R + S -> S, R + R -> R
        /// </summary>
        /// <param name="directions"></param>
        /// <returns></returns>
        public int CountCollisions(string directions)
        {
            int result = 0;
            char state = 'L'; int cnt = 0;
            foreach (char c in directions)
            {
                switch ((state, c))
                {
                    case ('L', 'L'): break;
                    case ('L', 'S'): state = 'S'; break;
                    case ('L', 'R'): state = 'R'; cnt = 1; break;
                    case ('S', 'L'): result += 1; break;
                    case ('S', 'S'): break;
                    case ('S', 'R'): state = 'R'; cnt = 1; break;
                    case ('R', 'L'): state = 'S'; result += cnt + 1; break;
                    case ('R', 'S'): state = 'S'; result += cnt; break;
                    case ('R', 'R'): cnt++; break;
                    default: break;
                }
            }

            return result;
        }
    }
}

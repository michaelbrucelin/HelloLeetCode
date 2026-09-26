using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3968
{
    public class Solution3968 : Interface3968
    {
        /// <summary>
        ///  状态机
        /// </summary>
        /// <param name="moves"></param>
        /// <returns></returns>
        public int MaxDistance(string moves)
        {
            int xcnt = 0, ycnt = 0, zcnt = 0;
            foreach (char move in moves) switch (move)
                {
                    case 'U': ycnt++; break;
                    case 'D': ycnt--; break;
                    case 'L': xcnt--; break;
                    case 'R': xcnt++; break;
                    default: zcnt++; break;
                }

            return Math.Abs(xcnt) + Math.Abs(ycnt) + zcnt;
        }
    }
}

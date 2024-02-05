using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2833
{
    public class Solution2833 : Interface2833
    {
        /// <summary>
        /// 消除掉成对的LR即可
        /// </summary>
        /// <param name="moves"></param>
        /// <returns></returns>
        public int FurthestDistanceFromOrigin(string moves)
        {
            int len = moves.Length, lcnt = 0, rcnt = 0;
            foreach (char c in moves)
            {
                if (c == 'L') lcnt++; else if (c == 'R') rcnt++;
            }

            return len - (Math.Min(lcnt, rcnt) << 1);
        }

        public int FurthestDistanceFromOrigin2(string moves)
        {
            int len = moves.Length;
            int[] cnts = new int[4];
            foreach (char c in moves) cnts[c & 3]++;

            return len - (Math.Min(cnts[0], cnts[2]) << 1);
        }
    }
}

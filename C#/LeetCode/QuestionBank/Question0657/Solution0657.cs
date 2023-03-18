using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0657
{
    public class Solution0657 : Interface0657
    {
        public bool JudgeCircle(string moves)
        {
            int x = 0, y = 0;
            for (int i = 0; i < moves.Length; i++)
            {
                switch (moves[i])
                {
                    case 'R': x++; break;
                    case 'L': x--; break;
                    case 'U': y++; break;
                    case 'D': y--; break;
                }
            }

            return x == 0 && y == 0;
        }

        /// <summary>
        /// 非if-else解析UDLR方向字母：((char+3)>>3)&3
        /// U --> 11 --> 3
        /// D --> 00 --> 0
        /// L --> 01 --> 1
        /// R --> 10 --> 2
        /// </summary>
        /// <param name="moves"></param>
        /// <returns></returns>
        public bool JudgeCircle2(string moves)
        {
            int[] cnt = new int[4];
            for (int i = 0; i < moves.Length; i++)
                cnt[((moves[i] + 3) >> 3) & 3]++;

            return cnt[0] == cnt[3] && cnt[1] == cnt[2];
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0948
{
    public class Solution0948 : Interface0948
    {
        /// <summary>
        /// 排序 + 贪心
        /// </summary>
        /// <param name="tokens"></param>
        /// <param name="power"></param>
        /// <returns></returns>
        public int BagOfTokensScore(int[] tokens, int power)
        {
            Array.Sort(tokens);

            int result = 0, pl = 0, pr = tokens.Length - 1;
            while (pl <= pr)
            {
                while (pl <= pr && power >= tokens[pl]) { result++; power -= tokens[pl++]; }
                if (pl >= pr) break;
                if (result > 0 && tokens[pr] > tokens[pl]) { result--; power += tokens[pr--]; } else break;
            }

            return result;
        }
    }
}

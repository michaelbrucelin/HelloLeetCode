using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2125
{
    public class Solution2125 : Interface2125
    {
        /// <summary>
        /// 逐行遍历
        /// </summary>
        /// <param name="bank"></param>
        /// <returns></returns>
        public int NumberOfBeams(string[] bank)
        {
            int result = 0, rcnt = bank.Length, ccnt = bank[0].Length, cnt1 = 0, cnt2 = 0;
            for (int r = 0; r < rcnt; r++)
            {
                for (int c = 0; c < ccnt; c++) cnt2 += bank[r][c] & 15;
                if (cnt2 > 0)
                {
                    result += cnt1 * cnt2;
                    cnt1 = cnt2;
                    cnt2 = 0;
                }
            }

            return result;
        }
    }
}

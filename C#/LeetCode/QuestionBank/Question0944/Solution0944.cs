using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0944
{
    public class Solution0944 : Interface0944
    {
        /// <summary>
        /// 遍历
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public int MinDeletionSize(string[] strs)
        {
            int result = 0, rcnt = strs.Length, ccnt = strs[0].Length;
            for (int c = 0; c < ccnt; c++) for (int r = 1; r < rcnt; r++)
                {
                    if (strs[r][c] < strs[r - 1][c]) { result++; break; }
                }

            return result;
        }
    }
}

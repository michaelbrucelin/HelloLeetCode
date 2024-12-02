using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0052
{
    public class Solution0052_2 : Interface0052
    {
        /// <summary>
        /// 回溯
        /// 逻辑同Solution0052，只是将其中的bool数组改为整型的位运算
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int TotalNQueens(int n)
        {
            if (n == 1) return 1;

            int mask_col = 0, mask_slash = 0, mask_back = 0;
            int result = 0;
            backtrack(0);
            return result;

            void backtrack(int rid)
            {
                if (rid < n)
                {
                    for (int cid = 0; cid < n; cid++)
                    {
                        if (((mask_col >> cid) & 1) == 0 && ((mask_slash >> rid - cid + n - 1) & 1) == 0 && ((mask_back >> rid + cid) & 1) == 0)
                        {
                            mask_col |= 1 << cid; mask_slash |= 1 << (rid - cid + n - 1); mask_back |= 1 << (rid + cid);
                            backtrack(rid + 1);
                            mask_col &= ~(1 << cid); mask_slash &= ~(1 << (rid - cid + n - 1)); mask_back &= ~(1 << (rid + cid));
                        }
                    }
                }
                else
                {
                    result++;
                }
            }
        }
    }
}

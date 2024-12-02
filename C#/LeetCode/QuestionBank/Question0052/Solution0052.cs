using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0052
{
    public class Solution0052 : Interface0052
    {
        /// <summary>
        /// 回溯
        /// 逻辑同Solution0051，更简单了，因为不需要记录每一步的位置
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int TotalNQueens(int n)
        {
            if (n == 1) return 1;

            bool[] mask_col = new bool[n], mask_slash = new bool[n * 2 - 1], mask_back = new bool[n * 2 - 1];
            int result = 0;
            backtrack(0);
            return result;

            void backtrack(int rid)
            {
                if (rid < n)
                {
                    for (int cid = 0; cid < n; cid++)
                    {
                        if (!mask_col[cid] && !mask_slash[rid - cid + n - 1] && !mask_back[rid + cid])
                        {
                            mask_col[cid] = mask_slash[rid - cid + n - 1] = mask_back[rid + cid] = true;
                            backtrack(rid + 1);
                            mask_col[cid] = mask_slash[rid - cid + n - 1] = mask_back[rid + cid] = false;
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

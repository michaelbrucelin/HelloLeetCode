using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0051
{
    public class Solution0051_2 : Interface0051
    {
        /// <summary>
        /// 回溯
        /// 逻辑完全同Solution0051，只是将其中的List改为数组+指针的形式，写着玩的
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public IList<IList<string>> SolveNQueens(int n)
        {
            if (n == 1) return [["Q"]];

            List<IList<string>> result = new List<IList<string>>();
            bool[] mask_col = new bool[n], mask_slash = new bool[n * 2 - 1], mask_back = new bool[n * 2 - 1];
            // List<(int rid, int cid)> buffer = new List<(int rid, int cid)>();
            // List<int> buffer = new List<int>();  // 只记录cid即可
            int[] buffer = new int[n]; int ptr = 0;
            backtrack(0);

            return result;

            void backtrack(int rid)
            {
                if (rid < n)
                {
                    for (int cid = 0; cid < n; cid++)
                    {
                        if (!mask_col[cid] && !mask_slash[rid + cid] && !mask_back[rid - cid + n - 1])
                        {
                            mask_col[cid] = mask_slash[rid + cid] = mask_back[rid - cid + n - 1] = true;
                            buffer[ptr++] = cid;
                            backtrack(rid + 1);
                            ptr--;
                            mask_col[cid] = mask_slash[rid + cid] = mask_back[rid - cid + n - 1] = false;
                        }
                    }
                }
                else
                {
                    List<string> _result = new List<string>();
                    foreach (int cid in buffer)
                    {
                        char[] chars = new char[n];
                        Array.Fill(chars, '.');
                        chars[cid] = 'Q';
                        _result.Add(new string(chars));
                    }
                    result.Add(_result);
                }
            }
        }
    }
}

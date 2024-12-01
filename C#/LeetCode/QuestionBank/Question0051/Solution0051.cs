using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0051
{
    public class Solution0051 : Interface0051
    {
        /// <summary>
        /// 回溯
        /// 经典的回溯问题，本质上就是DFS，但是传统的DFS需要维护太多的状态，使用回溯可以简化维护状态的代码以及空间复杂度
        /// 1. N个皇后一定在不同行，不同列，这个很容易判断，进而检查是不是在同一条斜线上即可
        /// 2. 先放第一个皇后在第一行，枚举每一个位置
        /// 3. 然后枚举第二个皇后（第二行）的位置
        /// 4. ... ...
        /// 技巧，使用bool[n]记录第n列有没有皇后
        ///       使用bool[2n-1]记录正斜线有没有皇后，id使用row_id + col_id
        ///       使用bool[2n-1]记录反斜线有没有皇后，id使用row_id - col_id + n - 1
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public IList<IList<string>> SolveNQueens(int n)
        {
            if (n == 1) return [["Q"]];

            List<IList<string>> result = new List<IList<string>>();
            bool[] mask_col = new bool[n], mask_slash = new bool[n * 2 - 1], mask_back = new bool[n * 2 - 1];
            // List<(int rid, int cid)> buffer = new List<(int rid, int cid)>();
            List<int> buffer = new List<int>();  // 只记录cid即可
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
                            buffer.Add(cid);
                            backtrack(rid + 1);
                            buffer.RemoveAt(rid);
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

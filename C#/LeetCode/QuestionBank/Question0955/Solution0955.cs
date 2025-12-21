using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0955
{
    public class Solution0955 : Interface0955
    {
        /// <summary>
        /// 贪心
        /// 从第1列开始，逐列比较，并记录下strs[i+1]与strs[i]的结果
        /// 假定比较到第k列
        ///     如果strs[i+1][k] > strs[i][k]，检查strs[i+1]与strs[i]的结果，
        ///         如果已经是true，表示前面的列已经决定了strs[i+1]与strs[i]的结果，忽略
        ///         如果是false，表示前面的列strs[i+1]与strs[i]相等，删除这一列，继续比较下一列
        ///             注意，比较下一列的时候，不需要从头开始比，从没比较出结果的第一行开始比较即可
        ///     如果strs[i+1][k] <= strs[i][k]，继续比较
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public int MinDeletionSize(string[] strs)
        {
            int result = 0, rcnt = strs.Length, ccnt = strs[0].Length;
            bool flag; int r0 = 1, _r0;
            bool[] flags = new bool[rcnt], _flags = new bool[rcnt];
            for (int c = 0; c < ccnt; c++)
            {
                flag = true; _r0 = r0;
                Array.Copy(flags, r0, _flags, r0, rcnt - r0);
                for (int r = r0; r < rcnt; r++)
                {
                    if (_flags[r])
                    {
                        if (flag) _r0 = r + 1;
                    }
                    else
                    {
                        switch (strs[r][c] - strs[r - 1][c])
                        {
                            case < 0: result++; goto DELCOL;
                            case > 0: _flags[r] = true; if (flag) _r0 = r + 1; break;
                            default: flag = false; break;
                        }
                    }
                }
                r0 = _r0;
                Array.Copy(_flags, r0, flags, r0, rcnt - r0);
            DELCOL:;
            }

            return result;
        }
    }
}

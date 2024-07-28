using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0699
{
    public class Solution0699_err : Interface0699
    {
        /// <summary>
        /// 线段树
        /// 逻辑基本上是对的，但是没有考虑到“擦边”落下的情况，参考测试用例02
        /// </summary>
        /// <param name="positions"></param>
        /// <returns></returns>
        public IList<int> FallingSquares(int[][] positions)
        {
            if (positions.Length == 1) return [positions[0][1]];

            int left = positions[0][0], right = positions[0][0] + positions[0][1], len = positions.Length;
            for (int i = 1; i < len; i++)
            {
                left = Math.Min(left, positions[i][0]); right = Math.Max(right, positions[i][0] + positions[i][1]);
            }

            int[] result = new int[len];
            int height = (int)Math.Ceiling(Math.Log(right - left + 1, 2));
            int n = (1 << (height + 1)) - 1;
            int[] segment = new int[n];
            for (int i = 0, l, r, max; i < len; i++)
            {
                l = positions[i][0]; r = positions[i][0] + positions[i][1];
                max = query(0, left, right, l, r) + positions[i][1];
                result[i] = max;
                update(0, left, right, l, r, max);
            }

            for (int i = 1; i < len; i++) result[i] = Math.Max(result[i], result[i - 1]);
            return result;

            int query(int pos, int rl, int rr, int tl, int tr)  // 在[rl, rr]中查找[tl, tr]
            {
                if (tl == rl && tr == rr) return segment[pos];

                int mid = rl + ((rr - rl) >> 1);
                if (tr <= mid)
                    return query((pos << 1) + 1, rl, mid, tl, tr);
                else if (tl >= mid + 1)
                    return query((pos + 1) << 1, mid + 1, rr, tl, tr);
                else
                    return Math.Max(query((pos << 1) + 1, rl, mid, tl, mid), query((pos + 1) << 1, mid + 1, rr, mid + 1, tr));
            }

            void update(int pos, int rl, int rr, int tl, int tr, int val)
            {
                segment[pos] = Math.Max(segment[pos], val);
                if (rl == rr) return;

                int mid = rl + ((rr - rl) >> 1);
                if (tr <= mid)
                    update((pos << 1) + 1, rl, mid, tl, tr, val);
                else if (tl >= mid + 1)
                    update((pos + 1) << 1, mid + 1, rr, tl, tr, val);
                else
                {
                    update((pos << 1) + 1, rl, mid, tl, mid, val);
                    update((pos + 1) << 1, mid + 1, rr, mid + 1, tr, val);
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1622
{
    public class Solution1622
    {
    }

    /// <summary>
    /// 模拟，延迟计算，懒更新
    /// 
    /// 提交竟然通过了，没有TLE... ...
    /// </summary>
    public class Fancy : Interface1622
    {
        public Fancy()
        {
            list = [];
            opts = [];
            seq = 0;
        }

        private const int MOD = (int)(1e9 + 7);
        private List<(int, int)> list;           // (val, seq)      val是seq次加入的
        private List<(byte, int, int)> opts;     // (+/*, val, seq) 0:+, 1:*
        private int seq;

        public void Append(int val)
        {
            list.Add((val, seq++));
        }

        public void AddAll(int inc)
        {
            opts.Add((0, inc, seq++));
        }

        public void MultAll(int m)
        {
            opts.Add((1, m, seq++));
        }

        public int GetIndex(int idx)
        {
            if (idx >= list.Count) return -1;

            long result = list[idx].Item1;
            int target = list[idx].Item2, start = opts.Count, lo = 0, hi = opts.Count - 1, mid;
            while (lo <= hi)
            {
                mid = lo + ((hi - lo) >> 1);
                if (opts[mid].Item3 > target)
                {
                    start = mid; hi = mid - 1;
                }
                else
                {
                    lo = mid + 1;
                }
            }

            int op, val, cnt = opts.Count;
            for (int i = start; i < cnt; i++)
            {
                (op, val, _) = opts[i];
                if (op == 0) result = (result + val) % MOD; else result = (result * val) % MOD;
            }

            list[idx] = ((int)result, seq++);  // 延迟计算 + 懒更新
            return (int)result;
        }
    }
}

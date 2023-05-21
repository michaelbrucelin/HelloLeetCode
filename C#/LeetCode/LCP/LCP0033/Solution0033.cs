using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCP.LCP0033
{
    public class Solution0033 : Interface0033
    {
        /// <summary>
        /// 数学 + 策略
        /// 具体分析见Solution0033.md
        /// </summary>
        /// <param name="bucket"></param>
        /// <param name="vat"></param>
        /// <returns></returns>
        public int StoreWater(int[] bucket, int[] vat)
        {
            int result = 0, len = bucket.Length;
            PriorityQueue<(int bucket, int vat, int cnt), int> maxpq = new PriorityQueue<(int bucket, int vat, int cnt), int>();
            for (int i = 0, cnt; i < len; i++)
            {
                if (vat[i] == 0) continue;
                if (bucket[i] == 0 && vat[i] > 0) { bucket[i] = 1; result++; }
                cnt = (int)Math.Ceiling(((double)vat[i]) / bucket[i]);
                maxpq.Enqueue((bucket[i], vat[i], cnt), -cnt);
            }
            if (maxpq.Count == 0) return 0;
            result += maxpq.Peek().cnt;

            while (maxpq.Peek().cnt > 1)
            {
                var t = maxpq.Dequeue();
                int cnt = t.cnt, upcnt;
                upcnt = Math.Ceiling(((double)t.vat) / (t.bucket + 1)) < cnt ? 1 : (int)Math.Ceiling(((double)t.vat) / (cnt - 1)) - t.bucket;
                if (upcnt >= result) goto EndLoop;
                int newcnt = (int)Math.Ceiling(((double)t.vat) / (t.bucket + upcnt));
                maxpq.Enqueue((t.bucket + upcnt, t.vat, newcnt), -newcnt);
                while (maxpq.Peek().cnt == cnt)
                {
                    var _t = maxpq.Dequeue();
                    int _upcnt = Math.Ceiling(((double)_t.vat) / (_t.bucket + 1)) < _t.cnt ? 1 : (int)Math.Ceiling(((double)_t.vat) / (_t.cnt - 1)) - _t.bucket;
                    upcnt += _upcnt;
                    if (upcnt >= result) goto EndLoop;
                    int _newcnt = (int)Math.Ceiling(((double)_t.vat) / (_t.bucket + _upcnt));
                    maxpq.Enqueue((_t.bucket + _upcnt, _t.vat, _newcnt), -_newcnt);
                }
                int change = cnt - maxpq.Peek().cnt - upcnt;
                if (change > 0) result -= change;
            }
            EndLoop:

            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0519
{
    public class Solution0519_off_1
    {
    }

    public class Solution_off_1
    {
        public Solution_off_1(int m, int n)
        {
            random = new Random();
            map = new Dictionary<int, int>();
            (this.m, this.n, total) = (m, n, m * n);
            cnt = total;
        }

        private Random random;
        private Dictionary<int, int> map;
        private int m, n, total, cnt;

        public int[] Flip()
        {
            int idx = random.Next(cnt);
            int point = idx;
            if (map.TryGetValue(idx, out int x)) point = x;
            int _point = cnt - 1;
            if (map.TryGetValue(cnt - 1, out x)) _point = x;
            // if (map.ContainsKey(idx)) map[idx] = _point; else map.Add(idx, _point);
            if (!map.TryAdd(idx, _point)) map[idx] = _point;
            cnt--;

            return [point / n, point % n];
        }

        public void Reset()
        {
            map.Clear();
            cnt = total;
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2975
{
    public class Solution2975 : Interface2975
    {
        /// <summary>
        /// 贪心
        /// 找出横向与纵向共同的宽度中的最大值即可
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <param name="hFences"></param>
        /// <param name="vFences"></param>
        /// <returns></returns>
        public int MaximizeSquareArea2(int m, int n, int[] hFences, int[] vFences)
        {
            List<int> _hFences = [1, m, .. hFences], _vFences = [1, n, .. vFences];
            _hFences.Sort();
            _vFences.Sort();
            HashSet<int> hset = [], vset = [];

            int cnt = _hFences.Count;
            for (int i = 0; i < cnt; i++) for (int j = i + 1; j < cnt; j++) hset.Add(_hFences[j] - _hFences[i]);
            cnt = _vFences.Count;
            for (int i = 0; i < cnt; i++) for (int j = i + 1; j < cnt; j++) vset.Add(_vFences[j] - _vFences[i]);

            HashSet<int> less, more;  // 小驱动大
            if (hset.Count <= vset.Count) (less, more) = (hset, vset); else (less, more) = (vset, hset);
            cnt = 0;
            foreach (int l in less) if (more.Contains(l)) cnt = Math.Max(cnt, l);
            if (cnt == 0) return -1;

            const int MOD = (int)1e9 + 7;
            return (int)(1L * cnt * cnt % MOD);
        }

        /// <summary>
        /// 逻辑同MaximizeSquareArea()，移除排序，前面想多了，排序没什么用
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <param name="hFences"></param>
        /// <param name="vFences"></param>
        /// <returns></returns>
        public int MaximizeSquareArea(int m, int n, int[] hFences, int[] vFences)
        {
            HashSet<int> hset = [m - 1], vset = [n - 1];

            int len = hFences.Length;
            for (int i = 0; i < len; i++)
            {
                hset.Add(hFences[i] - 1); hset.Add(m - hFences[i]);
                for (int j = i + 1; j < len; j++) hset.Add(Math.Abs(hFences[j] - hFences[i]));
            }
            len = vFences.Length;
            for (int i = 0; i < len; i++)
            {
                vset.Add(vFences[i] - 1); vset.Add(n - vFences[i]);
                for (int j = i + 1; j < len; j++) vset.Add(Math.Abs(vFences[j] - vFences[i]));
            }

            HashSet<int> less, more;  // 小驱动大
            if (hset.Count <= vset.Count) (less, more) = (hset, vset); else (less, more) = (vset, hset);
            len = 0;
            foreach (int l in less) if (more.Contains(l)) len = Math.Max(len, l);
            if (len == 0) return -1;

            const int MOD = (int)1e9 + 7;
            return (int)(1L * len * len % MOD);
        }
    }
}

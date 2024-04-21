using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0216
{
    public class Solution0216 : Interface0216
    {
        /// <summary>
        /// 状态压缩
        /// 二进制枚举
        /// </summary>
        /// <param name="k"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public IList<IList<int>> CombinationSum3(int k, int n)
        {
            int min = (k * (k + 1)) >> 1, max = (k * (19 - k)) >> 1;
            if (n < min || n > max) return new List<IList<int>>();
            if (n == min) return new List<IList<int>>() { Enumerable.Range(1, k).ToList() };
            if (n == max) return new List<IList<int>>() { Enumerable.Range(8 - k, k).ToList() };

            List<IList<int>> result = new List<IList<int>>();
            int kset = (1 << k) - 1, limit = 1 << 9, c, r, _kset, _pos, _sum;
            while (kset < limit)
            {
                _kset = kset; _pos = 1; _sum = 0;
                List<int> _list = new List<int>();
                while (_kset > 0)
                {
                    if ((_kset & 1) == 1) { _list.Add(_pos); _sum += _pos; }
                    _kset >>= 1; _pos++;
                }
                if (_sum == n) result.Add(_list);

                c = kset & -kset;
                r = kset + c;
                kset = (((r ^ kset) >> 2) / c) | r;
            }

            return result;
        }
    }
}

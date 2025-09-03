using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0077
{
    public class Solution0077_2 : Interface0077
    {
        /// <summary>
        /// 二进制枚举
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public IList<IList<int>> Combine2(int n, int k)
        {
            List<IList<int>> result = new List<IList<int>>();

            int kset = (1 << k) - 1, limit = 1 << n, c, r, _kset, i;
            while (kset < limit)
            {
                _kset = kset; i = 0;
                List<int> list = [];
                while (_kset > 0)
                {
                    i++;
                    if ((_kset & 1) == 1) list.Add(i);
                    _kset >>= 1;
                }
                result.Add(list);

                c = kset & -kset;
                r = kset + c;
                kset = (((r ^ kset) >> 2) / c) | r;
            }

            return result;
        }

        /// <summary>
        /// 逻辑同Combine()，稍加优化
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public IList<IList<int>> Combine(int n, int k)
        {
            List<IList<int>> result = new List<IList<int>>();

            int kset = (1 << k) - 1, limit = 1 << n, c, r, _kset, i;
            while (kset < limit)
            {
                _kset = kset;
                List<int> list = [];
                while (_kset > 0)
                {
                    i = BitOperations.TrailingZeroCount(_kset);
                    list.Add(i + 1);
                    _kset &= _kset - 1;
                }
                result.Add(list);

                c = kset & -kset;
                r = kset + c;
                kset = (((r ^ kset) >> 2) / c) | r;
            }

            return result;
        }
    }
}

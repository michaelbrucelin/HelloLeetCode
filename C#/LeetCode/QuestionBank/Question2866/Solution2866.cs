using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2866
{
    public class Solution2866 : Interface2866
    {
        /// <summary>
        /// 贪心
        /// 1. 创建 1-n 的id数组ids，排序：maxHeights值降序, id升序
        ///     这时ids中的值的顺序，就是maxHeights数组值的降序
        /// 2. 依次取maxHeights最大值，次大值，第3大值...第k大值作为峰值求对应的结果
        ///     如果第k大值*n <= 当前结果，结束
        /// 3. 在计算第k大值为峰值的结果时，由于越远离k的值越小，所以也可以提前剪枝，进行第k+1大值的计算
        ///     这里没有实现
        /// 
        /// 逻辑没问题，提交会TLE，参考测试用例05
        /// </summary>
        /// <param name="maxHeights"></param>
        /// <returns></returns>
        public long MaximumSumOfHeights(IList<int> maxHeights)
        {
            long len = maxHeights.Count;
            int[] ids = new int[len];
            for (int i = 0; i < len; i++) ids[i] = i;
            Array.Sort(ids, (i, j) => maxHeights[i] != maxHeights[j] ? maxHeights[j] - maxHeights[i] : i - j);

            long result = 0, _result;
            for (int id = 0, i, _limit; id < len; id++)
            {
                if (maxHeights[i = ids[id]] * len <= result) break;
                _result = maxHeights[i];

                _limit = maxHeights[i];
                for (int j = i - 1; j >= 0; j--)
                {
                    _limit = Math.Min(_limit, maxHeights[j]); _result += _limit;
                }
                _limit = maxHeights[i];
                for (int j = i + 1; j < len; j++)
                {
                    _limit = Math.Min(_limit, maxHeights[j]); _result += _limit;
                }
                result = Math.Max(result, _result);
            }

            return result;
        }

        /// <summary>
        /// 贪心
        /// 逻辑同MaximumSumOfHeights()，将第3点中的剪枝优化实现了
        /// 依然很慢，没有提交测试
        /// </summary>
        /// <param name="maxHeights"></param>
        /// <returns></returns>
        public long MaximumSumOfHeights2(IList<int> maxHeights)
        {
            long len = maxHeights.Count;
            int[] ids = new int[len];
            for (int i = 0; i < len; i++) ids[i] = i;
            Array.Sort(ids, (i, j) => maxHeights[i] != maxHeights[j] ? maxHeights[j] - maxHeights[i] : i - j);

            long result = 0, _result, _id_l, _id_r, _limit_l, _limit_r;
            for (int id = 0, i; id < len; id++)
            {
                if (maxHeights[i = ids[id]] * len <= result) break;
                _result = maxHeights[i];

                _limit_l = _limit_r = maxHeights[i]; _id_l = i - 1; _id_r = i + 1;
                while (_id_l >= 0 || _id_r < len)
                {
                    _limit_l = _id_l >= 0 ? Math.Min(_limit_l, maxHeights[(int)_id_l]) : 0;
                    _limit_r = _id_r < len ? Math.Min(_limit_r, maxHeights[(int)_id_r]) : 0;
                    if (_result + _limit_l * (_id_l + 1) + _limit_r * (len - _id_r) > result)
                        _result += _limit_l + _limit_r;
                    _id_l--; _id_r++;
                }
                result = Math.Max(result, _result);
            }

            return result;
        }
    }
}

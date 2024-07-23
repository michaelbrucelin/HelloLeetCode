using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3098
{
    public class Solution3098 : Interface3098
    {
        /// <summary>
        /// 暴力枚举
        /// 1. 由于是子序列，所以可以先排序，这样绝对值最小值一定发生在相邻的元素上
        /// 2. 然后使用二进制枚举来遍历全部的子序列
        /// 
        /// 由于题目限定nums最多有50个元素，这样最大的子序列数量为C(50, 25) = 126,410,606,437,752
        /// 所以此解法必然TLE，先写出来看看，再想其它的解法
        /// 
        /// 逻辑没问题，意料之中的TLE，参考测试用例04
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int SumOfPowers(int[] nums, int k)
        {
            Array.Sort(nums);
            const int MOD = (int)1e9 + 7;

            int result = 0, i, j, cnt, _result, n = nums.Length;
            long kset = (1L << k) - 1, limit = 1L << n, c, r;
            while (kset < limit)
            {
                _result = int.MaxValue;
                for (j = 0; ; j++) if (((kset >> j) & 1) == 1) break;
                for (i = j + 1, cnt = 1; cnt < k; i++) if (((kset >> i) & 1) == 1)
                    {
                        _result = Math.Min(_result, nums[i] - nums[j]);
                        j = i; cnt++;
                    }
                result = (result + _result) % MOD;

                c = kset & -kset;
                r = kset + c;
                kset = (((r ^ kset) >> 2) / c) | r;
            }

            return result;
        }
    }
}

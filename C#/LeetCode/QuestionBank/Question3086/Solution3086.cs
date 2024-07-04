using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3086
{
    public class Solution3086 : Interface3086
    {
        /// <summary>
        /// 暴力解
        /// 先暴力求解，必然会TLE，然后再优化
        /// 1. 如果选择的位置为1，k-1
        /// 2. 如果change > 0，每行动2次，k-1
        /// 3. 如果相距x个位置为1，行动x次，k-1
        /// 题目限定一定有解，贪心的话，按照下面策略，假定选择的位置为idx
        /// 1. 如果nums[idx] == 1, k-1
        /// 2. 如果idx-1或idx+1位置，即相邻位置为1，优先获取
        /// 3. 如果change > 0，优先获取
        /// 4. 最后再获取更远位置的1
        /// 显然，需要优化的就是第4步
        /// 
        /// 逻辑没问题，意料之中的TLE，参考测试用例04
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <param name="maxChanges"></param>
        /// <returns></returns>
        public long MinimumMoves(int[] nums, int k, int maxChanges)
        {
            long result = long.MaxValue, _result;
            int _k, len = nums.Length;
            for (int i = 0; i < len; i++)
            {
                _result = 0; _k = k;
                if (nums[i] == 1) { if (--_k == 0) goto CONTINUE; }
                if (i - 1 >= 0 && nums[i - 1] == 1) { _result++; if (--_k == 0) goto CONTINUE; }
                if (i + 1 < len && nums[i + 1] == 1) { _result++; if (--_k == 0) goto CONTINUE; }
                if (maxChanges >= _k) { _result += _k << 1; goto CONTINUE; }

                _result += maxChanges << 1;
                _k -= maxChanges;
                for (int j = 2; _k > 0; j++)
                {
                    if (i - j >= 0 && nums[i - j] == 1) { _result += j; if (--_k == 0) goto CONTINUE; }
                    if (i + j < len && nums[i + j] == 1) { _result += j; if (--_k == 0) goto CONTINUE; }
                }

                CONTINUE:;
                result = Math.Min(result, _result);
            }

            return result;
        }
    }
}

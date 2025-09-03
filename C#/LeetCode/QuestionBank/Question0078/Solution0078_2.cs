using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0078
{
    public class Solution0078_2 : Interface0078
    {
        /// <summary>
        /// 二进制枚举
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> Subsets(int[] nums)
        {
            List<IList<int>> result = new List<IList<int>>();
            int limit = 1 << nums.Length;
            for (int i = 0, _i, j; i < limit; i++)
            {
                List<int> list = [];
                _i = i;
                while (_i > 0)
                {
                    j = BitOperations.TrailingZeroCount(_i);
                    list.Add(nums[j]);
                    _i &= _i - 1;
                }

                result.Add(list);
            }

            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0698
{
    public class Solution0698_2 : Interface0698
    {
        /// <summary>
        /// 枚举
        /// n个元素分为k个非空子集，共有n(n-1)...(n-k+1)k^(n-k)种可能
        ///     这个公式会比真实的可能性大，因为有重复，这里是要计算上限，所以有重复没有影响
        ///     准确的计算公式应该是斯特林（Stirling）数
        ///     计算的结果大的离谱，    n = 16, k = 10: 29059430400000000
        /// 计算准确的Stirling值也很大，n = 16, k = 7:  3281882604
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public bool CanPartitionKSubsets(int[] nums, int k)
        {
            if (k == 1) return true;
            int sum = nums.Sum();
            if (sum % k != 0) return false;
            int tar = sum / k;
            if (nums.Any(x => x > tar)) return false;

            return true;
        }
    }
}

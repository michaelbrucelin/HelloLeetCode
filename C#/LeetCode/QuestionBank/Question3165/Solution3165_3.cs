using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3165
{
    public class Solution3165_3 : Interface3165
    {
        /// <summary>
        /// 分治
        /// 首先，将数组用其中小于等于0的元素，分隔为若干子数组，那么整个数组的最大值 = 所有子数组最大值的和
        /// 每次查询时，更改一个值，可能将1个子数组分为2个更小的子数组
        ///                         可能将2个子数组合为1个更大的子数组
        ///                         或者子数组不变
        /// 那么每次只要重新计算发生变化的子数组即可。
        /// 计算变化的数组时，发生变化前面的位置不需要重新dp，后面的位置需要重新dp，理论上后面的位置如果出现连续两个位置的值与上一轮dp的值的差相等，那么后面的差也一定相等。
        /// 
        /// 没有实现，如果数组的值全部大于0，每次查询变更后的值也全部大于0，退化为暴力查询。
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="queries"></param>
        /// <returns></returns>
        public int MaximumSumSubsequence(int[] nums, int[][] queries)
        {
            throw new NotImplementedException();
        }
    }
}

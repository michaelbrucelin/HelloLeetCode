using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3691
{
    public class Solution3691 : Interface3691
    {
        /// <summary>
        /// 贪心(贡献法) + 稀疏表 + Hash
        /// 1. 按照数组中值将索引排序，例如
        ///     nums = [1,3,2], 索引数组排序为 [0,1,2] --> [0,2,1]
        ///     这样使用双指针可以贪心的从大到小找出(max-min)的区间
        /// 2. 第1轮，没有问题，第2轮时需要验证子数组的最大值及最小值是否真的是双指针枚举的值
        ///     使用稀疏表快速查询区间的最大值及最小值
        ///     使用Hash快速判断是否是重复获取
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public long MaxTotalValue(int[] nums, int k)
        {
            throw new NotImplementedException();
        }
    }
}

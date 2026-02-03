using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3640
{
    public class Solution3640 : Interface3640
    {
        /// <summary>
        /// 多轮遍历
        /// 如果找出一个最长的三段式子数组，那么
        ///     第1段，取和最大的后缀子数组
        ///     第2段，和不变
        ///     第3段，取和最大的前缀子数组
        /// 基于上面思路，制定下面解题过程，有些轮的遍历可以合并为1轮，那都是编码技巧了，这里只描述思路过程
        /// 1. 遍历，预处理出前缀和
        /// 2. 遍历，找出所有的严格递增区间与严格递减区间
        /// 3. 遍历，找出递增区间的和最大的前缀，只记录位置就可以（有前缀和）
        /// 3. 遍历，找出递增区间的和最大的后缀，只记录位置就可以（有前缀和）
        /// 4. 遍历，找最终结果
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public long MaxSumTrionic(int[] nums)
        {
            throw new NotImplementedException();
        }
    }
}

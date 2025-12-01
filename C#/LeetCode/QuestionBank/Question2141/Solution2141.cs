using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2141
{
    public class Solution2141 : Interface2141
    {
        /// <summary>
        /// 贪心
        /// batteries.Sum()/n 是不对的，例如 n=3, [10,10,8]，结果是8而不是9，因为8分钟后电池不够用了
        /// 所以，如果电池数量小于电脑数量，结果为0
        ///       如果电池数量等于电脑数量，结果为batteries的最小值
        ///       如果电池数量大于电脑数量，将数组的某些项拆开合并到其他项上，让数组的长度为n，且最小值最大即可
        ///           问题是拆哪些项，怎样拆
        /// </summary>
        /// <param name="n"></param>
        /// <param name="batteries"></param>
        /// <returns></returns>
        public long MaxRunTime(int n, int[] batteries)
        {
            if (batteries.Length == n) return batteries.Min();  // 题目限定n<=len

            throw new NotImplementedException();
        }
    }
}

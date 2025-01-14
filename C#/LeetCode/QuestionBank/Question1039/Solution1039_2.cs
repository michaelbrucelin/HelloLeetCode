using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1039
{
    public class Solution1039_2 : Interface1039
    {
        /// <summary>
        /// DFS + 状态压缩 + 记忆化搜索
        /// 无论怎样切，最后都相当于：
        ///     每次选连续的3个元素构成一个三角形，计算得分，然后移除中3个点中中间的的点
        ///     重复上面的操作直至只剩下2个点
        /// 题目限定最多50个点，所以可以将状态压缩为一个long来表示
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public int MinScoreTriangulation(int[] values)
        {
            throw new NotImplementedException();
        }
    }
}

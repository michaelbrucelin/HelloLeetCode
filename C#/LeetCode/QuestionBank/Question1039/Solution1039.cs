﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1039
{
    public class Solution1039 : Interface1039
    {
        /// <summary>
        /// 贪心，没证明
        /// 无论怎样切，最后都相当于：
        ///     每次选连续的3个元素构成一个三角形，计算得分，然后移除中3个点中中间的的点
        ///     重复上面的操作直至只剩下2个点
        /// 优先级队列，每次移除最大的点
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public int MinScoreTriangulation(int[] values)
        {
            throw new NotImplementedException();
        }
    }
}

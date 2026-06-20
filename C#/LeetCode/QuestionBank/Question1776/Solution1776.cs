using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1776
{
    public class Solution1776 : Interface1776
    {
        /// <summary>
        /// 单调栈 + 二分查找
        /// 1. 车辆按照位置排序，题目已经排好序了
        /// 2. 倒序遍历，如果一辆车的速度小于等于右边车的速度，则右边车相当于不存在，因为永远追不上或者直接追上再右边的车，单调栈
        /// 3. 当前右边有N辆车，速度单调递减，当前车速度大于右边N辆车的第一辆，下，现在需要计算这辆车什么时候追上后面的车
        ///     
        /// </summary>
        /// <param name="cars"></param>
        /// <returns></returns>
        public double[] GetCollisionTimes(int[][] cars)
        {
            throw new NotImplementedException();
        }
    }
}

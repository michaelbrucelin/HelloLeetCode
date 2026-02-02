using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0189
{
    public class Solution0189 : Interface0189
    {
        /// <summary>
        /// 递归？
        /// 想不到不用循环与乘法的解法了，这里用递归代替循环，但是用递归也需要用判断... ...
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public int MechanicalAccumulator(int target)
        {
            return target != 0 ? target + MechanicalAccumulator(target - 1) : 0;
        }
    }
}

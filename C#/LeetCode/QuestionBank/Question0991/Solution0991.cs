using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0991
{
    public class Solution0991 : Interface0991
    {
        /// <summary>
        /// 贪心
        /// 如果 start >= target，则 start - target
        /// 如果 start >= (target+1)/2，则比较 start * 2 - target + 1 与 start - (target+1)/2 + 1 + (target&1)
        /// 如果 start <  (target+1)/2，更新目标为 (target+1)/2
        /// 
        /// 没有证明这个贪心以严谨的
        /// </summary>
        /// <param name="startValue"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int BrokenCalc(int startValue, int target)
        {
            if (startValue >= target) return startValue - target;
            int _target = (target + 1) >> 1;
            if (startValue >= _target) return Math.Min((startValue << 1) - target, startValue - _target + (target & 1)) + 1;

            return BrokenCalc(startValue, _target) + 1 + (target & 1);
        }
    }
}

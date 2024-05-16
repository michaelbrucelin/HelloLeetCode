using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1953
{
    public class Solution1953_err2 : Interface1953
    {
        /// <summary>
        /// 贪心，类摩尔投票找众数
        /// 逻辑同Solution1953_err，但是做了调整
        /// 1. 找出最大的max，继续找出x1, x2,...xn，使 max-x1-x2-...-xn-1 小于余下最大的值，将余下的 max-x1-x2-...-xn-1 放回去
        ///     max-x1-x2-...-xn-1 一定不是最大值
        /// 2. 重复1
        /// 
        /// 逻辑依然使错误的，参考测试用例04
        /// </summary>
        /// <param name="milestones"></param>
        /// <returns></returns>
        public long NumberOfWeeks(int[] milestones)
        {
            if (milestones.Length == 1) return 1;
            if (milestones.Length == 2)
            {
                return milestones[0] == milestones[1] ? milestones[0] << 1 : (Math.Min(milestones[0], milestones[1]) << 1) + 1;
            }

            long result = 0; int first, second; bool flag = true;
            PriorityQueue<int, int> maxpq = new PriorityQueue<int, int>();
            foreach (int milestone in milestones) maxpq.Enqueue(milestone, -milestone);
            while (maxpq.Count > 1)
            {
                flag = true; first = maxpq.Dequeue(); second = maxpq.Dequeue();
                while (maxpq.Count > 0 && first - second - 1 >= maxpq.Peek()) second += maxpq.Dequeue();
                if (first > second)
                {
                    result += (second << 1) + 1;
                    if (first > second + 1)
                    {
                        maxpq.Enqueue(first - second - 1, 1 + second - first);
                        flag = false;
                    }
                }
                else  // if (first == second)
                {
                    result += second << 1;
                }
            }
            if (flag && maxpq.Count > 0) result++;

            return result;
        }
    }
}

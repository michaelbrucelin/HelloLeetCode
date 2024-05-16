using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1953
{
    public class Solution1953_err : Interface1953
    {
        /// <summary>
        /// 贪心，类摩尔投票找众数
        /// 1. 找出最多的两个 x, y(x>=y)，干 2y 天，将余下的 x-y 放回去
        /// 2. 重复1
        /// 
        /// 逻辑是错误的，参考测试用例03
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

            long result = 0; int first, second;
            PriorityQueue<int, int> maxpq = new PriorityQueue<int, int>();
            foreach (int milestone in milestones) maxpq.Enqueue(milestone, -milestone);
            while (maxpq.Count > 1)
            {
                first = maxpq.Dequeue(); second = maxpq.Dequeue();
                result += second << 1;
                if (first > second) maxpq.Enqueue(first - second, second - first);
            }
            if (maxpq.Count > 0) result++;

            return result;
        }
    }
}

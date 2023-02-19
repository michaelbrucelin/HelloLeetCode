using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1792
{
    public class Solution1792 : Interface1792
    {
        /// <summary>
        /// 贪心法
        /// 一个人一个人的添加，每次都把人加到提高通过率最大的班级
        /// 借助优先级队列来实现，优先级是增加一个人后增加的通过率，即(pass+1)/(total+1)-pass/total
        /// 
        /// 规律是(pass+1)/(total+1)-pass/total，感觉应该有没有数学解，但是没找到
        /// </summary>
        /// <param name="classes"></param>
        /// <param name="extraStudents"></param>
        /// <returns></returns>
        public double MaxAverageRatio(int[][] classes, int extraStudents)
        {
            PriorityQueue<(int, int), double> queue = new PriorityQueue<(int, int), double>(Comparer<double>.Create((d1, d2) => (d2 - d1) switch { > 0 => 1, < 0 => -1, _ => 0 }));
            for (int i = 0; i < classes.Length; i++)
            {
                int pass = classes[i][0], total = classes[i][1];
                queue.Enqueue((pass, total), (((double)pass) + 1) / (total + 1) - ((double)pass) / total);
            }

            if (queue.Peek().Item1 == queue.Peek().Item2) return 1;

            for (int i = 0; i < extraStudents; i++)
            {
                var item = queue.Dequeue();
                int pass = item.Item1 + 1, total = item.Item2 + 1;
                queue.Enqueue((pass, total), (((double)pass) + 1) / (total + 1) - ((double)pass) / total);
            }

            double score = 0;
            while (queue.Count > 0)
            {
                var item = queue.Dequeue();
                score += ((double)item.Item1) / item.Item2;
            }

            return score / classes.Length;
        }
    }
}

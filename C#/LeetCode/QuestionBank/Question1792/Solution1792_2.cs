using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1792
{
    public class Solution1792_2 : Interface1792
    {
        /// <summary>
        /// 贪心，大顶堆
        /// 每次将人分配给通过率增长更大的班级
        /// </summary>
        /// <param name="classes"></param>
        /// <param name="extraStudents"></param>
        /// <returns></returns>
        public double MaxAverageRatio(int[][] classes, int extraStudents)
        {
            PriorityQueue<int[], double> maxpq = new PriorityQueue<int[], double>();
            foreach (int[] arr in classes) maxpq.Enqueue(arr, 1D * arr[0] / arr[1] - 1D * (arr[0] + 1) / (arr[1] + 1));
            while (extraStudents-- > 0)
            {
                int[] item = maxpq.Dequeue();
                item[0] += 1; item[1] += 1;
                maxpq.Enqueue(item, 1D * item[0] / item[1] - 1D * (item[0] + 1) / (item[1] + 1));
            }

            double point = 0, cnt = classes.Length;
            while (maxpq.Count > 0)
            {
                int[] item = maxpq.Dequeue();
                point += 1D * item[0] / item[1];
            }
            return point / cnt;
        }
    }
}

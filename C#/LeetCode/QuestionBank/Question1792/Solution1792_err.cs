using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1792
{
    public class Solution1792_err : Interface1792
    {
        /// <summary>
        /// 贪心，小顶堆
        /// 
        /// 贪心不应该每次都把人添加到通过率最低的班级，而应该添加到通过率增长更大的班级，参考测试用例01
        /// </summary>
        /// <param name="classes"></param>
        /// <param name="extraStudents"></param>
        /// <returns></returns>
        public double MaxAverageRatio(int[][] classes, int extraStudents)
        {
            PriorityQueue<int[], double> minpq = new PriorityQueue<int[], double>();
            foreach (int[] arr in classes) minpq.Enqueue(arr, 1D * arr[0] / arr[1]);
            while (extraStudents-- > 0)
            {
                int[] item = minpq.Dequeue();
                item[0] += 1; item[1] += 1;
                minpq.Enqueue(item, 1D * item[0] / item[1]);
            }

            double point = 0, cnt = classes.Length;
            while (minpq.Count > 0)
            {
                int[] item = minpq.Dequeue();
                point += 1D * item[0] / item[1];
            }
            return point / cnt;
        }
    }
}

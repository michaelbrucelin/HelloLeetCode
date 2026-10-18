using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0519
{
    public class Solution0519
    {
    }

    /// <summary>
    /// 分类讨论
    /// 题目限定最多1000次随机，所以这里采用当总数<=10W时，将所有项放链表中，然后随机，否则，拒绝采样随机
    /// </summary>
    public class Solution : Interface0519
    {
        public Solution(int m, int n)
        {
            random = new Random();
            points = [];
            visited = [];
            (this.m, this.n, total) = (m, n, m * n);
            Reset();
        }

        private Random random;
        private List<int> points;
        private HashSet<int> visited;
        private int m, n, total;
        private const int LIMIT = 100000;

        public int[] Flip()
        {
            int point;
            if (total <= LIMIT)
            {
                int cnt = points.Count;
                int idx = random.Next(points.Count);
                point = points[idx];
                points[idx] = points[cnt - 1];
                points.RemoveAt(cnt - 1);
            }
            else
            {
                do { point = random.Next(total); } while (visited.Contains(point));
                visited.Add(point);
            }

            return [point / n, point % n];
        }

        public void Reset()
        {
            points.Clear();
            visited.Clear();
            if (total <= LIMIT) for (int i = 0; i < total; i++) points.Add(i);
        }
    }
}

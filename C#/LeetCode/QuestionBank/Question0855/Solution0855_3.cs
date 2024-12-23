using LeetCode.QuestionBank.Question1000;
using LeetCode.QuestionBank.Question1114;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0855
{
    public class Solution0855_3
    {
    }

    public class ExamRoom_3 : Interface0855
    {
        /// <summary>
        /// 堆
        /// 堆中存放空位区间
        /// 
        /// 意料之外的双百
        /// </summary>
        /// <param name="n"></param>
        public ExamRoom_3(int n)
        {
            this.n = n;
            Comparer<(int l, int r)> comparer = Comparer<(int l, int r)>.Create((t1, t2) =>
            {
                int d1 = (t1.l == 0 || t1.r == n - 1) ? t1.r - t1.l : (t1.r - t1.l) / 2;
                int d2 = (t2.l == 0 || t2.r == n - 1) ? t2.r - t2.l : (t2.r - t2.l) / 2;
                return d1 != d2 ? d2 - d1 : t1.l - t2.l;
            });
            queue = new PriorityQueue<(int l, int r), (int l, int r)>(comparer);
            queue.Enqueue((0, n - 1), (0, n - 1));
            buffer = new List<(int l, int r)>();
        }

        private int n;
        private PriorityQueue<(int l, int r), (int l, int r)> queue;
        private List<(int l, int r)> buffer;

        public void Leave(int p)
        {
            int l = p, r = p;
            (int l, int r) item;
            bool find_l = true, find_r = true;
            while (queue.Count > 0 && (find_l || find_r))
            {
                item = queue.Dequeue();
                if (item.r == p - 1)
                {
                    l = item.l; find_l = false;
                }
                else if (item.l == p + 1)
                {
                    r = item.r; find_r = false;
                }
                else
                {
                    buffer.Add(item);
                }
            }
            queue.Enqueue((l, r), (l, r));
            for (int i = buffer.Count - 1; i >= 0; i--)
            {
                queue.Enqueue(buffer[i], buffer[i]); buffer.RemoveAt(i);
            }
        }

        public int Seat()
        {
            int seat;
            (int l, int r) range = queue.Dequeue();
            if (range.l == 0) seat = 0; else if (range.r == n - 1) seat = n - 1; else seat = range.l + (range.r - range.l) / 2;
            if (seat > range.l) queue.Enqueue((range.l, seat - 1), (range.l, seat - 1));
            if (seat < range.r) queue.Enqueue((seat + 1, range.r), (seat + 1, range.r));
            return seat;
        }
    }
}

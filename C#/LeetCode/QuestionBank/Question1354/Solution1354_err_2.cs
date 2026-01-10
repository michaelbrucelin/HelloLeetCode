using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1354
{
    public class Solution1354_err_2 : Interface1354
    {
        /// <summary>
        /// 贪心 + 模拟 + 堆
        /// 逻辑同Solution1354，做了下面几点优化
        /// 1. 用乘法代替加法
        /// 2. 如果target中有相等的值（1不算），一定无解，可以剪枝，这里没有排序，直接使用小顶堆，所以没有实现这一点
        /// 
        /// 逻辑错了，参考测试用例07
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool IsPossible(int[] target)
        {
            if (target.Length == 1) return target[0] == 1;

            int sum = target.Length;
            PriorityQueue<int, int> srcpq = new PriorityQueue<int, int>();
            PriorityQueue<int, int> tgtpq = new PriorityQueue<int, int>();
            foreach (int num in target) if (num != 1)
                {
                    if (num < sum) return false;
                    tgtpq.Enqueue(num, num);
                    srcpq.Enqueue(1, 1);
                }

            int tgt, src, inc, src_next;
            while (tgtpq.Count > 0)
            {
                tgt = tgtpq.Dequeue();
                src = srcpq.Dequeue();
                inc = sum - src;
                if (srcpq.Count > 0)
                {
                    src_next = srcpq.Peek();
                    if (tgt == src_next) return false;
                    src_next = src + ((src_next - src) / inc + 1) * inc;
                    if (tgt <= src_next)  // 一直调整同一个堆顶
                    {
                        if ((tgt - src) % inc != 0) return false;
                        sum += tgt - src;
                    }
                    else                  // 需要换堆顶
                    {
                        sum += src_next - src;
                        tgtpq.Enqueue(tgt, tgt);
                        srcpq.Enqueue(src_next, src_next);
                    }
                }
                else
                {
                    return (tgt - src) % inc == 0;
                }
            }

            return true;
        }
    }
}

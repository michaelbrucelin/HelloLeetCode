using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1354
{
    public class Solution1354_err : Interface1354
    {
        /// <summary>
        /// 贪心 + 模拟 + 堆
        /// 由于每次操作之后，整个数组的和都会变大，所以如果有解，那必须先操作最小的元素
        /// 借助小顶堆选择最小的元素
        /// 
        /// TLE，参考测试用例04
        /// 不但TLE，逻辑也是错的，参考测试用例07
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

            int tgt, src;
            while (tgtpq.Count > 0)
            {
                tgt = tgtpq.Dequeue();
                while (srcpq.Peek() < tgt)
                {
                    src = srcpq.Dequeue();
                    (src, sum) = (sum, sum + sum - src);
                    srcpq.Enqueue(src, src);
                }
                if (srcpq.Dequeue() != tgt) return false;
            }

            return true;
        }
    }
}

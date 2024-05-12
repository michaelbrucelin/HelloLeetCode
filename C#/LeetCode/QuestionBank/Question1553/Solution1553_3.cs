using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1553
{
    public class Solution1553_3 : Interface1553
    {
        /// <summary>
        /// 将Solution1553_2中的递归1:1翻译为迭代
        /// 
        /// 提交TLE，参考测试用例07
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int MinDays(int n)
        {
            if (n < 3) return n;

            int[] memory = new int[n + 1];
            memory[1] = 1;
            memory[2] = 2;
            Stack<int> stack = new Stack<int>();
            Queue<int> queue = new Queue<int>();
            stack.Push(n);
            int _n, rec; bool flag;
            while (stack.Count > 0)
            {
                if (memory[_n = stack.Pop()] > 0) continue;

                rec = _n; flag = true; queue.Enqueue(_n);
                if (memory[_n - 1] > 0) rec = memory[_n - 1]; else { flag = false; queue.Enqueue(_n - 1); }
                if ((_n & 1) == 0)
                {
                    if (memory[_n >> 1] > 0) rec = Math.Min(rec, memory[_n >> 1]); else { flag = false; queue.Enqueue(_n >> 1); }
                }
                if ((_n % 3) == 0)
                {
                    if (memory[_n / 3] > 0) rec = Math.Min(rec, memory[_n / 3]); else { flag = false; queue.Enqueue(_n / 3); }
                }

                if (flag) memory[_n] = rec + 1; else while (queue.Count > 0) stack.Push(queue.Dequeue());
            }

            return memory[n];
        }
    }
}

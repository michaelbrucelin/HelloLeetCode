using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2600
{
    public class Solution2600_2 : Interface2600
    {
        /// <summary>
        /// 模拟
        /// 使用队列模拟，写着玩的
        /// </summary>
        /// <param name="numOnes"></param>
        /// <param name="numZeros"></param>
        /// <param name="numNegOnes"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int KItemsWithMaximumSum(int numOnes, int numZeros, int numNegOnes, int k)
        {
            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < numOnes; i++) queue.Enqueue(1);
            for (int i = 0; i < numZeros; i++) queue.Enqueue(0);
            for (int i = 0; i < numNegOnes; i++) queue.Enqueue(-1);

            int result = 0;
            for (int i = 0; i < k; i++) result += queue.Dequeue();

            return result;
        }

        /// <summary>
        /// 模拟
        /// 使用栈模拟，写着玩的
        /// </summary>
        /// <param name="numOnes"></param>
        /// <param name="numZeros"></param>
        /// <param name="numNegOnes"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int KItemsWithMaximumSum2(int numOnes, int numZeros, int numNegOnes, int k)
        {
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < numNegOnes; i++) stack.Push(-1);
            for (int i = 0; i < numZeros; i++) stack.Push(0);
            for (int i = 0; i < numOnes; i++) stack.Push(1);

            int result = 0;
            for (int i = 0; i < k; i++) result += stack.Pop();

            return result;
        }
    }
}

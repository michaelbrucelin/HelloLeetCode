using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1686
{
    public class Solution1686 : Interface1686
    {
        /// <summary>
        /// 策略
        /// 换个角度想，假设一开始全部的石块都被Bob拿走了，Alice现在可以从Bob手中拿走(n+1)/2块石块，问Alice的最优策略是什么？
        /// 显然，Alice拿去第i块石块的话，Alice得到A[i]，Bob损失B[i]，所以Alice应该优先拿取A[i]+B[i]更大的石块
        /// </summary>
        /// <param name="aliceValues"></param>
        /// <param name="bobValues"></param>
        /// <returns></returns>
        public int StoneGameVI(int[] aliceValues, int[] bobValues)
        {
            int len = aliceValues.Length;
            int[] index = new int[len];
            for (int i = 0; i < len; i++) index[i] = i;
            Array.Sort(index, (i, j) => (aliceValues[j] + bobValues[j]) - (aliceValues[i] + bobValues[i]));

            int alice = 0, bob = 0;
            for (int i = 0; i < len; i += 2) alice += aliceValues[index[i]];
            for (int i = 1; i < len; i += 2) bob += bobValues[index[i]];

            return (alice - bob) switch { > 0 => 1, < 0 => -1, _ => 0 };
        }

        /// <summary>
        /// 逻辑同StoneGameVI()，只是将排序改为了大顶堆
        /// </summary>
        /// <param name="aliceValues"></param>
        /// <param name="bobValues"></param>
        /// <returns></returns>
        public int StoneGameVI2(int[] aliceValues, int[] bobValues)
        {
            PriorityQueue<(int alice, int bob), int> maxpq = new PriorityQueue<(int alice, int bob), int>();
            int len = aliceValues.Length;
            for (int i = 0; i < len; i++) maxpq.Enqueue((aliceValues[i], bobValues[i]), -(aliceValues[i] + bobValues[i]));

            int alice = 0, bob = 0; bool flag = true;
            while (maxpq.Count > 0)
            {
                if (flag) alice += maxpq.Dequeue().alice; else bob += maxpq.Dequeue().bob;
                flag = !flag;
            }

            return (alice - bob) switch { > 0 => 1, < 0 => -1, _ => 0 };
        }
    }
}

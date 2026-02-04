using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0178
{
    public class Solution0178 : Interface0178
    {
        /// <summary>
        /// 找只出现1次的值？实在没读懂题意
        /// 使用 [5,7,5,5,5,7,5,5,5,7,5,5] 作为输入，竟然返回 0
        /// 使用 [5,7,5,5,5,8,5,5,5,9,5,5] 作为输入，竟然返回 15
        /// 
        /// 提交竟然通过了... ...
        /// </summary>
        /// <param name="actions"></param>
        /// <returns></returns>
        public int TrainingPlan(int[] actions)
        {
            Dictionary<int, int> freq = new Dictionary<int, int>();
            foreach (int x in actions) if (freq.ContainsKey(x)) freq[x]++; else freq.Add(x, 1);

            foreach (int x in freq.Keys) if (freq[x] == 1) return x;
            return 0;
        }
    }
}

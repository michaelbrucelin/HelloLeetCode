using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0134
{
    public class Solution0134_err : Interface0134
    {
        /// <summary>
        /// 数学
        /// 由于题目限定如果有解，一定是唯一解，所以一定从第一个gas - cost > 0的位置开始
        ///     gas - cost > 0，一定是一个连续区间，否则一定有多个解
        /// gas = [5, 8, 2, 8]; cost = [6, 5, 6, 6]
        /// </summary>
        /// <param name="gas"></param>
        /// <param name="cost"></param>
        /// <returns></returns>
        public int CanCompleteCircuit(int[] gas, int[] cost)
        {
            if (gas.Sum() - cost.Sum() < 0) return -1;

            int n = gas.Length;
            if (gas[0] - cost[0] < 0)
            {
                for (int i = 1; i < n; i++) if (gas[i] - cost[i] > 0) return i;
            }
            else
            {
                for (int i = n - 1; i >= 0; i--) if (gas[i] - cost[i] < 0) return (i + 1) % n;
            }

            throw new Exception("logic error.");
        }
    }
}

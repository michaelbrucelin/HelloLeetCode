using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0871
{
    public class Solution0871 : Interface0871
    {
        /// <summary>
        /// 模拟（DP + 贪心 + 大顶堆）
        /// 1. 如果加了x次油才能到达第y个加油站，一定选择加油最多的可能
        /// 2. 如果到达第N个加油站，最少加油为F(N)次，那么，
        ///     如果余下的油可以到达下一个加油站，则F(N+1) = F(N)
        ///     否则，选择前面没有加油的加油站中油量最多的加油
        /// </summary>
        /// <param name="target"></param>
        /// <param name="startFuel"></param>
        /// <param name="stations"></param>
        /// <returns></returns>
        public int MinRefuelStops(int target, int startFuel, int[][] stations)
        {
            if (startFuel >= target) return 0;
            if (stations.Length == 0 || startFuel < stations[0][0]) return -1;
            startFuel -= stations[0][0];

            int result = 0, total = startFuel, dist = 0, fuel, n = stations.Length;
            PriorityQueue<int, int> maxpq = new PriorityQueue<int, int>();
            maxpq.Enqueue(stations[0][1], -stations[0][1]);
            for (int i = 1; i < n; i++)
            {
                dist = stations[i][0] - stations[i - 1][0]; fuel = stations[i][1];
                while (total < dist && maxpq.Count > 0)
                {
                    total += maxpq.Dequeue(); result++;
                }
                if (total < dist) return -1;
                total -= dist;
                maxpq.Enqueue(fuel, -fuel);
                if (total >= target - stations[i][0]) return result;
            }

            dist = target - stations[^1][0];
            while (total < dist && maxpq.Count > 0)
            {
                total += maxpq.Dequeue(); result++;
            }
            if (total < dist) return -1;

            return result;
        }
    }
}

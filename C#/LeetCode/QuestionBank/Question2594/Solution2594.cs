using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2594
{
    public class Solution2594 : Interface2594
    {
        /// <summary>
        /// 二分法
        /// 1. n分钟，能力为r的修理工，可以修sqrt(n/r)辆车
        /// 2. 将ranks预处理为排序字典，这样有几点好处
        ///     - 能力值相同的修理工只需要计算一次
        ///     - 能力值小的修理工单位时间修的车多，这样更容易达到目标值，可以尽快跳出计算，方便剪枝
        ///     - 利用最小的能力值可以定二分法的上界
        /// </summary>
        /// <param name="ranks"></param>
        /// <param name="cars"></param>
        /// <returns></returns>
        public long RepairCars(int[] ranks, int cars)
        {
            SortedDictionary<long, int> dic = new SortedDictionary<long, int>();
            for (int i = 0, rank; i < ranks.Length; i++)
            {
                rank = ranks[i];
                if (dic.ContainsKey(rank)) dic[rank]++; else dic.Add(rank, 1);
            }

            long min_rank = dic.First().Key, min_cars = (long)Math.Ceiling(((decimal)cars) / dic[min_rank]);
            long mid, low = 1, high = min_cars * min_cars * min_rank;
            long result = -1, _cars;
            while (low <= high)
            {
                _cars = 0; mid = low + ((high - low) >> 1);
                foreach (var kv in dic)
                {
                    _cars += ((long)Math.Sqrt(mid / kv.Key)) * kv.Value;
                    if (_cars >= cars) break;
                }

                if (_cars >= cars)
                {
                    result = mid; high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }

            return result;
        }
    }
}

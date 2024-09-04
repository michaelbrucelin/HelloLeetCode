using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2860
{
    public class Solution2860_err : Interface2860
    {
        /// <summary>
        /// 类DP，类BFS
        /// 假定数组的前n项有F(n)中方案，那么数组的前n+1项呢？
        /// 1. 前n项无效的方案，无论选不选第n+1项仍然无效
        /// 2. 前n项有效的方案
        ///     不选第n+1项，如果第n+1项 > 0，仍然有效；如果第n+1项 = 0，无效；
        ///     选了第n+1项，不一定有效了
        ///     所以要维护当前有效的方案，记录每一个方案的：(选了几项, 最小未选项)
        /// 不确定会不会TLE或OLE，先写出来试试
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int CountWays(IList<int> nums)
        {
            Dictionary<(int cnt, int min), int> ways = new Dictionary<(int cnt, int min), int>() { { (0, int.MaxValue), 0 } };
            Dictionary<(int cnt, int min), int> _ways = new Dictionary<(int cnt, int min), int>();
            foreach (int num in nums)
            {
                // 不选num
                _ways.Clear();
                if (num > 0) foreach (var kv in ways) _ways.Add((kv.Key.cnt, Math.Min(kv.Key.min, num)), kv.Value);

                // 选择num
                foreach (var kv in ways)
                {
                    int cnt = kv.Key.cnt + 1;
                    if (cnt < kv.Key.min && cnt > num)
                    {
                        _ways.TryAdd((cnt, kv.Key.min), 0);
                        _ways[(cnt, kv.Key.min)] += kv.Value;
                    }
                }

                ways = new Dictionary<(int cnt, int min), int>(_ways);
            }

            return ways.Values.Sum();
        }
    }
}

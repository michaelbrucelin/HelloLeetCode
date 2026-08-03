using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1406
{
    public class Solution1406 : Interface1406
    {
        /// <summary>
        /// DFS + 记忆化搜索
        /// </summary>
        /// <param name="stoneValue"></param>
        /// <returns></returns>
        public string StoneGameIII(int[] stoneValue)
        {
            int len = stoneValue.Length;
            Dictionary<(int, int), int[]> memory = new Dictionary<(int, int), int[]>();  // (idx, who) -> [Alice, Bob]
            int[] info = StoneGameIII(0, 0);

            return (info[0] - info[1]) switch { > 0 => "Alice", < 0 => "Bob", _ => "Tie" };

            int[] StoneGameIII(int idx, int who)
            {
                if (idx == len) return [0, 0];
                if (memory.ContainsKey((idx, who))) return memory[(idx, who)];

                int[] values = [0, 0], _values;
                // 取1个
                _values = StoneGameIII(idx + 1, 1 - who);
                values = [_values[0], _values[1]];
                values[who] += stoneValue[idx];
                // 取2个
                if (idx + 1 < len)
                {
                    _values = StoneGameIII(idx + 2, 1 - who);
                    if (_values[who] + stoneValue[idx] + stoneValue[idx + 1] > values[who])
                    {
                        values = [_values[0], _values[1]];
                        values[who] += stoneValue[idx] + stoneValue[idx + 1];
                    }
                }
                // 取3个
                if (idx + 2 < len)
                {
                    _values = StoneGameIII(idx + 3, 1 - who);
                    if (_values[who] + stoneValue[idx] + stoneValue[idx + 1] + stoneValue[idx + 2] > values[who])
                    {
                        values = [_values[0], _values[1]];
                        values[who] += stoneValue[idx] + stoneValue[idx + 1] + stoneValue[idx + 2];
                    }
                }

                memory.Add((idx, who), values);
                return values;
            }
        }
    }
}

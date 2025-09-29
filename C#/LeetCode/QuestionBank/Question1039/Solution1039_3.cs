using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1039
{
    public class Solution1039_3 : Interface1039
    {
        /// <summary>
        /// DFS + 记忆化搜索
        /// 每一条连线都将一凸n边形分割为两个小的凸?边形，所以可以自顶向下dfs
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public int MinScoreTriangulation(int[] values)
        {
            if (values.Length == 3) return values[0] * values[1] * values[2];

            Dictionary<(int, int), int> memory = new Dictionary<(int, int), int>();
            int len = values.Length;
            return dfs(0, len - 1);

            int dfs(int a, int z)
            {
                if (memory.ContainsKey((a, z))) return memory[(a, z)];
                int result = int.MaxValue, cnt = z > a ? z - a + 1 : z + len - a + 1;
                if (cnt == 3)
                {
                    result = (z > a) ? values[a] * values[a + 1] * values[z] : values[a] * values[(a + 1 + len) % len] * values[z];
                    memory.Add((a, z), result);
                    return result;
                }

                // 先不写了，这里不复杂

                memory.Add((a, z), result);
                return result;
            }
        }
    }
}

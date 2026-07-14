using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1642
{
    public class Solution1642 : Interface1642
    {
        /// <summary>
        /// dfs + 记忆化搜索
        /// 可以贪心解的，参考Solution1642，这里写一个dfs+记忆化搜索玩玩
        /// 连续下降可以压缩成最后一个最低的位置，这里也不写了，反正dfs + 记忆化搜索就不是正解，不优化了
        /// 
        /// 意料之中的TLE，参考测试用例04
        /// </summary>
        /// <param name="heights"></param>
        /// <param name="bricks"></param>
        /// <param name="ladders"></param>
        /// <returns></returns>
        public int FurthestBuilding(int[] heights, int bricks, int ladders)
        {
            if (ladders >= heights.Length - 1) return heights.Length - 1;

            Dictionary<(int, int, int), int> memory = new Dictionary<(int, int, int), int>();
            return dfs(0, bricks, ladders);

            int dfs(int idx, int bricks, int ladders)
            {
                if (memory.ContainsKey((idx, bricks, ladders))) return memory[(idx, bricks, ladders)];
                if (idx == heights.Length - 1) return heights.Length - 1;
                if (heights[idx + 1] <= heights[idx]) return dfs(idx + 1, bricks, ladders);

                int result = idx, diff = heights[idx + 1] - heights[idx];
                if (bricks >= diff) result = Math.Max(result, dfs(idx + 1, bricks - diff, ladders));
                if (ladders > 0) result = Math.Max(result, dfs(idx + 1, bricks, ladders - 1));

                memory.Add((idx, bricks, ladders), result);
                return result;
            }
        }
    }
}

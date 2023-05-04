using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2106
{
    public class Solution2106_3 : Interface2106
    {
        /// <summary>
        /// DFS + 记忆化搜索
        /// 与Solution2106_2相同，添加记忆化搜索，预计效果不会好多少，没有找到利用率更高的记忆化的key
        /// 
        /// 逻辑没问题，速度没快，没有提交测试，参考测试用例04
        /// </summary>
        /// <param name="fruits"></param>
        /// <param name="startPos"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MaxTotalFruits(int[][] fruits, int startPos, int k)
        {
            Dictionary<(int, int, int, int), int> memory = new Dictionary<(int, int, int, int), int>();
            int startId = BinarySearch(fruits, startPos);
            if (startId == -1)
            {
                if (fruits[0][0] - startPos <= k)
                    return dfs(fruits, 0, -1, 1, k - (fruits[0][0] - startPos), 0, memory);
            }
            else
            {
                if (fruits[startId][0] == startPos)
                {
                    return dfs(fruits, startId, startId - 1, startId + 1, k, 0, memory);
                }
                else
                {
                    int cnt1 = 0, cnt2 = 0;
                    if (startPos - fruits[startId][0] <= k)                                     // 向左走
                    {
                        cnt1 = dfs(fruits, startId, startId - 1, startId + 1, k - (startPos - fruits[startId][0]), 0, memory);
                    }
                    if (startId < fruits.Length - 1 && fruits[startId + 1][0] - startPos <= k)  // 向右走
                    {
                        cnt2 = dfs(fruits, startId + 1, startId, startId + 2, k - (fruits[startId + 1][0] - startPos), 0, memory);
                    }
                    return Math.Max(cnt1, cnt2);
                }
            }

            return 0;
        }

        private int dfs(int[][] fruits, int id, int lid, int rid, int k, int cnt, Dictionary<(int, int, int, int), int> memory)
        {
            if (memory.ContainsKey((id, lid, rid, k))) return memory[(id, lid, rid, k)];
            cnt += fruits[id][1];
            int cnt1 = cnt, cnt2 = cnt;
            if (lid > 0 && fruits[id][0] - fruits[lid][0] <= k)              // 向左走
                cnt1 = dfs(fruits, lid, lid - 1, rid, k - (fruits[id][0] - fruits[lid][0]), cnt, memory);
            if (rid < fruits.Length && fruits[rid][0] - fruits[id][0] <= k)  // 向右走
                cnt2 = dfs(fruits, rid, lid, rid + 1, k - (fruits[rid][0] - fruits[id][0]), cnt, memory);
            memory.Add((id, lid, rid, k), Math.Max(cnt1, cnt2));

            return Math.Max(cnt1, cnt2);
        }

        /// <summary>
        /// 找出第一个小于等于startPos的position的id
        /// </summary>
        /// <param name="fruits"></param>
        /// <param name="startPos"></param>
        /// <returns></returns>
        private int BinarySearch(int[][] fruits, int startPos)
        {
            int result = -1, low = 0, high = fruits.Length - 1, mid;
            while (low <= high)
            {
                mid = low + ((high - low) >> 1);
                if (fruits[mid][0] < startPos)
                {
                    result = mid; low = mid + 1;
                }
                else if (fruits[mid][0] > startPos)
                {
                    high = mid - 1;
                }
                else  // if (fruits[mid][0] == startPos)
                {
                    result = mid; break;
                }
            }

            return result;
        }
    }
}

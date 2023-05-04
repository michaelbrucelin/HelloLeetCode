using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2106
{
    public class Solution2106 : Interface2106
    {
        /// <summary>
        /// DFS
        /// 1. 无论在哪个位置，都只有两种选择：向左走、向右走
        ///     如果只有一侧有水果，当然就只剩下一种选择
        /// 2. 无论向那边走，都一定要到达第一处水果位置，再进行下一次的方向选择
        ///     如果没有达到第一次水果位置，就反方向走，那么就产生无用的步数耗费
        /// 
        /// 逻辑没问题，但是提交会超时，参考测试用例04
        /// 猜想：最多只能有一次折返？怎么证明？或者证否？
        ///     很好证明，参考Solution2106_4.md
        /// </summary>
        /// <param name="fruits"></param>
        /// <param name="startPos"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MaxTotalFruits(int[][] fruits, int startPos, int k)
        {
            int startId = BinarySearch(fruits, startPos);
            if (startId == -1)
            {
                if (fruits[0][0] - startPos <= k)
                {
                    List<(int pos, int cnt)> _fruits = new List<(int pos, int cnt)>();
                    for (int i = 0; i < fruits.Length; i++) _fruits.Add((fruits[i][0], fruits[i][1]));
                    return dfs(_fruits, 0, k - (fruits[0][0] - startPos), 0);
                }
            }
            else
            {
                if (fruits[startId][0] == startPos)
                {
                    List<(int pos, int cnt)> _fruits = new List<(int pos, int cnt)>();
                    for (int i = 0; i < fruits.Length; i++) _fruits.Add((fruits[i][0], fruits[i][1]));
                    return dfs(_fruits, startId, k, 0);
                }
                else
                {
                    int cnt1 = 0, cnt2 = 0;
                    if (startPos - fruits[startId][0] <= k)                                     // 向左走
                    {
                        List<(int pos, int cnt)> _fruits = new List<(int pos, int cnt)>();
                        for (int i = 0; i < fruits.Length; i++) _fruits.Add((fruits[i][0], fruits[i][1]));
                        cnt1 = dfs(_fruits, startId, k - (startPos - fruits[startId][0]), 0);
                    }
                    if (startId < fruits.Length - 1 && fruits[startId + 1][0] - startPos <= k)  // 向右走
                    {
                        List<(int pos, int cnt)> _fruits = new List<(int pos, int cnt)>();
                        for (int i = 0; i < fruits.Length; i++) _fruits.Add((fruits[i][0], fruits[i][1]));
                        cnt2 = dfs(_fruits, startId + 1, k - (fruits[startId + 1][0] - startPos), 0);
                    }
                    return Math.Max(cnt1, cnt2);
                }
            }

            return 0;
        }

        private int dfs(List<(int pos, int cnt)> fruits, int id, int k, int cnt)
        {
            cnt += fruits[id].cnt;
            int cnt1 = cnt, cnt2 = cnt;
            if (id > 0 && fruits[id].pos - fruits[id - 1].pos <= k)                 // 向左走
            {
                List<(int pos, int cnt)> _fruits = new List<(int pos, int cnt)>(fruits);
                _fruits.RemoveAt(id);
                cnt1 = dfs(_fruits, id - 1, k - (fruits[id].pos - fruits[id - 1].pos), cnt);
            }
            if (id < fruits.Count - 1 && fruits[id + 1].pos - fruits[id].pos <= k)  // 向右走
            {
                List<(int pos, int cnt)> _fruits = new List<(int pos, int cnt)>(fruits);
                _fruits.RemoveAt(id);
                cnt2 = dfs(_fruits, id, k - (fruits[id + 1].pos - fruits[id].pos), cnt);
            }

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

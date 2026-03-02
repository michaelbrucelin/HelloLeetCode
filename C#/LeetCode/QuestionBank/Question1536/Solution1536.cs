using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1536
{
    public class Solution1536 : Interface1536
    {
        /// <summary>
        /// 贪心 + 小顶堆，冒泡
        /// 1. 预处理List<int, List<int>> freq
        ///     表示 grid[idx] 这一行从右至左有连续 freq[idx].Count 个 0
        /// 2. 小顶堆，minpq，将 freq[n] 放入堆
        /// 3. 逐行判断
        ///     第 0 行，需要右端至少有 n-1 个 0，将 freq[n-1] 放入小顶堆，Dequeue() 最小的行，计算移动次数
        ///     第 1 行，需要右端至少有 n-2 个 0，将 freq[n-2] 放入小顶堆，Dequeue() 最小的行，计算移动次数
        ///     ... ...
        /// 4. 注意每一轮移动后，部分行的 id 发生了变化
        ///     例如，第一轮将第 idx=6 行移动到第 0 行，那么原先 idx in [0-5] 的行需要 idx++
        ///     只需要一个数组记录每一行 idx 的增量即可，不需要更新 minpq，因为有增量的 idx 一定比没有增量的更小（好好脑补一下或者纸上画一画）
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int MinSwaps(int[][] grid)
        {
            int result = 0, n = grid.Length;
            List<List<int>> freq = [];
            for (int i = 0; i <= n; i++) freq.Add([]);
            for (int i = 0, cnt; i < n; i++)
            {
                cnt = 0;
                for (int j = n - 1; j > -1 && grid[i][j] == 0; j--) cnt++;
                freq[cnt].Add(i);
            }

            PriorityQueue<int, int> minpq = new PriorityQueue<int, int>();
            int[] idinc = new int[n];
            foreach (int x in freq[n]) minpq.Enqueue(x, x);
            for (int i = 0, j = n - 1, idx; i < n; i++, j--)
            {
                foreach (int x in freq[j]) minpq.Enqueue(x, x);
                if (minpq.Count == 0) return -1;
                idx = minpq.Dequeue();
                result += idx + idinc[idx] - i;
                for (int k = 0; k < idx; k++) idinc[k]++;  // 这里有些行已经被用掉，不需要记录增量，但是那样还需要记录哪些行被用掉，不如全部记录
            }

            return result;
        }
    }
}

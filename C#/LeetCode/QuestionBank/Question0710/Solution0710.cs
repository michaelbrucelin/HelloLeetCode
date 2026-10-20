using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0710
{
    public class Solution0710
    {
    }

    /// <summary>
    /// 重映射
    /// 起初相当于有 n 个映射： 0 -> 0, 1 -> 1, ...n-1 -> n-1，有了 x 个黑名单后，相当于有 n-x 个映射
    /// 将黑名单位置的映射值改为有效的，然后在 [0, n-x) 之间随机即可
    /// 例如：n=7, [2, 3, 5]
    /// 初始化：0 -> 0, 1 -> 1, 2 -> 2, 3 -> 3, 4 -> 4, 5 -> 5, 6 -> 6
    /// 重映射：0 -> 0, 1 -> 1, 2 -> 6, 3 -> 4
    /// </summary>
    public class Solution : Interface0710
    {
        public Solution(int n, int[] blacklist)
        {
            random = new Random();
            map = new Dictionary<int, int>();
            this.n = n - blacklist.Length;
            HashSet<int> set = [.. blacklist];
            int to = n - 1;
            foreach (int x in set) if (x < this.n)
                {
                    while (set.Contains(to)) to--;
                    map.Add(x, to--);
                }
        }

        private Random random;
        private Dictionary<int, int> map;
        private int n;

        public int Pick()
        {
            int x = random.Next(n);
            if (map.TryGetValue(x, out int y)) return y; else return x;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1998
{
    public class Solution1998 : Interface1998
    {
        /// <summary>
        /// 并查集 + 堆排序
        /// 并查集找出可以互换位置的组，每个组内部排序，看结果和整体排序的结果是否一致即可
        /// 具体解释见Solution1269_oth.md
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public bool GcdSort(int[] nums)
        {
            if (nums.Length == 1) return true;

            int max = nums[0], len = nums.Length;
            for (int i = 1; i < len; i++) max = Math.Max(max, nums[i]);
            List<int> primes = get_primes(max + 1);

            Dictionary<int, int> uf = new Dictionary<int, int>(), height = new Dictionary<int, int>();
            for (int i = 0, num, x; i < len; i++)
            {
                num = x = nums[i];
                if (!uf.ContainsKey(num)) { uf.Add(num, num); height.Add(num, 0); }
                foreach (int prime in primes)
                {
                    if (prime > x) break;
                    if (x % prime == 0) union(num, prime);
                    while (x % prime == 0) x /= prime;
                }
            }

            Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();
            for (int i = 0, key; i < len; i++)
            {
                key = find(nums[i]);
                if (map.TryGetValue(key, out List<int> list)) list.Add(i); else map.Add(key, [i]);
            }

            int[] _nums = new int[len];
            PriorityQueue<int, int> minpq = new PriorityQueue<int, int>();
            foreach (List<int> list in map.Values)
            {
                foreach (int id in list) minpq.Enqueue(nums[id], nums[id]);
                foreach (int id in list) _nums[id] = minpq.Dequeue();
            }

            Array.Sort(nums);
            for (int i = 0; i < len; i++) if (_nums[i] != nums[i]) return false;
            return true;

            static List<int> get_primes(int n)
            {
                List<int> result = new List<int>();
                bool[] mask = new bool[n]; Array.Fill(mask, true);
                for (int i = 2; i < n; i++)
                {
                    if (mask[i]) result.Add(i);
                    for (int j = 0; j < result.Count && i * result[j] < n; j++)
                    {
                        mask[i * result[j]] = false;
                        if (i % result[j] == 0) break;
                    }
                }

                return result;
            }

            void union(int x, int y)
            {
                x = find(x); y = find(y);
                if (x == y) return;
                if (height[x] == height[y])
                {
                    uf[y] = x; height[x]++;
                }
                else
                {
                    if (height[x] > height[y]) uf[y] = x; else uf[x] = y;
                }
            }

            int find(int x)
            {
                if (!uf.ContainsKey(x))
                {
                    uf.Add(x, x); height.Add(x, 0);
                    return x;
                }

                int f = x;
                while (uf[f] != f) f = uf[f];
                int i = x, j;
                while (uf[i] != f)
                {
                    j = uf[i]; uf[i] = f; i = j;
                }

                return f;
            }
        }
    }
}

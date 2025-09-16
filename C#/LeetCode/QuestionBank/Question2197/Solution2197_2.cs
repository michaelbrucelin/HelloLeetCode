using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2197
{
    public class Solution2197_2 : Interface2197
    {
        /// <summary>
        /// 双向链表
        /// 逻辑完全同Solution2197，仔细看TestCase08的数据，发现从后向前合并，就会很快完成，所以考虑用鸡尾酒排序的思想解决
        /// 但是如果必须从中间向两边合并怎么办？鸡尾酒排序也无效
        /// 所以这里采用出现可以合并的两项，就合并一直向左合并，然后再向右合并
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<int> ReplaceNonCoprimes(int[] nums)
        {
            if (nums.Length == 1) return nums;

            SortedSet<int> primes = GetPrimes((int)1e5 + 1);
            Dictionary<int, Dictionary<int, int>> factors = new Dictionary<int, Dictionary<int, int>>();
            foreach (int num in nums) BuildFactors(num);

            LinkedList<int> list = new LinkedList<int>(nums);
            LinkedListNode<int> ptr = list.First;
            int lcm;
            while (ptr != null)
            {
                while ((ptr.Previous != null && MapOverlaps(ptr.Previous.Value, ptr.Value)) || (ptr.Next != null && MapOverlaps(ptr.Next.Value, ptr.Value)))
                {
                    while (ptr.Previous != null)
                    {
                        if (!MapOverlaps(ptr.Previous.Value, ptr.Value)) break;
                        lcm = GetLCM(ptr.Previous.Value, ptr.Value);
                        ptr.Value = lcm;
                        list.Remove(ptr.Previous);
                        BuildFactors(lcm);
                    }
                    while (ptr.Next != null)
                    {
                        if (!MapOverlaps(ptr.Next.Value, ptr.Value)) break;
                        lcm = GetLCM(ptr.Next.Value, ptr.Value);
                        ptr.Value = lcm;
                        list.Remove(ptr.Next);
                        BuildFactors(lcm);
                    }
                }
                ptr = ptr.Next;
            }

            return list.ToArray();

            bool MapOverlaps(int x, int y)
            {
                if (factors[x].Count > factors[y].Count) (x, y) = (y, x);
                foreach (int key in factors[x].Keys) if (factors[y].ContainsKey(key)) return true;

                return false;
            }

            int GetLCM(int x, int y)
            {
                if (x == y) return x;

                int gcd = 1, cnt;
                if (factors[x].Count > factors[y].Count) (x, y) = (y, x);
                foreach (int key in factors[x].Keys) if (factors[y].ContainsKey(key))
                    {
                        cnt = Math.Min(factors[x][key], factors[y][key]);
                        for (int i = 0; i < cnt; i++) gcd *= key;
                    }

                return x / gcd * y;
            }

            void BuildFactors(int num)
            {
                if (factors.ContainsKey(num)) return;
                if (primes.Contains(num)) { factors.Add(num, new Dictionary<int, int>() { { num, 1 } }); return; }

                Dictionary<int, int> map = new Dictionary<int, int>();
                int _num = num;
                foreach (int prime in primes)
                {
                    if (prime > _num) break;
                    while (_num % prime == 0)
                    {
                        if (map.ContainsKey(prime)) map[prime]++; else map.Add(prime, 1);
                        _num /= prime;
                        if (factors.ContainsKey(_num))
                        {
                            foreach (int key in factors[_num].Keys)
                            {
                                if (map.ContainsKey(key)) map[key] += factors[_num][key]; else map.Add(key, factors[_num][key]);
                            }
                            _num = 1;
                        }
                        else if (primes.Contains(_num))
                        {
                            if (map.ContainsKey(_num)) map[_num]++; else map.Add(_num, 1);
                            _num = 1;
                        }
                    }
                }
                factors.Add(num, map);
            }
        }

        private SortedSet<int> GetPrimes(int n)
        {
            List<int> list = new List<int>();
            bool[] mask = new bool[n]; Array.Fill(mask, true);
            for (int i = 2; i < n; i++)
            {
                if (mask[i]) list.Add(i);
                for (int j = 0; j < list.Count && i * list[j] < n; j++)
                {
                    mask[i * list[j]] = false;
                    if (i % list[j] == 0) break;
                }
            }

            return [.. list];
        }
    }
}

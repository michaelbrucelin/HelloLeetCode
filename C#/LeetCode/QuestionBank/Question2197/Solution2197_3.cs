using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2197
{
    public class Solution2197_3 : Interface2197
    {
        /// <summary>
        /// 栈
        /// 逻辑同Solution2197,将双向链表换成栈
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<int> ReplaceNonCoprimes(int[] nums)
        {
            if (nums.Length == 1) return nums;

            SortedSet<int> primes = GetPrimes((int)1e5 + 1);
            Dictionary<int, Dictionary<int, int>> factors = new Dictionary<int, Dictionary<int, int>>();
            foreach (int num in nums) BuildFactors(num);

            Stack<int> stack = new Stack<int>();
            int lcm;
            for (int i = nums.Length - 1, num; i >= 0; i--)
            {
                num = nums[i];
                while (stack.Count > 0 && MapOverlaps(num, stack.Peek()))
                {
                    num = GetLCM(num, stack.Pop());
                    BuildFactors(num);
                }
                stack.Push(num);
            }

            return stack.ToArray();

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

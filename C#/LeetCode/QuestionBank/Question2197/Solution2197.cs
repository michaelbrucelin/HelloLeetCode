using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2197
{
    public class Solution2197 : Interface2197
    {
        /// <summary>
        /// 暴力
        /// 1. 使用线性筛将可能使用到的质数获取出来
        /// 2. 将数组中的每个元素分解质因数
        ///     有了质因数结果，可以快速的计算两个数字的 是否存在约数 与 最小公倍数
        /// 可优化：
        /// 1. 分解nums中每个元素的质因数时，按照从小到达进行分解，这样分解大的数字时，可能会用到小的数字分解好的结果
        ///     不确定带来的剪枝能否抵消掉排序带来的消耗
        ///     
        /// 逻辑没问题，TLE，参考测试用例08
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<int> ReplaceNonCoprimes(int[] nums)
        {
            if (nums.Length == 1) return nums;

            SortedSet<int> primes = GetPrimes((int)1e5 + 1);
            Dictionary<int, Dictionary<int, int>> factors = new Dictionary<int, Dictionary<int, int>>();
            foreach (int num in nums) BuildFactors(num);

            List<int> result = [.. nums], _result;
            bool flag = true;
            while (flag)
            {
                flag = false;
                _result = [];
                for (int i = 1, lcm; i < result.Count; i++)
                {
                    if (MapOverlaps(result[i - 1], result[i]))
                    {
                        lcm = GetLCM(result[i - 1], result[i]);
                        _result.Add(lcm);
                        BuildFactors(lcm);
                        flag = true;
                        if (i == result.Count - 2) _result.Add(result[^1]);
                        i++;
                    }
                    else
                    {
                        _result.Add(result[i - 1]);
                        if (i == result.Count - 1) _result.Add(result[^1]);
                    }
                }
                if (flag) result = _result;
            }

            return result;

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

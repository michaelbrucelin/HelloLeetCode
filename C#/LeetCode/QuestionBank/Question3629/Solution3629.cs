using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3629
{
    public class Solution3629 : Interface3629
    {
        /// <summary>
        /// BFS
        /// 核心思路同Solution3629_err，使用BFS去找最小的步数
        /// 
        /// 当nums[i]为质数时，寻找下一跳的时间复杂度是O(n)，所以整体时间复杂度是O(n^2)，大概率会TLE
        /// 逻辑没问题，提交果然TLE，参考测试用例05
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MinJumps(int[] nums)
        {
            if (nums.Length == 1) return 0;

            int max = nums[0], len = nums.Length;
            for (int i = 1; i < len; i++) max = Math.Max(max, nums[i]);
            HashSet<int> primes = [.. GetPrimes(max + 1)];
            if (primes.Contains(nums[0]) && nums[^1] % nums[0] == 0) return 1;

            int result = 0;
            bool[] visited = new bool[len];
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(0); visited[0] = true;
            while (true)
            {
                result++;
                for (int i = queue.Count, idx, num, _idx; i > 0; i--)
                {
                    idx = queue.Dequeue();
                    if ((_idx = idx - 1) == len - 1) goto END; else if (_idx > 0 && !visited[_idx]) { queue.Enqueue(_idx); visited[_idx] = true; }  // if (next < len) 不会发生
                    if ((_idx = idx + 1) == len - 1) goto END; else if (_idx > 0 && !visited[_idx]) { queue.Enqueue(_idx); visited[_idx] = true; }
                    if (primes.Contains(num = nums[idx]))
                    {
                        if (nums[^1] >= num && nums[^1] % num == 0) goto END;
                        for (int j = 1; j < len - 1; j++) if (nums[j] >= num && nums[j] % num == 0 && !visited[j]) { queue.Enqueue(j); visited[j] = true; }
                    }
                }
            }

        END:;
            return result;

            static List<int> GetPrimes(int n)
            {
                List<int> result = [];
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
        }

        /// <summary>
        /// 逻辑同MinJumps()，
        /// 用一个队列维护没还有到达的吓一跳，如果数组正好有一半质数一半合数，同时两两配对，这种极端情况的时间复杂度仍然是O(n^2)，先写出来试试
        /// 
        /// 依然TLE
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MinJumps2(int[] nums)
        {
            if (nums.Length == 1) return 0;

            int max = nums[0], len = nums.Length;
            for (int i = 1; i < len; i++) max = Math.Max(max, nums[i]);
            HashSet<int> primes = [.. GetPrimes(max + 1)];
            if (primes.Contains(nums[0]) && nums[^1] % nums[0] == 0) return 1;

            int result = 0;
            bool[] visited = new bool[len];
            Queue<int> queue = new Queue<int>(), _queue = new Queue<int>();
            queue.Enqueue(0); visited[0] = true;
            for (int i = 1; i < len; i++) _queue.Enqueue(i);
            while (true)
            {
                result++;
                for (int i = queue.Count, idx, num, _idx; i > 0; i--)
                {
                    idx = queue.Dequeue();
                    if ((_idx = idx - 1) == len - 1) goto END; else if (_idx > 0 && !visited[_idx]) { queue.Enqueue(_idx); visited[_idx] = true; }  // if (next < len) 不会发生
                    if ((_idx = idx + 1) == len - 1) goto END; else if (_idx > 0 && !visited[_idx]) { queue.Enqueue(_idx); visited[_idx] = true; }
                    if (primes.Contains(num = nums[idx]))
                    {
                        if (nums[^1] >= num && nums[^1] % num == 0) goto END;
                        // for (int j = 1; j < len - 1; j++) if (nums[j] >= num && nums[j] % num == 0 && !visited[j]) { queue.Enqueue(j); visited[j] = true; }
                        for (int j = _queue.Count; j > 0; j--)
                        {
                            _idx = _queue.Dequeue();
                            if (nums[_idx] >= num && nums[_idx] % num == 0 && !visited[_idx]) { queue.Enqueue(_idx); visited[_idx] = true; } else _queue.Enqueue(_idx);
                        }
                    }
                }
            }

        END:;
            return result;

            static List<int> GetPrimes(int n)
            {
                List<int> result = [];
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
        }
    }
}

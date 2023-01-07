using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1658
{
    public class Solution1658 : Interface1658
    {
        /// <summary>
        /// 前缀和 + 后缀和
        /// 用字典存储前缀和与后缀和，然后找到最小的操作数
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public int MinOperations(int[] nums, int x)
        {
            int result = x + 1;
            SortedDictionary<int, int> head = new SortedDictionary<int, int>();
            SortedDictionary<int, int> tail = new SortedDictionary<int, int>();
            int len = nums.Length;
            int sum = 0; for (int i = 0; i < len; i++)
            {
                sum += nums[i];
                if (sum <= x) head.Add(sum, i + 1); else break;
            }
            sum = 0; for (int i = len - 1; i >= 0; i--)
            {
                sum += nums[i];
                if (sum <= x) tail.Add(sum, len - i); else break;
            }

            foreach (var kv in head)
            {
                if (kv.Value > result) break;
                if (kv.Key == x && kv.Value < result)
                    result = kv.Value;
                else if (tail.ContainsKey(x - kv.Key))
                {
                    int steps = kv.Value + tail[x - kv.Key];
                    if (steps < result && steps <= len) result = steps;
                }
            }
            foreach (var kv in tail)
            {
                if (kv.Value > result) break;
                if (kv.Key == x && kv.Value < result)
                    result = kv.Value;
                else if (head.ContainsKey(x - kv.Key))
                {
                    int steps = kv.Value + head[x - kv.Key];
                    if (steps < result && steps <= len) result = steps;
                }
            }

            return result == x + 1 ? -1 : result;
        }
    }
}

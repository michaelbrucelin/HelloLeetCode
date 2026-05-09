using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3629
{
    public class Solution3629_err : Interface3629
    {
        /// <summary>
        /// 分析
        /// 1. 使用线性筛找出[1..nums[^1]]区间全部的质数
        /// 2. 如果nums[0]是质数
        ///        如果nums[^1]是nums[0]的倍数，结果为1，否则将nums中nums[0]的倍数的索引按顺序记录到链表S1
        /// 3. 如果nums[0]不是质数或nums[0] > nums[^1]
        ///        一步一步的向前移动，并检查当前位置是否是质数并同时是nums[^1]的因数即可
        ///    如果nums[0]是质数且nums[0] < nums[^1]
        ///        3.1. 一步一步的向前移动，并检查当前位置是否是质数并同时是nums[^1]的因数
        ///        3.2. 将nums中nums[^1]的质因数的索引按顺序记录到链表S2中
        ///             使用双指针找出S1与S2的最小距离即可
        ///        3.3. 上面两个结果的较小者就是结果
        /// 
        /// 本来是沿着这个思路在写的，直觉上会有特殊情况需要处理，先写出来再结合反例去修正代码
        /// 突然想到用BFS更合适，而且逻辑是严谨的，所以直接使用BFS重新写了
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MinJumps(int[] nums)
        {
            if (nums.Length == 0) return 0;

            int len = nums.Length;
            HashSet<int> primes = [.. GetPrimes(nums[^1] + 1)];
            List<int> ids0 = [], ids1 = [];
            if (primes.Contains(nums[0]))
            {
                if (nums[^1] % nums[0] == 0) return 1;
                for (int i = 0; i < len; i++) if (nums[i] % nums[0] == 0) ids0.Add(i);
            }

            throw new NotImplementedException();

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

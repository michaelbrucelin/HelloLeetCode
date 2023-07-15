using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0018
{
    public class Solution0018_2 : Interface0018
    {
        /// <summary>
        /// 策略
        /// a + b + c + d = target  <-->  a + b + c = target - d
        /// 遍历a + b + c，哈希查找d
        /// 
        /// 逻辑没错，提交超时
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            if (nums.Length <= 3) return new List<IList<int>>();

            Dictionary<long, List<int>> dic = new Dictionary<long, List<int>>();
            int len = nums.Length;
            for (int i = 0; i < len; i++)
                if (dic.ContainsKey(nums[i])) dic[nums[i]].Add(i); else dic.Add(nums[i], new List<int>() { i });

            HashSet<(int a, int b, int c, int d)> result = new HashSet<(int a, int b, int c, int d)>();
            long _target; int[] temp = new int[4];
            for (int a = 0; a < len - 3; a++) for (int b = a + 1; b < len - 2; b++) for (int c = b + 1; c < len - 1; c++)
                    {
                        _target = (long)target - nums[a] - nums[b] - nums[c];
                        if (dic.ContainsKey(_target)) for (int i = dic[_target].Count - 1; i >= 0 && dic[_target][i] > c; i--)
                            {
                                temp[0] = nums[a]; temp[1] = nums[b]; temp[2] = nums[c]; temp[3] = nums[dic[_target][i]];
                                Array.Sort(temp);
                                result.Add((temp[0], temp[1], temp[2], temp[3]));
                            }
                    }

            return result.Select(t => new int[] { t.a, t.b, t.c, t.d }).ToArray();
        }
    }
}

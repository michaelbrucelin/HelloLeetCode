using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0018
{
    public class Solution0018_3 : Interface0018
    {
        /// <summary>
        /// 策略
        /// a + b + c + d = target  <-->  a + b = target - (c + d)
        /// 将数组中的元素两两组合哈希化，然后查找
        /// 
        /// 逻辑没错，提交超时
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            if (nums.Length <= 3) return new List<IList<int>>();

            Dictionary<long, List<(int i, int j)>> dic = new Dictionary<long, List<(int i, int j)>>();
            int key, len = nums.Length;
            for (int i = 0; i < len - 1; i++) for (int j = i + 1; j < len; j++)
                {
                    key = nums[i] + nums[j];
                    if (dic.ContainsKey(key)) dic[key].Add((i, j)); else dic.Add(key, new List<(int i, int j)>() { (i, j) });
                }

            HashSet<(int a, int b, int c, int d)> result = new HashSet<(int a, int b, int c, int d)>();
            long _target; int[] temp = new int[4];
            foreach (var kv1 in dic)
            {
                _target = (long)target - kv1.Key;
                if (dic.ContainsKey(_target))
                {
                    foreach ((int i, int j) v1 in kv1.Value) foreach ((int i, int j) v2 in dic[_target])
                        {
                            if (v1.i != v2.i && v1.i != v2.j && v1.j != v2.i && v1.j != v2.j)
                            {
                                temp[0] = nums[v1.i]; temp[1] = nums[v1.j]; temp[2] = nums[v2.i]; temp[3] = nums[v2.j];
                                Array.Sort(temp);
                                result.Add((temp[0], temp[1], temp[2], temp[3]));
                            }
                        }
                }
            }

            return result.Select(t => new int[] { t.a, t.b, t.c, t.d }).ToArray();
        }
    }
}

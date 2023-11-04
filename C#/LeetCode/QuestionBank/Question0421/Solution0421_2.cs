using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0421
{
    public class Solution0421_2 : Interface0421
    {
        /// <summary>
        /// 贪心，迭代
        /// 与Solution0421一样的思路，只是将递归改为了迭代
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindMaximumXOR(int[] nums)
        {
            if (nums.Length <= 1) return 0;

            int result = 0;
            Queue<(List<int> nums0, List<int> nums1)> queue = new Queue<(List<int> nums0, List<int> nums1)>();
            queue.Enqueue((nums.ToList(), new List<int>()));
            Queue<(List<int> nums0, List<int> nums1)> queue0, queue1;
            for (int i = 31; i > 0; i--)
            {
                queue0 = new Queue<(List<int> nums0, List<int> nums1)>();
                queue1 = new Queue<(List<int> nums0, List<int> nums1)>();
                while (queue.Count > 0)
                {
                    var t = queue.Dequeue();
                    if (t.nums1.Count == 0)
                    {
                        var _t = split(t.nums0, i);
                        if (_t.nums0.Count > 0 && _t.nums1.Count > 0)
                            queue1.Enqueue(_t);
                        else if (_t.nums0.Count > 0)
                            queue0.Enqueue(_t);
                        else  // if (_t.nums1.Count > 0)
                            queue0.Enqueue((_t.nums1, _t.nums0));
                    }
                    else
                    {
                        var _t0 = split(t.nums0, i);
                        var _t1 = split(t.nums1, i);
                        if (_t0.nums0.Count > 0 && _t1.nums1.Count > 0 && _t1.nums0.Count > 0 && _t0.nums1.Count > 0)
                        {
                            queue1.Enqueue((_t0.nums0, _t1.nums1)); queue1.Enqueue((_t1.nums0, _t0.nums1));
                        }
                        else if (_t0.nums0.Count > 0 && _t1.nums1.Count > 0)
                        {
                            queue1.Enqueue((_t0.nums0, _t1.nums1));
                        }
                        else if (_t1.nums0.Count > 0 && _t0.nums1.Count > 0)
                        {
                            queue1.Enqueue((_t1.nums0, _t0.nums1));
                        }
                        else
                        {
                            queue0.Enqueue((t.nums0.Concat(t.nums1).ToList(), new List<int>()));
                        }
                    }
                }

                if (queue1.Count > 0)
                {
                    queue = queue1; result |= 1 << (i - 1);
                }
                else
                {
                    queue = queue0;
                }
            }

            return result;
        }

        /// <summary>
        /// 按pos位0与1分为两个list
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="pos"></param>
        /// <returns></returns>
        private (List<int> nums0, List<int> nums1) split(IList<int> nums, int pos)
        {
            List<int> nums0 = new List<int>(), nums1 = new List<int>();
            int mask = 1 << (pos - 1);
            for (int i = 0, num; i < nums.Count; i++)
            {
                num = nums[i];
                if ((num & mask) != 0) nums1.Add(num); else nums0.Add(num);
            }

            return (nums0, nums1);
        }
    }
}

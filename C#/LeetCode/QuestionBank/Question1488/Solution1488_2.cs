using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1488
{
    public class Solution1488_2 : Interface1488
    {
        /// <summary>
        /// 贪心
        /// 逻辑同Solution1488_err，将队列改为List，二分查找找出第一个不下雨的天
        /// 
        /// 离了谱了，本来觉得List删除元素的代价太大，还想优化，没想到来了个双百... ...
        /// </summary>
        /// <param name="rains"></param>
        /// <returns></returns>
        public int[] AvoidFlood(int[] rains)
        {
            int len = rains.Length;
            int[] result = new int[len];
            Dictionary<int, int> full = new Dictionary<int, int>();
            List<int> todo = new List<int>();
            for (int i = 0, rain; i < len; i++)
            {
                rain = rains[i];
                if (rain > 0)
                {
                    result[i] = -1;
                    if (full.TryGetValue(rain, out int _i))
                    {
                        int _todo = BinarySearch(_i);
                        if (_todo == todo.Count) return [];
                        result[todo[_todo]] = rain;
                        todo.RemoveAt(_todo);
                        full[rain] = i;
                    }
                    else
                    {
                        full.Add(rain, i);
                    }
                }
                else
                {
                    result[i] = 1;
                    todo.Add(i);
                }
            }

            return result;

            int BinarySearch(int target)
            {
                int result = todo.Count, left = 0, right = todo.Count - 1, mid;
                while (left <= right)
                {
                    mid = left + ((right - left) >> 1);
                    if (todo[mid] > target)
                    {
                        result = mid; right = mid - 1;
                    }
                    else
                    {
                        left = mid + 1;
                    }
                }

                return result;
            }
        }
    }
}

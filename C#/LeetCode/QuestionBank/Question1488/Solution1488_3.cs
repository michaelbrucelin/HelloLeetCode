using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1488
{
    public class Solution1488_3 : Interface1488
    {
        /// <summary>
        /// 贪心
        /// 逻辑同Solution1488_2，将List改为SortedSet试试
        /// 
        /// TLE，画蛇添足，更慢了，参考测试用例06
        /// </summary>
        /// <param name="rains"></param>
        /// <returns></returns>
        public int[] AvoidFlood(int[] rains)
        {
            int len = rains.Length;
            int[] result = new int[len];
            Dictionary<int, int> full = new Dictionary<int, int>();
            SortedSet<int> todo = new SortedSet<int>();
            for (int i = 0, rain; i < len; i++)
            {
                rain = rains[i];
                if (rain > 0)
                {
                    result[i] = -1;
                    if (full.TryGetValue(rain, out int _i))
                    {
                        var view = todo.GetViewBetween(_i + 1, i);
                        if (view.Count == 0) return [];
                        result[view.First()] = rain;
                        todo.Remove(view.First());
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
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1488
{
    public class Solution1488_err : Interface1488
    {
        /// <summary>
        /// 贪心
        /// 不下雨的天优先抽第一个可能发生洪水的湖即可
        /// 使用一个Hash表记录有水的湖，使用一个队列记录可以抽水的日期即可
        /// 
        /// 思路是错误的，参考测试用例04
        /// </summary>
        /// <param name="rains"></param>
        /// <returns></returns>
        public int[] AvoidFlood(int[] rains)
        {
            int len = rains.Length;
            int[] result = new int[len];
            HashSet<int> full = new HashSet<int>();
            Queue<int> todo = new Queue<int>();
            for (int i = 0, rain; i < len; i++)
            {
                rain = rains[i];
                if (rain > 0)
                {
                    result[i] = -1;
                    if (!full.Add(rain))
                    {
                        if (todo.Count == 0) return [];
                        result[todo.Dequeue()] = rain;
                    }
                }
                else
                {
                    result[i] = 1;
                    todo.Enqueue(i);
                }
            }

            return result;
        }
    }
}

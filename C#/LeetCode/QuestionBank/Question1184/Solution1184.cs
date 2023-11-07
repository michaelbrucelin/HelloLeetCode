using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1184
{
    public class Solution1184 : Interface1184
    {
        /// <summary>
        /// 前缀和
        /// 多次调用可以采用前缀和来优化，这里是一次调用，原则上一次遍历更快，但是那样就太没意思了。
        /// </summary>
        /// <param name="distance"></param>
        /// <param name="start"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        public int DistanceBetweenBusStops(int[] distance, int start, int destination)
        {
            int sum = 0, len = distance.Length;
            int[] pre = new int[len + 1];
            for (int i = 0; i < len; i++)
            {
                sum += distance[i]; pre[i + 1] = pre[i] + distance[i];
            }

            if (start > destination) (start, destination) = (destination, start);
            return Math.Min(pre[destination] - pre[start], sum - pre[destination] + pre[start]);
        }
    }
}

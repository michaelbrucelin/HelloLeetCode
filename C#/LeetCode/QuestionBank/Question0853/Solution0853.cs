using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0853
{
    public class Solution0853 : Interface0853
    {
        /// <summary>
        /// 排序
        /// 按照位置排序，从后向前依次遍历每辆车，计算当前车是否会被后面的车挡住
        /// 本质上是一个单调栈
        /// </summary>
        /// <param name="target"></param>
        /// <param name="position"></param>
        /// <param name="speed"></param>
        /// <returns></returns>
        public int CarFleet(int target, int[] position, int[] speed)
        {
            if (position.Length == 1) return 1;

            int len = position.Length;
            int[] idxs = new int[len];
            for (int i = 1; i < len; i++) idxs[i] = i;
            Array.Sort(idxs, (i, j) => position[i] - position[j]);

            // 这里使用 距离+速度 两个变量来记录车行驶到target所需的时间，大概率使用 double = 距离 / 速度 也可以
            int result = 1, _dist = target - position[idxs[^1]], _speed = speed[idxs[^1]];
            for (int i = len - 2, idx; i >= 0; i--)
            {
                idx = idxs[i];
                if (gt(target - position[idx], speed[idx], _dist, _speed))
                {
                    result++;
                    _dist = target - position[idx]; _speed = speed[idx];
                }
            }

            return result;

            static bool gt(int dist1, int speed1, int dist2, int speed2)
            {
                return 1L * dist1 * speed2 > 1L * dist2 * speed1;
            }
        }
    }
}

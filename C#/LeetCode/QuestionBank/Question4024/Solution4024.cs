using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question4024
{
    public class Solution4024 : Interface4024
    {
        /// <summary>
        /// 遍历
        /// </summary>
        /// <param name="drones"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int NearestDrone(int[][] drones, int[] target)
        {
            int result = -1, dist, range = int.MaxValue, len = drones.Length;
            for (int i = 0; i < len; i++) if ((dist = Math.Abs(drones[i][0] - target[0]) + Math.Abs(drones[i][1] - target[1])) <= drones[i][2])
                {
                    if (dist < range)
                    {
                        range = dist; result = i;
                    }
                }

            return result;
        }
    }
}

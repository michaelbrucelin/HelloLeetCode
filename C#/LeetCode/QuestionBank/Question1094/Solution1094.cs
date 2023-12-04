using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1094
{
    public class Solution1094 : Interface1094
    {
        /// <summary>
        /// 差分数组
        /// </summary>
        /// <param name="trips"></param>
        /// <param name="capacity"></param>
        /// <returns></returns>
        public bool CarPooling(int[][] trips, int capacity)
        {
            int len = trips.Length, _len = 0;
            for (int i = 0; i < len; i++) _len = Math.Max(_len, trips[i][2]);  // 由提议设定，_len也可以直接取1000
            int[] diff = new int[_len + 2];

            for (int i = 0; i < len; i++)
            {
                diff[trips[i][1]] += trips[i][0]; diff[trips[i][2]] -= trips[i][0];
            }

            if (diff[0] > capacity) return false;
            for (int i = 1; i < _len + 2; i++)
                if ((diff[i] += diff[i - 1]) > capacity) return false;
            return true;
        }
    }
}

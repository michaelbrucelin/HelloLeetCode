using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3386
{
    public class Solution3386 : Interface3386
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="events"></param>
        /// <returns></returns>
        public int ButtonWithLongestTime(int[][] events)
        {
            int id = events[0][0], time = events[0][1], len = events.Length;
            for (int i = 1, _time; i < len; i++)
            {
                _time = events[i][1] - events[i - 1][1];
                if (_time > time || (_time == time && events[i][0] < id))
                {
                    time = _time; id = events[i][0];
                }
            }

            return id;
        }
    }
}

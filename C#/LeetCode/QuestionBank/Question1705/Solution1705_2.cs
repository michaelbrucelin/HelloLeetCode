using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1705
{
    public class Solution1705_2 : Interface1705
    {
        /// <summary>
        /// 贪心，小顶堆
        /// 逻辑完全同Solution1705，只是优化了“不再长苹果”之后的部分
        /// </summary>
        /// <param name="apples"></param>
        /// <param name="days"></param>
        /// <returns></returns>
        public int EatenApples(int[] apples, int[] days)
        {
            int result = 0, day, len = apples.Length;
            PriorityQueue<(int cnt, int day), int> minpq = new PriorityQueue<(int cnt, int day), int>();
            (int cnt, int day) item; bool flag;
            for (day = 0; day < len; day++)
            {
                if (apples[day] > 0) minpq.Enqueue((apples[day], day + days[day]), day + days[day]);
                flag = true;
                while (flag && minpq.Count > 0)
                {
                    item = minpq.Dequeue();
                    if (item.day > day)
                    {
                        result++;
                        if (item.cnt > 1) minpq.Enqueue((item.cnt - 1, item.day), item.day);
                        flag = false;
                    }
                }
            }

            int _cnt;
            while (minpq.Count > 0)
            {
                item = minpq.Dequeue();
                if (item.day > day)
                {
                    _cnt = Math.Min(item.cnt, item.day - day);
                    result += _cnt;
                    day += _cnt;
                }
            }

            return result;
        }
    }
}

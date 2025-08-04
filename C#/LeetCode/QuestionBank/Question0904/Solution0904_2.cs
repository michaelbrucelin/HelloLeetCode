using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0904
{
    public class Solution0904_2 : Interface0904
    {
        /// <summary>
        /// 滑动窗口
        /// </summary>
        /// <param name="fruits"></param>
        /// <returns></returns>
        public int TotalFruit(int[] fruits)
        {
            int result = 0, len = fruits.Length, pl = 0, pr = 0;
            Dictionary<int, int> map = new Dictionary<int, int>();
            while (pr < len)
            {
                while (pr < len && map.Count < 3)
                {
                    if (map.ContainsKey(fruits[pr]))
                    {
                        map[fruits[pr]]++;
                    }
                    else
                    {
                        map.Add(fruits[pr], 1);
                        if (map.Count == 3) break;
                    }
                    pr++;
                }
                result = Math.Max(result, pr - pl);
                if (++pr == len) break;
                while (map.Count == 3)
                {
                    if (map[fruits[pl]] == 1) map.Remove(fruits[pl]); else map[fruits[pl]]--;
                    pl++;
                }
            }

            return result;
        }
    }
}

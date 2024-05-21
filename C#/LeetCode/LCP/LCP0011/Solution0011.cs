using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCP.LCP0011
{
    public class Solution0011 : Interface0011
    {
        /// <summary>
        /// 数学
        /// 就是统计不同的score的数量
        /// </summary>
        /// <param name="scores"></param>
        /// <returns></returns>
        public int ExpectNumber(int[] scores)
        {
            // HashSet<int> set = new HashSet<int>();
            // foreach (int score in scores) set.Add(score);
            HashSet<int> set = [.. scores];

            return set.Count;
        }
    }
}

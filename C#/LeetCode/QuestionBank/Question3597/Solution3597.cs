using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3597
{
    public class Solution3597 : Interface3597
    {
        /// <summary>
        /// Hash + 双指针
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public IList<string> PartitionString(string s)
        {
            if (s.Length == 1) return [s];

            List<string> result = [];
            HashSet<string> set = [];
            int pl = 0, pr = -1, len = s.Length;
            while (pl < len)
            {
                while (++pr < len && set.Contains(s[pl..(pr + 1)])) ;
                if (pr == len) break;
                result.Add(s[pl..(pr + 1)]);
                set.Add(result[^1]);
                pl = pr + 1;
            }

            return result;
        }
    }
}

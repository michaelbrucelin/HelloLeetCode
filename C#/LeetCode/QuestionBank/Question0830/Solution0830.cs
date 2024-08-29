using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0830
{
    public class Solution0830 : Interface0830
    {
        /// <summary>
        /// 遍历，双指针
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public IList<IList<int>> LargeGroupPositions(string s)
        {
            List<IList<int>> result = new List<IList<int>>();
            if (s.Length <= 2) return result;

            int len = s.Length, p1 = 0, p2 = 1;
            while (p1 < len && p2 < len)
            {
                if (s[p1] != s[p2])
                {
                    if (p2 - p1 >= 3) result.Add([p1, p2 - 1]);
                    p1 = p2++;
                }
                else
                {
                    p2++;
                }
            }
            if (len - p1 >= 3 && s[len - 1] == s[p1]) result.Add([p1, len - 1]);

            return result;
        }

        public IList<IList<int>> LargeGroupPositions2(string s)
        {
            List<IList<int>> result = new List<IList<int>>();
            int len = s.Length, p1 = 0, p2;
            while (p1 < len)
            {
                p2 = p1;
                while (p2 + 1 < len && s[p2 + 1] == s[p1]) p2++;
                if (p2 - p1 >= 2) result.Add([p1, p2]);
                p1 = p2 + 1;
            }

            return result;
        }
    }
}

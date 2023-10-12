using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0830
{
    public class Solution0830_2 : Interface0830
    {
        /// <summary>
        /// 遍历，单指针
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public IList<IList<int>> LargeGroupPositions(string s)
        {
            List<IList<int>> result = new List<IList<int>>();
            if (s.Length <= 2) return result;

            int len = 1;
            for (int i = 1; i < s.Length; i++)
            {
                if (s[i] != s[i - 1])
                {
                    if (len >= 3) result.Add(new int[] { i - len, i - 1 });
                    len = 1;
                }
                else
                {
                    len++;
                }
            }
            if (len >= 3) result.Add(new int[] { s.Length - len, s.Length - 1 });

            return result;
        }
    }
}

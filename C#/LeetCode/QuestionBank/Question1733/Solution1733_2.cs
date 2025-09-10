using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1733
{
    public class Solution1733_2 : Interface1733
    {
        /// <summary>
        /// 逻辑同Solution1733，将HashSet<int>改为
        /// </summary>
        /// <param name="n"></param>
        /// <param name="languages"></param>
        /// <param name="friendships"></param>
        /// <returns></returns>
        public int MinimumTeachings(int n, int[][] languages, int[][] friendships)
        {
            int m = languages.Length;
            BigInteger[] langs = new BigInteger[m + 1];
            BigInteger big1 = 1;
            for (int i = 1; i <= m; i++) foreach (int x in languages[i - 1]) langs[i] |= (big1 << x);
            List<int[]> friends = new List<int[]>();
            foreach (int[] item in friendships) if ((langs[item[0]] & langs[item[1]]) == 0) friends.Add(item);

            int result = m, _result;
            BigInteger[] _langs = new BigInteger[m + 1];
            for (int i = 1; i <= n; i++)
            {
                _result = 0;
                Array.Copy(langs, _langs, m + 1);
                foreach (int[] item in friends)
                {
                    if ((_langs[item[0]] & (big1 << i)) == 0) { _result++; _langs[item[0]] |= (big1 << i); }
                    if ((_langs[item[1]] & (big1 << i)) == 0) { _result++; _langs[item[1]] |= (big1 << i); }
                }
                result = Math.Min(result, _result);
            }

            return result;
        }
    }
}

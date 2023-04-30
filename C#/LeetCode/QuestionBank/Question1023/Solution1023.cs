using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1023
{
    public class Solution1023 : Interface1023
    {
        /// <summary>
        /// 双指针
        /// </summary>
        /// <param name="queries"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public IList<bool> CamelMatch(string[] queries, string pattern)
        {
            bool[] result = new bool[queries.Length];
            for (int i = 0; i < result.Length; i++)
                result[i] = IsCamelMatch(queries[i], pattern);

            return result;
        }

        private bool IsCamelMatch(string query, string pattern)
        {
            int lenq = query.Length, lenp = pattern.Length, pq = 0, pp = 0;
            while (pq < lenq && pp < lenp)
            {
                if (query[pq] == pattern[pp])
                {
                    pq++; pp++;
                }
                else
                {
                    if (char.IsLower(query[pq])) pq++; else return false;
                }
            }

            if (pq < lenq)
            {
                while (pq < lenq) if (char.IsUpper(query[pq++])) return false;
                return true;
            }
            else if (pp < lenp)
                return false;
            else  // pq == lenq && pp == lenp
                return true;
        }
    }
}

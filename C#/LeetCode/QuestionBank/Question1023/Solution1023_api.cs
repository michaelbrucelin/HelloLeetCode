using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1023
{
    public class Solution1023_api : Interface1023
    {
        public IList<bool> CamelMatch(string[] queries, string pattern)
        {
            bool[] result = new bool[queries.Length];
            string lower = "[a-z]*";
            string _pattern = @$"^{lower}{string.Join(lower, pattern.Select(c => c))}{lower}$";
            for (int i = 0; i < result.Length; i++)
                result[i] = Regex.IsMatch(queries[i], _pattern);

            return result;
        }

        public IList<bool> CamelMatch2(string[] queries, string pattern)
        {
            string lower = "[a-z]*";
            string _pattern = @$"^{lower}{string.Join(lower, pattern.Select(c => c))}{lower}$";

            return queries.Select(s => Regex.IsMatch(s, _pattern)).ToArray();
        }
    }
}

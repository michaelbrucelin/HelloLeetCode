using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0819
{
    public class Solution0819_api : Interface0819
    {
        /// <summary>
        /// API
        /// </summary>
        /// <param name="paragraph"></param>
        /// <param name="banned"></param>
        /// <returns></returns>
        public string MostCommonWord(string paragraph, string[] banned)
        {
            HashSet<string> ban = new HashSet<string>(banned);

            return paragraph.Split(new char[] { ' ', '!', '?', '\'', ',', ';', '.' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(s => s.ToLower())
                            .Where(s => !banned.Contains(s))
                            .GroupBy(s => s)
                            .OrderByDescending(s => s.Count())
                            .FirstOrDefault()
                            .Key;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1805
{
    public class Solution1805_2 : Interface1805
    {
        private static readonly char[] az = Enumerable.Range('a', 26).Select(i => (char)i).ToArray();
        /// <summary>
        /// 使用.Net API
        /// 测试用例中有超长的数字，导致转换为数字失败
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public int NumDifferentIntegers(string word)
        {
            var t = word.Split(az);
            return word.Split(az, StringSplitOptions.RemoveEmptyEntries)
                .Select(s => Convert.ToUInt64(s))
                .Distinct()
                .Count();
        }
    }
}

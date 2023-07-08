using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1566
{
    public class Solution1566_2 : Interface1566
    {
        /// <summary>
        /// 正则
        /// 由于1 <= arr[i] <= 100，可以将arr看作由ASCII码组成的string，然后正则解决
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="m"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public bool ContainsPattern(int[] arr, int m, int k)
        {
            if (m * k > arr.Length) return false;

            string str = new string(arr.Select(i => (char)i).ToArray());

            return Regex.IsMatch(str, @$"(.{{{m}}})\1{{{k - 1},}}");
        }

        /// <summary>
        /// 正则
        /// 更通用的实现方式
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="m"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public bool ContainsPattern2(int[] arr, int m, int k)
        {
            if (m * k > arr.Length) return false;

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < arr.Length; i++) sb.Append($"[{arr[i]}]");
            string str = sb.ToString();

            return Regex.IsMatch(str, @$"((\[\d+\]){{{m}}})\1{{{k - 1},}}");
        }
    }
}

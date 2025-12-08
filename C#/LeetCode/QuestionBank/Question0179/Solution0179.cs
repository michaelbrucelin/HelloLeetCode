using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0179
{
    public class Solution0179 : Interface0179
    {
        /// <summary>
        /// 自定义排序
        /// 如果s1是s2的前缀或s2是s1的前缀，则称s1与s2之间有前缀关系
        /// 排序规则：
        ///     1. 如果s1与s2没有前缀关系，字典序排序
        ///     2. 如果s1与s2有前缀关系，去掉前缀（递归）再字典序排序
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public string LargestNumber(int[] nums)
        {
            if (nums.Length == 1) return nums[0].ToString();

            int len = nums.Length;
            string[] strs = new string[len];
            for (int i = 0; i < len; i++) strs[i] = nums[i].ToString();
            IComparer<string> comparer = Comparer<string>.Create((s1, s2) =>
            {
                (s1, s2) = rec(s1, s2);
                return s2.CompareTo(s1);
            });
            Array.Sort(strs, comparer);
            if (strs[0] == "0") return "0";

            StringBuilder result = new StringBuilder();
            for (int i = 0; i < len; i++) result.Append(strs[i]);
            return result.ToString();

            (string, string) rec(string s1, string s2)
            {
                if (s1 == s2) return (s1, s2);
                if (s1.StartsWith(s2)) return rec(s1.Substring(s2.Length), s2);
                if (s2.StartsWith(s1)) return rec(s1, s2.Substring(s1.Length));
                return (s1, s2);
            }
        }
    }
}

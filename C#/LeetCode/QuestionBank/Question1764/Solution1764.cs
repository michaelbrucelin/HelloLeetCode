using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1764
{
    public class Solution1764 : Interface1764
    {
        /// <summary>
        /// 投机取巧一下，通过API将整型数组转为字符串求解
        /// </summary>
        /// <param name="groups"></param>
        /// <param name="nums"></param>
        /// <returns></returns>
        public bool CanChoose(int[][] groups, int[] nums)
        {
            if (groups.Select(arr => arr.Length).Sum() > nums.Length) return false;

            string str = $",{nums.Select(i => i.ToString()).Aggregate((s1, s2) => $"{s1},{s2}")},";
            var subs = groups.Select(arr => $",{arr.Select(i => i.ToString()).Aggregate((s1, s2) => $"{s1},{s2}")},");
            int start = 0, index = -1;
            foreach (string sub in subs)
            {
                if ((index = str.IndexOf(sub, start)) == -1) return false;
                start = index + sub.Length - 1;
            }

            return true;
        }

        /// <summary>
        /// 投机取巧一下，通过API将整型数组转为字符串利用正则求解
        /// </summary>
        /// <param name="groups"></param>
        /// <param name="nums"></param>
        /// <returns></returns>
        public bool CanChoose2(int[][] groups, int[] nums)
        {
            if (groups.Select(arr => arr.Length).Sum() > nums.Length) return false;

            string str = $",{nums.Select(i => i.ToString()).Aggregate((s1, s2) => $"{s1},{s2}")},";
            string pattern = groups.Select(arr => arr.Select(i => i.ToString()).Aggregate((s1, s2) => $"{s1},{s2}"))
                                .Aggregate((s1, s2) => $"{s1},.*{s2}");
            pattern = $",{pattern},";

            return Regex.IsMatch(str, pattern);
        }

        /// <summary>
        /// 投机取巧一下，通过API将整型数组转为Unicode字符求解
        /// 这种解法是不可以的，因为数字的范围太大了
        /// </summary>
        /// <param name="groups"></param>
        /// <param name="nums"></param>
        /// <returns></returns>
        public bool CanChoose3(int[][] groups, int[] nums)
        {
            if (groups.Select(arr => arr.Length).Sum() > nums.Length) return false;

            string str = nums.Select(i => Convert.ToChar(i).ToString()).Aggregate((s1, s2) => $"{s1}{s2}");
            var subs = groups.Select(arr => arr.Select(i => Convert.ToChar(i).ToString()).Aggregate((s1, s2) => $"{s1},{s2}"));
            int start = 0, index = -1;
            foreach (string sub in subs)
            {
                if ((index = str.IndexOf(sub, start)) == -1) return false;
                start = index + sub.Length;
            }

            return true;
        }
    }
}

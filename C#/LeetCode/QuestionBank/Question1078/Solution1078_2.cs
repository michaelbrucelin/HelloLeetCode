using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1078
{
    public class Solution1078_2 : Interface1078
    {
        /// <summary>
        /// 与Solution1078一样，利用API拆分数组
        /// </summary>
        /// <param name="text"></param>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public string[] FindOcurrences(string text, string first, string second)
        {
            string[] strs = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            List<string> result = new List<string>();
            for (int i = 2; i < strs.Length; i++)
                if (strs[i - 2] == first && strs[i - 1] == second) result.Add(strs[i]);

            return result.ToArray();
        }
    }
}

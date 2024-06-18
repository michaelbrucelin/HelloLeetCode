using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2288
{
    public class Solution2288_2 : Interface2288
    {
        /// <summary>
        /// API
        /// </summary>
        /// <param name="sentence"></param>
        /// <param name="discount"></param>
        /// <returns></returns>
        public string DiscountPrices(string sentence, int discount)
        {
            StringBuilder buffer = new StringBuilder();
            string[] words = sentence.Split(' ');
            Regex regex = new Regex(@"^\$\d+$");
            decimal num;

            foreach (string word in words)
            {
                if (regex.IsMatch(word))
                {
                    buffer.Append(word[0]);
                    num = decimal.Parse(word[1..]) * (100 - discount) / 100;
                    buffer.Append($"{num:F2}");
                }
                else
                {
                    buffer.Append(word);
                }
                buffer.Append(' ');
            }

            return buffer.Remove(buffer.Length - 1, 1).ToString();
        }
    }
}

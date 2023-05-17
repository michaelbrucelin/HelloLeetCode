using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2264
{
    public class Solution2264_3 : Interface2264
    {
        /// <summary>
        /// 遍历
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public string LargestGoodInteger(string num)
        {
            string result = "";
            for (int i = 0; i < num.Length - 2; i++)
            {
                if (num[i] == num[i + 1] && num[i] == num[i + 2] && string.CompareOrdinal(num.Substring(i, 3), result) > 0)
                    result = num.Substring(i, 3);
                if (result == "999") return "999";
            }

            return result;
        }
    }
}

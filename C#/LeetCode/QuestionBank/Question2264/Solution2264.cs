using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2264
{
    public class Solution2264 : Interface2264
    {
        /// <summary>
        /// 暴力
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public string LargestGoodInteger(string num)
        {
            if (num.Contains("999")) return "999";
            if (num.Contains("888")) return "888";
            if (num.Contains("777")) return "777";
            if (num.Contains("666")) return "666";
            if (num.Contains("555")) return "555";
            if (num.Contains("444")) return "444";
            if (num.Contains("333")) return "333";
            if (num.Contains("222")) return "222";
            if (num.Contains("111")) return "111";
            if (num.Contains("000")) return "000";
            return "";
        }

        public string LargestGoodInteger2(string num)
        {
            foreach (string str in new string[] { "999", "888", "777", "666", "555", "444", "333", "222", "111", "000" })
                if (num.Contains(str)) return str;

            return "";
        }

        public string LargestGoodInteger3(string num)
        {
            string str;
            for (int i = 9; i >= 0; i--)
                if (num.Contains(str = new string((char)(i | 48), 3))) return str;

            return "";
        }
    }
}

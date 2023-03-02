using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview0502
{
    public class Solution0502 : Interface0502
    {
        public string PrintBin(double num)
        {
            StringBuilder result = new StringBuilder("0.");

            int len = 2;
            while (num > 0 && len < 32)
            {
                if ((num *= 2) < 1) result.Append('0');
                else
                {
                    result.Append('1'); num -= 1;
                }
            }

            return result.Length <= 32 ? result.ToString() : "ERROR";
        }

        /// <summary>
        /// 更严谨，但是略慢
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public string PrintBin2(double num)
        {
            StringBuilder result = new StringBuilder("0.");
            HashSet<decimal> visited = new HashSet<decimal>();

            decimal _num = Convert.ToDecimal(num);
            while (_num > 0)
            {
                if (visited.Contains(_num)) return "ERROR";
                visited.Add(_num);
                if ((_num *= 2) < 1) result.Append('0');
                else
                {
                    result.Append('1'); _num -= 1;
                }
            }

            return result.ToString();
        }
    }
}

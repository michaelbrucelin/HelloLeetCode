using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3280
{
    public class Solution3280 : Interface3280
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public string ConvertDateToBinary(string date)
        {
            int YY = 0, MM = 0, DD = 0;
            YY = (date[0] & 15) * 1000 + (date[1] & 15) * 100 + (date[2] & 15) * 10 + (date[3] & 15);
            MM = (date[5] & 15) * 10 + (date[6] & 15);
            DD = (date[8] & 15) * 10 + (date[9] & 15);

            return $"{Dec2Bin(YY)}-{Dec2Bin(MM)}-{Dec2Bin(DD)}";

            string Dec2Bin(int x)
            {
                List<char> chars = new List<char>();
                while (x > 0)
                {
                    chars.Add((char)((x & 1) | 48));
                    x >>= 1;
                }

                chars.Reverse();
                return new string(chars.ToArray());
            }
        }
    }
}

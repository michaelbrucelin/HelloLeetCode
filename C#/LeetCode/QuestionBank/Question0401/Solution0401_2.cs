using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0401
{
    public class Solution0401_2 : Interface0401
    {
        /// <summary>
        /// 二进制遍历
        /// 遍历0-11的二进制中1的数量，可以得到可能的小时
        /// 遍历0-59的二进制中1的数量，可以得到可能的分钟
        /// </summary>
        /// <param name="turnedOn"></param>
        /// <returns></returns>
        public IList<string> ReadBinaryWatch(int turnedOn)
        {
            List<string> result = new List<string>();
            for (int hh = 0; hh < 12; hh++) for (int mi = 0, hhcnt = BitCount(hh), micnt; mi < 60; mi++)
                {
                    micnt = BitCount(mi);
                    if (hhcnt + micnt == turnedOn) result.Add($"{hh}:{mi:D2}");
                }
            return result;
        }

        /// <summary>
        /// 二进制遍历
        /// 遍历0-11的二进制中1的数量，可以得到可能的小时
        /// 遍历0-59的二进制中1的数量，可以得到可能的分钟
        /// 简化
        /// 把小时与分钟连在一起分析，那么遍历0-1023二进制中1的数量，如果数量正确，再分析二进制高4位（小时）与低4位（分钟）的有效性
        /// </summary>
        /// <param name="turnedOn"></param>
        /// <returns></returns>
        public IList<string> ReadBinaryWatch2(int turnedOn)
        {
            List<string> result = new List<string>();
            for (int i = 0; i < 1024; i++)
            {
                if (BitCount(i) != turnedOn) continue;
                int hour = i >> 6, minute = i & 63;
                if (hour < 12 && minute < 60) result.Add($"{hour}:{minute:D2}");
            }
            return result;
        }

        private int BitCount(int n)
        {
            int result = 0;

            while (n > 0)
            {
                result++; n &= n - 1;
            }

            return result;
        }
    }
}

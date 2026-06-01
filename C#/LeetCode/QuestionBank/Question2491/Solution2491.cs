using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2491
{
    public class Solution2491 : Interface2491
    {
        /// <summary>
        /// 贪心
        /// </summary>
        /// <param name="skill"></param>
        /// <returns></returns>
        public long DividePlayers(int[] skill)
        {
            int sum = 0, len = skill.Length;
            int[] freq = new int[1001];
            for (int i = 0; i < len; i++) { freq[skill[i]]++; sum += skill[i]; }
            len >>= 1;
            if (sum % len != 0) return -1;

            long result = 0;
            sum /= len;
            int x = 1, y = 1000;
            while (x <= y)
            {
                while (x <= y && freq[x] == 0) x++;
                while (y >= x && freq[y] == 0) y--;
                if (x > y) break;
                if (freq[x] != freq[y] || x + y != sum) return -1;
                if (x != y)
                {
                    result += 1L * x * y * freq[x];
                }
                else
                {
                    if ((freq[x] & 1) != 0) return -1;
                    result += 1L * x * y * freq[x] >> 1;
                }
                x++; y--;
            }

            return result;
        }
    }
}

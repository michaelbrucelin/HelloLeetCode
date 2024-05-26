using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCP.LCP0077
{
    public class Solution0077 : Interface0077
    {
        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="runes"></param>
        /// <returns></returns>
        public int RuneReserve(int[] runes)
        {
            Array.Sort(runes);
            int result = 1, _result = 1, len = runes.Length;
            for (int i = 1; i < len; i++)
            {
                if (runes[i] <= runes[i - 1] + 1)
                {
                    _result++;
                }
                else
                {
                    result = Math.Max(result, _result); _result = 1;
                }
            }
            result = Math.Max(result, _result);

            return result;
        }
    }
}

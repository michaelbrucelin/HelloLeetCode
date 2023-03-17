using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCP.LCP0061
{
    public class Solution0061 : Interface0061
    {
        public int TemperatureTrend(int[] temperatureA, int[] temperatureB)
        {
            int result = 0, len = temperatureA.Length;
            for (int i = 1, _result; i < len; i++)
            {
                if (Math.Sign(temperatureA[i] - temperatureA[i - 1]) != Math.Sign(temperatureB[i] - temperatureB[i - 1])) continue;
                else
                {
                    _result = 1;
                    while (i + 1 < len && Math.Sign(temperatureA[i + 1] - temperatureA[i]) == Math.Sign(temperatureB[i + 1] - temperatureB[i]))
                    {
                        _result++; i++;
                    }
                    result = Math.Max(result, _result);
                }
            }

            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCP.LCP0061
{
    public class Solution0061_2 : Interface0061
    {
        public int TemperatureTrend(int[] temperatureA, int[] temperatureB)
        {
            int result = 0, _result = 0, len = temperatureA.Length;
            for (int i = 1; i < len; i++)
            {
                if ((temperatureA[i] - temperatureA[i - 1]) * (temperatureB[i] - temperatureB[i - 1]) > 0
                    || (temperatureA[i] == temperatureA[i - 1] && temperatureB[i] == temperatureB[i - 1]))
                {
                    _result++;
                }
                else
                {
                    result = Math.Max(result, _result);
                    _result = 0;
                }
            }
            result = Math.Max(result, _result);

            return result;
        }
    }
}

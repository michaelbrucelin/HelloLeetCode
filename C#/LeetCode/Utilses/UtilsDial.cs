using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Utilses
{
    public static class UtilsDial
    {
        public static List<int> DialPrime(int low, int high)
        {
            List<int> result = new List<int>();
            for (int i = low; i <= high; i++) if (UtilsMath.IsPrime(i)) result.Add(i);

            return result;
        }
    }
}

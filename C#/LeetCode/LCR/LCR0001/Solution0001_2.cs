using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0001
{
    public class Solution0001_2 : Interface0001
    {
        /// <summary>
        /// 逆快速幂
        /// 本质上依然是Solution0001中的“除法转减法”，只不过加速了这个过程。
        /// 本质上也是b进制映射。
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public int Divide(int a, int b)
        {
            // if (b == 0) throw new Exception("the divisor is equal to 0.");  // 题目保证了b != 0
            if (a == 0) return 0;
            if (a == int.MinValue && b == -1) return int.MaxValue;
            if (b == 1) return a; else if (b == -1) return -a;

            int flag = 1;
            if (a > 0) { a = -a; flag *= -1; }
            if (b > 0) { b = -b; flag *= -1; }

            int result = 0;
            // while (a <= b) { result++; a -= b; }
            int BORDER = -(1 << 30), _b = b;
            List<int> map = new List<int>() { _b };
            while (_b >= BORDER) { _b <<= 1; map.Add(_b); }
            for (int i = map.Count - 1; i >= 0; i--) if (a <= map[i])
                {
                    result += 1 << i; a -= map[i];
                }

            return result * flag;
        }
    }
}

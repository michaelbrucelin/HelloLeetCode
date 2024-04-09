using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0146
{
    public class Solution0146 : Interface0146
    {
        /// <summary>
        /// 状态机
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public int[] SpiralArray(int[][] array)
        {
            if (array.Length == 0) return new int[0];

            int rcnt = array.Length, ccnt = array[0].Length;
            int[] result = new int[rcnt * ccnt];
            int state = -1, l = 0, r = ccnt - 1, u = 0, b = rcnt - 1, ptr = 0, pr, pc, len = result.Length;
            while (ptr < len)
            {
                state = (state + 1) % 4;
                switch (state)
                {
                    case 0:  // 向右
                        pr = u++;
                        for (pc = l; pc <= r; pc++) result[ptr++] = array[pr][pc];
                        break;
                    case 1:  // 向下
                        pc = r--;
                        for (pr = u; pr <= b; pr++) result[ptr++] = array[pr][pc];
                        break;
                    case 2:  // 向左
                        pr = b--;
                        for (pc = r; pc >= l; pc--) result[ptr++] = array[pr][pc];
                        break;
                    case 3:  // 向上
                        pc = l++;
                        for (pr = b; pr >= u; pr--) result[ptr++] = array[pr][pc];
                        break;
                    default:
                        break;
                }
            }

            return result;
        }
    }
}

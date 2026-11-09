using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview1616
{
    public class Solution1616 : Interface1616
    {
        /// <summary>
        /// 预处理
        /// 预处理前缀树组的最大值与后缀数组的最小值，然后模拟就可以了
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public int[] SubSort(int[] array)
        {
            if (array.Length < 2) return [-1, -1];

            int len = array.Length;
            bool flag = true;
            int[] lmax = new int[len], rmin = new int[len];
            lmax[0] = array[0];
            for (int i = 1; i < len; i++)
            {
                lmax[i] = Math.Max(lmax[i - 1], array[i]);
                if (lmax[i] != array[i]) flag = false;
            }
            if (flag) return [-1, -1];
            rmin[len - 1] = array[len - 1];
            for (int i = len - 2; i >= 0; i--) rmin[i] = Math.Min(rmin[i + 1], array[i]);

            int[] result = [0, len - 1];
            for (int i = 0; i < len - 1; i++) if (array[i] > rmin[i + 1]) { result[0] = i; break; }
            for (int i = len - 1; i > 0; i--) if (array[i] < lmax[i - 1]) { result[1] = i; break; }

            return result;
        }
    }
}

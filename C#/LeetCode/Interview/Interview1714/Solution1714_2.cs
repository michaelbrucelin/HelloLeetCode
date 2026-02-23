using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview1714
{
    public class Solution1714_2 : Interface1714
    {
        /// <summary>
        /// 快速选择
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[] SmallestK(int[] arr, int k)
        {
            if (k == arr.Length) return arr;


            return arr[0..k];

            int partition(int lo, int hi)
            {
                throw new NotImplementedException();
            }
        }
    }
}

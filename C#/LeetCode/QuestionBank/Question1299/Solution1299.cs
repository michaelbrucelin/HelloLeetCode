using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1299
{
    public class Solution1299 : Interface1299
    {
        public int[] ReplaceElements(int[] arr)
        {
            for (int i = arr.Length - 1, rmax = -1, _t; i >= 0; i--)
            {
                _t = arr[i]; arr[i] = rmax; rmax = Math.Max(rmax, _t);
            }

            return arr;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1385
{
    public class Solution1385 : Interface1385
    {
        /// <summary>
        /// 暴力枚举
        /// </summary>
        /// <param name="arr1"></param>
        /// <param name="arr2"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        public int FindTheDistanceValue(int[] arr1, int[] arr2, int d)
        {
            int result = 0;
            bool flag;
            foreach (int num1 in arr1)
            {
                flag = true;
                foreach (int num2 in arr2)
                {
                    if (Math.Abs(num1 - num2) <= d) { flag = false; break; }
                }
                if (flag) result++;
            }

            return result;
        }
    }
}

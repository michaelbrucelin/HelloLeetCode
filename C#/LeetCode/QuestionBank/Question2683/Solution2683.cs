using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2683
{
    public class Solution2683 : Interface2683
    {
        /// <summary>
        /// 递推
        /// </summary>
        /// <param name="derived"></param>
        /// <returns></returns>
        public bool DoesValidArrayExist(int[] derived)
        {
            int len = derived.Length;
            int[] original = new int[len];
            for (int i = 1; i < len; i++) original[i] = original[i - 1] ^ derived[i - 1];

            return (original[^1] ^ derived[^1]) == 0;
        }

        /// <summary>
        /// 逻辑同DoesValidArrayExist()，滚动数组
        /// </summary>
        /// <param name="derived"></param>
        /// <returns></returns>
        public bool DoesValidArrayExist2(int[] derived)
        {
            int original = 0, len = derived.Length;
            for (int i = 1; i < len; i++) original ^= derived[i - 1];

            return (original ^ derived[^1]) == 0;
        }
    }
}

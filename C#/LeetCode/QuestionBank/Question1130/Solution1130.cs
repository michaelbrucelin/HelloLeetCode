using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1130
{
    public class Solution1130 : Interface1130
    {
        /// <summary>
        /// 分治
        /// 1. 中序遍历，那么叶子结点就是从左到右（这个与中序没关系，前序与后序也是一样的）
        /// 2. arr的长度是len的话，二叉树有len-1个非叶子结点
        ///     假定二叉树有n0（len）个叶子结点，n1个度为1的结点，n2个度为2的结点
        ///     那么总结点数就是n = n0 + n1 + n2，那么总“边”数为n0 + n1 + n2 - 1，因为只有根节点没有“进入的边”
        ///     另外总边数也可以表示为：n1 + n2 * 2，则：n0 + n1 + n2 - 1 = n1 + n2 * 2
        ///     则：n2 = n0 - 1
        /// 上边第2点结论与本题无关，想到就写在这里了，这里主要根据第1点结论，分治（自底向上递归）即可。
        /// 
        /// 逻辑没问题，提交会超时，参考测试用例03
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int MctFromLeafValues(int[] arr)
        {
            int result = int.MaxValue, len = arr.Length;
            for (int i = 0; i < len - 1; i++) result = Math.Min(result, DivideAndConquer(arr, 0, len - 1, i));

            return result;
        }

        private int DivideAndConquer(int[] arr, int left, int right, int divide)
        {
            int lmct = 0, rmct = 0;
            if (left < divide)
            {
                lmct = int.MaxValue;
                for (int i = left; i < divide; i++) lmct = Math.Min(lmct, DivideAndConquer(arr, left, divide, i));
            }
            if (divide + 1 < right)
            {
                rmct = int.MaxValue;
                for (int i = divide + 1; i < right; i++) rmct = Math.Min(rmct, DivideAndConquer(arr, divide + 1, right, i));
            }

            return MaxValue(arr, left, divide) * MaxValue(arr, divide + 1, right) + lmct + rmct;
        }

        /// <summary>
        /// 与MctFromLeafValues()一样，分治时少传了一个参数
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int MctFromLeafValues2(int[] arr)
        {
            return DivideAndConquer(arr, 0, arr.Length - 1);
        }

        private int DivideAndConquer(int[] arr, int left, int right)
        {
            if (left >= right) return 0;

            int result = int.MaxValue, lmct, rmct;
            for (int i = left; i < right; i++)  // [left, i] [i+1, right]
            {
                lmct = DivideAndConquer(arr, left, i);
                rmct = DivideAndConquer(arr, i + 1, right);
                result = Math.Min(result, MaxValue(arr, left, i) * MaxValue(arr, i + 1, right) + lmct + rmct);
            }

            return result;
        }

        private int MaxValue(int[] arr, int left, int right)
        {
            int result = arr[left];
            for (int i = left + 1; i <= right; i++) result = Math.Max(result, arr[i]);
            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0932
{
    public class Solution0932_off : Interface0932
    {
        /// <summary>
        /// 手写官解
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int[] BeautifulArray(int n)
        {
            if (n == 1) return [1];
            if (n == 2) return [1, 2];

            int[] result = new int[n];
            int[] left = BeautifulArray((n + 1) >> 1);
            int[] right = BeautifulArray(n >> 1);
            int idx = 0, len = left.Length;
            for (int i = 0; i < len; i++) result[idx++] = (left[i] << 1) - 1;
            len = right.Length;
            for (int i = 0; i < len; i++) result[idx++] = right[i] << 1;

            return result;
        }

        /// <summary>
        /// 逻辑完全同BeautifulArray2()，始终操作一个数组
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int[] BeautifulArray2(int n)
        {
            if (n == 1) return [1];
            if (n == 2) return [1, 2];

            int[] result = new int[n];
            _BeautifulArray2(n, 0, n - 1);

            return result;

            void _BeautifulArray2(int n, int left, int right)
            {
                if (n == 1) { result[left] = 1; return; }
                if (n == 2) { result[left] = 1; result[right] = 2; return; }

                int mid = left + ((right - left) >> 1);
                _BeautifulArray2((n + 1) >> 1, left, mid);
                for (int i = left; i <= mid; i++) result[i] = (result[i] << 1) - 1;
                _BeautifulArray2(n >> 1, mid + 1, right);
                for (int i = mid + 1; i <= right; i++) result[i] = result[i] << 1;
            }
        }
    }
}

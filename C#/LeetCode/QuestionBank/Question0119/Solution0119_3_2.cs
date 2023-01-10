using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0119
{
    public class Solution0119_3_2 : Interface0119
    {
        /// <summary>
        /// 数学
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <returns></returns>
        public IList<int> GetRow(int rowIndex)
        {
            if (rowIndex == 0) return new int[] { 1 };

            int[] result = new int[rowIndex + 1]; result[0] = 1; result[rowIndex] = 1;
            for (int i = 1; i <= (rowIndex >> 1); i++) result[i] = (int)nCr(rowIndex, i);
            for (int i = 1; i <= (rowIndex >> 1); i++) result[rowIndex - i] = result[i];

            return result;
        }

        private long nCr(int n, int r)
        {
            if (n < 29 || (n == 29 && r < 15))
                return nCr_Fast(n, r);
            else
                return nCr_Slow(n, r);
        }

        private long nCr_Fast(int n, int r)
        {
            long result = 1;
            for (int i = 0; i < r; i++) result *= n - i;
            for (int i = 1; i <= r; i++) result /= i;

            return (int)result;
        }

        private long nCr_Slow(int n, int r)
        {
            int[] multip = new int[r];
            for (int i = 0; i < r; i++) multip[i] = n - i;
            Queue<int> divide = new Queue<int>();
            for (int i = 1; i <= r; i++) divide.Enqueue(i);

            while (divide.Count > 0)
            {
                int div = divide.Dequeue();
                for (int i = 0; i < multip.Length; i++)
                {
                    if (multip[i] > 1)
                    {
                        int gcd = GetGCD(multip[i], div);
                        multip[i] /= gcd; div /= gcd;
                        if (div == 1) break;
                    }
                }

                if (div != 1) divide.Enqueue(div);
            }

            long result = 1;
            for (int i = 0; i < r; i++) result *= multip[i];

            return result;
        }

        private int GetGCD(int x, int y)
        {
            if (x == y) return x;

            int move = 0;
            while (x != y)
            {
                if ((x & 1) == 0 && (y & 1) == 0)
                {
                    x >>= 1; y >>= 1; move++;
                }
                else if ((x & 1) == 0 && (y & 1) == 1) x >>= 1;
                else if ((x & 1) == 1 && (y & 1) == 0) y >>= 1;
                else
                {
                    if (x > y) x = (x - y) >> 1; else y = (y - x) >> 1;
                }
            }

            return x << move;
        }
    }
}

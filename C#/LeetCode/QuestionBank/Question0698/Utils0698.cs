using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0698
{
    public class Utils0698
    {
        public Utils0698()
        {
            stirling = new long[17, 17];
            for (int i = 1; i < 17; i++) for (int j = 1; j < 17; j++) stirling[i, j] = -1;
            stirling[0, 0] = 1;
        }

        public void Dial()
        {
            // for (int i = 1; i <= 16; i++) Dial(16, i);
            for (int i = 1; i <= 16; i++)
            {
                Stirling(16, i);
                Console.WriteLine($"n = {16}, k = {i}:\t{stirling[16, i]}");
            }
        }

        private void Dial(int n, int k)
        {
            long result = 1;
            for (int i = 0; i < k; i++) result *= n - i;
            for (int i = 0; i < n - k; i++) result *= k;

            Console.WriteLine($"n = {n}, k = {k}:\t{result}");
        }

        private long[,] stirling;

        private void Stirling(int n, int k)
        {
            if (stirling[n, k] >= 0) return;
            Stirling(n - 1, k);
            Stirling(n - 1, k - 1);
            stirling[n, k] = k * stirling[n - 1, k] + stirling[n - 1, k - 1];
        }
    }
}

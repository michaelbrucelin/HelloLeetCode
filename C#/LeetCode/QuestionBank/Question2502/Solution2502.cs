using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2502
{
    public class Solution2502
    {
    }

    /// <summary>
    /// 暴力解法
    /// </summary>
    public class Allocator : Interface2502
    {
        public Allocator(int n)
        {
            this.n = n;
            memory = new int[n];
        }

        private int n;
        private int[] memory;

        public int Allocate(int size, int mID)
        {
            int p = 0, q;
            while (p < n)
            {
                while (p < n && memory[p] != 0) p++;
                if (p + size > n) break;
                for (q = p + 1; q < p + size; q++) if (memory[q] != 0) goto CONTINUE;
                Array.Fill(memory, mID, p, size);
                return p;
            CONTINUE:;
                p = q + 1;
            }

            return -1;
        }

        public int FreeMemory(int mID)
        {
            int cnt = 0;
            for (int i = 0; i < n; i++) if (memory[i] == mID)
                {
                    memory[i] = 0; cnt++;
                }
            return cnt;
        }
    }
}

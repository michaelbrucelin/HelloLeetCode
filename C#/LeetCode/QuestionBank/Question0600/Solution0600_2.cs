using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0600
{
    public class Solution0600_2 : Interface0600
    {
        /// <summary>
        /// 逻辑同Solution0600，增加了记忆化搜索
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int FindIntegers(int n)
        {
            if (n < 3) return n + 1;

            int[] dial = new int[32];
            dial[0] = 2; dial[1] = 3;
            for (int i = 2; i < 32; i++) dial[i] = dial[i - 1] + dial[i - 2];

            List<int> bits = new List<int>();
            while (n > 0) { bits.Add(n & 1); n >>= 1; }
            Dictionary<int, int> memory = new Dictionary<int, int>();

            return _FindIntegers(bits.Count - 1);

            int _FindIntegers(int right)
            {
                if (memory.ContainsKey(right)) return memory[right];
                int _right = right;
                while (_right >= 0 && bits[_right] == 0) _right--;
                if (memory.ContainsKey(_right)) return memory[_right];

                if (_right < 0)
                {
                    memory.Add(right, 1); memory.TryAdd(_right, 1);
                }
                else if (_right == 0)
                {
                    memory.Add(right, 2); memory.TryAdd(_right, 2);
                }
                else
                {
                    if (bits[_right - 1] == 1)
                    {
                        memory.Add(right, dial[_right - 1] + (_right >= 2 ? dial[_right - 2] : 1));
                        memory.TryAdd(_right, dial[_right - 1] + (_right >= 2 ? dial[_right - 2] : 1));
                    }
                    else
                    {
                        memory.Add(right, dial[_right - 1] + _FindIntegers(_right - 2));
                        memory.TryAdd(_right, dial[_right - 1] + _FindIntegers(_right - 2));
                    }
                }

                return memory[right];
            }
        }
    }
}

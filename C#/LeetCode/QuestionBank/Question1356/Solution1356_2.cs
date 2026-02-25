using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1356
{
    public class Solution1356_2 : Interface1356
    {
        public int[] SortByBits(int[] arr)
        {
            Array.Sort(arr, (x, y) =>
            {
                if (x == y) return 0;
                int _x = count(x), _y = count(y);
                return _x != _y ? _x - _y : x - y;
            });
            return arr;

            static int count(int x)
            {
                x = (x & 0B0101010101010101) + ((x >> 1) & 0B0101010101010101);
                x = (x & 0B0011001100110011) + ((x >> 2) & 0B0011001100110011);
                x = (x & 0B0000111100001111) + ((x >> 4) & 0B0000111100001111);
                x = (x & 0B0000000011111111) + ((x >> 8) & 0B0000000011111111);
                return x;
            }
        }
    }
}

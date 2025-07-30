using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2411
{
    public class Solution2411_off : Interface2411
    {
        public int[] SmallestSubarrays(int[] nums)
        {
            int len = nums.Length;
            int[] result = new int[len]; Array.Fill(result, 1);
            int[] pos = new int[31]; Array.Fill(pos, -1);
            for (int i = len - 1, _num, _pos; i >= 0; i--)
            {
                _num = nums[i];
                while (_num > 0)
                {
                    _pos = BitOperations.Log2((uint)(_num - (_num & (_num - 1))));
                    pos[_pos] = i;
                    _num &= _num - 1;
                }
                for (int j = 0; j < 31; j++) result[i] = Math.Max(result[i], pos[j] - i + 1);
            }

            return result;
        }
    }
}

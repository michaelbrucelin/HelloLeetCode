using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0982
{
    public class Solution0982_3 : Interface0982
    {
        public int CountTriplets(int[] nums)
        {
            int result = 0, len = nums.Length;
            Dictionary<int, int> buffer = new Dictionary<int, int> { { 0, 0 } };
            int _key; for (int i = 0; i < len; i++)
            {
                if (nums[i] == 0) buffer[0] += len;
                else for (int j = 0; j < len; j++)
                    {
                        if (nums[j] == 0) buffer[0]++;
                        else
                        {
                            _key = nums[i] & nums[j]; buffer.TryAdd(_key, 0); buffer[_key]++;
                        }
                    }
            }

            for (int k = 0, sup = 0, sub = 0; k < len; k++)
            {
                sub = sup = nums[k] ^ 0xFFFF;
                do
                {
                    if (buffer.ContainsKey(sub)) result += buffer[sub];
                } while ((sub = (sub - 1) & sup) != sup);
            }

            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1630
{
    public class Solution1630_3 : Interface1630
    {
        public IList<bool> CheckArithmeticSubarrays(int[] nums, int[] l, int[] r)
        {
            bool[] result = new bool[l.Length];
            HashSet<int> set = new HashSet<int>();
            for (int i = 0, min = 0, max = 0, len = 0, diff = 0; i < l.Length; i++)
            {
                min = max = nums[l[i]]; len = r[i] - l[i] + 1;
                for (int j = l[i] + 1; j <= r[i]; j++)
                {
                    min = Math.Min(min, nums[j]);
                    max = Math.Max(max, nums[j]);
                }
                if (min == max)
                {
                    result[i] = true;
                }
                else
                {
                    if ((diff = (max - min) / (len - 1)) * (len - 1) == (max - min))
                    {
                        set.Clear();
                        for (int j = 0; j < len; j++) set.Add(min + diff * j);
                        for (int j = l[i]; j <= r[i]; j++)
                        {
                            if (set.Contains(nums[j])) set.Remove(nums[j]); else goto False;
                        }
                        result[i] = true; continue;
                        False:;
                    }
                }
            }

            return result;
        }
    }
}

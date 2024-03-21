using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2671
{
    public class Solution2671
    {
    }

    /// <summary>
    /// 双哈希表
    /// </summary>
    public class FrequencyTracker : Interface2671
    {
        public FrequencyTracker()
        {
            nums = new Dictionary<int, int>();
            freq = new Dictionary<int, HashSet<int>>();
        }

        private Dictionary<int, int> nums;
        private Dictionary<int, HashSet<int>> freq;

        public void Add(int number)
        {
            if (nums.ContainsKey(number))
            {
                DelFreq(number);
                nums[number]++;
            }
            else
            {
                nums.Add(number, 1);
            }
            AddFreq(number);
        }

        public void DeleteOne(int number)
        {
            if (nums.ContainsKey(number))
            {
                DelFreq(number);
                nums[number]--;
                if (nums[number] == 0) nums.Remove(number); else AddFreq(number);
            }
        }

        private void AddFreq(int number)
        {
            if (freq.ContainsKey(nums[number]))
            {
                freq[nums[number]].Add(number);
            }
            else
            {
                freq.Add(nums[number], new HashSet<int>() { number });
            }
        }

        private void DelFreq(int number)
        {
            freq[nums[number]].Remove(number);
            if (freq[nums[number]].Count == 0) freq.Remove(nums[number]);
        }

        public bool HasFrequency(int frequency)
        {
            return freq.ContainsKey(frequency);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3321
{
    public class Solution3321 : Interface3321
    {
        public long[] FindXSum(int[] nums, int k, int x)
        {
            throw new NotImplementedException();
        }
        /* public int[] FindXSum(int[] nums, int k, int x)
{
    int len = nums.Length;
    int[] result = new int[len - k + 1];

    if (x == k)
    {
        for (int i = k - 1; i >= 0; i--) result[0] += nums[i];
        for (int i = k; i < len; i++) result[i - k + 1] = result[i - k] - nums[i - k] + nums[i];
    }
    else
    {
        Dictionary<int, int> freq = new Dictionary<int, int>();
        PriorityQueue<int, (int,int)> maxpq = new PriorityQueue<int, (int,int)>();
        for (int i = k - 1; i >= 0; i--) if (freq.ContainsKey(nums[i])) freq[nums[i]]++; else freq.Add(nums[i], 1);
        foreach (var kv in freq) maxpq.Enqueue(kv.Key * kv.Value, -kv.Value);
        for (int j = 0; j < x && maxpq.Count > 0; j++) result[0] += maxpq.Dequeue();
        for (int i = k; i < len; i++)
        { 

        }
    }

    return result;
}
*/
    }
}

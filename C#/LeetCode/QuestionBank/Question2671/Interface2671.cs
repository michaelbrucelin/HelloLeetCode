using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2671
{
    /// <summary>
    /// Your FrequencyTracker object will be instantiated and called as such:
    /// FrequencyTracker obj = new FrequencyTracker();
    /// obj.Add(number);
    /// obj.DeleteOne(number);
    /// bool param_3 = obj.HasFrequency(frequency);
    /// </summary>
    public interface Interface2671
    {
        // public FrequencyTracker()；

        public void Add(int number);

        public void DeleteOne(int number);

        public bool HasFrequency(int frequency);
    }
}

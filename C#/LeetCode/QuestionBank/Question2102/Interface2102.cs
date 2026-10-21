using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2102
{
    /// <summary>
    /// Your SORTracker object will be instantiated and called as such:
    /// SORTracker obj = new SORTracker();
    /// obj.Add(name,score);
    /// string param_2 = obj.Get();
    /// </summary>
    public interface Interface2102
    {
        // public SORTracker(){ }

        public void Add(string name, int score);

        public string Get();
    }
}

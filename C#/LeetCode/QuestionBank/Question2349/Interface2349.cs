using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2349
{
    /// <summary>
    /// Your NumberContainers object will be instantiated and called as such:
    /// NumberContainers obj = new NumberContainers();
    /// obj.Change(index,number);
    /// int param_2 = obj.Find(number);
    /// </summary>
    public interface Interface2349
    {
        // public NumberContainers() {}

        public void Change(int index, int number);

        public int Find(int number);
    }
}

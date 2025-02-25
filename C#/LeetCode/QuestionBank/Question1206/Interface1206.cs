using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1206
{
    /// <summary>
    /// Your Skiplist object will be instantiated and called as such:
    /// Skiplist obj = new Skiplist();
    /// bool param_1 = obj.Search(target);
    /// obj.Add(num);
    /// bool param_3 = obj.Erase(num);
    /// </summary>
    public interface Interface1206
    {
        // public Skiplist(){ }

        public bool Search(int target);

        public void Add(int num);

        public bool Erase(int num);
    }
}

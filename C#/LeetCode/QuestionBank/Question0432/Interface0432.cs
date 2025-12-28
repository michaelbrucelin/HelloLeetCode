using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0432
{
    /// <summary>
    /// Your AllOne object will be instantiated and called as such:
    /// AllOne obj = new AllOne();
    /// obj.Inc(key);
    /// obj.Dec(key);
    /// string param_3 = obj.GetMaxKey();
    /// string param_4 = obj.GetMinKey();
    /// </summary>
    public interface Interface0432
    {
        // public AllOne(){ }

        public void Inc(string key);

        public void Dec(string key);

        public string GetMaxKey();

        public string GetMinKey();
    }
}
